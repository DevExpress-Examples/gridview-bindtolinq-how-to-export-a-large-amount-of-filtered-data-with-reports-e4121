Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Linq
Imports DevExpress.Data.Linq.Helpers

Public Module LargeDatabaseDataProvider
    Dim _db As LargeDatabaseDataContext

    Public ReadOnly Property DB As LargeDatabaseDataContext
        Get
            If _db Is Nothing Then _db = New LargeDatabaseDataContext()
            Return _db
        End Get
    End Property

    Function GetEmailsByFilter(ByVal filterCriteria As CriteriaOperator) As IList(Of Email)
        Dim converter As CriteriaToExpressionConverter = New CriteriaToExpressionConverter()
        Dim source As IQueryable(Of Email) = From product In DB.Emails Select product
        Dim filteredData As IQueryable(Of Email) = TryCast(source.AppendWhere(converter, filterCriteria), IQueryable(Of Email))
        Return filteredData.ToList()
    End Function
End Module
