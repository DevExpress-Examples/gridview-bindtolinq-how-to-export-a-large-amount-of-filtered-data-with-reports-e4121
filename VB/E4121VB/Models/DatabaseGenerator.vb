Imports System.Data.SqlClient

Public Module DatabaseGenerator
    Public Class TableData
        Public ConnectionStringName As String
        Public Name As String
        Public Fields = New List(Of FieldData)
        Public RecordCount As Integer
        Public ReadOnly Property ConnectionString As String
            Get
                Dim sqlString = ConfigurationManager.ConnectionStrings(ConnectionStringName).ConnectionString
                Return sqlString
            End Get
        End Property
    End Class
    Public Class FieldData

        Shared rnd As New Random()
        Public Delegate Function ValueGeneratorDelegate(ByVal rnd As Random) As Object
        Protected Sub New(name As String)
            Me.Name = name
        End Sub

        Public Sub New(name As String, possibleValues As IList)
            Me.New(name)
            Me.PossibleValues = possibleValues
        End Sub
        Public Sub New(name As String, valueGenerator As ValueGeneratorDelegate)
            Me.New(name)
            Me.ValueGenerator = valueGenerator
        End Sub
        Public Name As String
        Public PossibleValues As IList
        Public ValueGenerator As ValueGeneratorDelegate
        Public Function GenerateValue() As Object
            Dim result = Nothing
            If PossibleValues IsNot Nothing Then
                result = PossibleValues(rnd.Next(PossibleValues.Count - 1))
            End If
            If ValueGenerator IsNot Nothing Then
                result = ValueGenerator(rnd)
            End If
            Return result
        End Function
    End Class

    ReadOnly _lockers As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
    ReadOnly _lockersLock As Object = New Object()
    Dim _recordCountTable As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)()
    Dim _tables As Dictionary(Of String, TableData) = New Dictionary(Of String, TableData)()

    Public Sub RegisterTable(ByVal key As String, ByVal table As TableData)
        _tables(key) = table
    End Sub

    Public Function GetTable(ByVal key As String) As TableData
        Return _tables(key)
    End Function

    Public Function IsReady(ByVal tableKey As String) As Boolean
        Return Not IsDatabaseCreating(tableKey) AndAlso IsDatabaseCreated(tableKey)
    End Function

    Public Function TryCreateDatabase(ByVal tableKey As String) As Boolean
        If IsDatabaseCreating(tableKey) Then Return False

        If Not _lockers.ContainsKey(tableKey) Then

            SyncLock _lockersLock
                _lockers(tableKey) = New Object()
            End SyncLock
        End If

        SyncLock _lockers(tableKey)
            If IsDatabaseCreated(tableKey) Then Return True
            _recordCountTable.Add(tableKey, 0)

            Try
                GenerateDatabase(tableKey)
            Finally
                _recordCountTable.Remove(tableKey)
            End Try

            Return False
        End SyncLock
    End Function

    Public Function GetCreatingDatabaseRecordCount(ByVal tableKey As String) As Integer
        If _recordCountTable.ContainsKey(tableKey) Then Return _recordCountTable(tableKey)
        Return GetRecordCount(tableKey)
    End Function

    Private Function IsDatabaseCreated(ByVal tableKey As String) As Boolean
        Return GetRecordCount(tableKey) > 0
    End Function

    Private Function IsDatabaseCreating(ByVal tableKey As String) As Boolean
        Return _recordCountTable.ContainsKey(tableKey)
    End Function

    Private Sub GenerateDatabase(ByVal tableKey As String)
        Dim table As TableData = _tables(tableKey)

        Using connection As SqlConnection = New SqlConnection(table.ConnectionString)
            connection.Open()
            Dim transaction As SqlTransaction = Nothing

            For i As Integer = 0 To table.RecordCount - 1

                If i = 1 OrElse i Mod 1000 = 0 Then
                    CommitTransaction(transaction)
                    _recordCountTable(tableKey) = i
                    transaction = connection.BeginTransaction()
                End If

                Using cmd As SqlCommand = CreateInsertCommand(table.Name, table.Fields)
                    cmd.Connection = connection
                    cmd.Transaction = transaction
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        Throw
                    End Try

                End Using
            Next

            CommitTransaction(transaction)
        End Using
    End Sub

    Private Sub CommitTransaction(ByVal transaction As SqlTransaction)
        If transaction Is Nothing Then Return

        Try
            transaction.Commit()
        Catch
            transaction.Rollback()
            Throw
        End Try
    End Sub

    Private Function CreateInsertCommand(ByVal tableName As String, ByVal fields As List(Of FieldData)) As SqlCommand
        Dim builder As StringBuilder = New StringBuilder()
        builder.AppendFormat("insert into [{0}] (", tableName)

        For i As Integer = 0 To fields.Count - 1
            If i > 0 Then builder.Append(", ")
            builder.AppendFormat("[{0}]", fields(i).Name)
        Next

        builder.Append(") values (")

        For i As Integer = 0 To fields.Count - 1
            If i > 0 Then builder.Append(", ")
            builder.Append("@p" & i)
        Next

        builder.Append(")")
        Dim result As SqlCommand = New SqlCommand(builder.ToString())

        For i As Integer = 0 To fields.Count - 1
            result.Parameters.Add(New SqlParameter("@p" & i, fields(i).GenerateValue()))
        Next

        Return result
    End Function

    Private Function GetRecordCount(ByVal tableKey As String) As Integer
        Try
            Dim table As TableData = _tables(tableKey)

            Using connection As SqlConnection = New SqlConnection(table.ConnectionString)
                connection.Open()
                Dim cmd As SqlCommand = New SqlCommand("select count(*) from " & table.Name, connection)
                Return CInt(cmd.ExecuteScalar())
            End Using

        Catch
            Return 0
        End Try
    End Function
End Module
