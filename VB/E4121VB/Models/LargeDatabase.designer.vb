﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="LargeDatabase")>  _
Partial Public Class LargeDatabaseDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertEmail(instance As Email)
    End Sub
  Partial Private Sub UpdateEmail(instance As Email)
    End Sub
  Partial Private Sub DeleteEmail(instance As Email)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("LargeDatabaseConnectionString").ConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property Emails() As System.Data.Linq.Table(Of Email)
		Get
			Return Me.GetTable(Of Email)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.Emails")>  _
Partial Public Class Email
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _ID As Integer
	
	Private _Subject As String
	
	Private _From As String
	
	Private _Sent As Date
	
	Private _Size As Long
	
	Private _HasAttachment As Boolean
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnIDChanged()
    End Sub
    Partial Private Sub OnSubjectChanging(value As String)
    End Sub
    Partial Private Sub OnSubjectChanged()
    End Sub
    Partial Private Sub OnFromChanging(value As String)
    End Sub
    Partial Private Sub OnFromChanged()
    End Sub
    Partial Private Sub OnSentChanging(value As Date)
    End Sub
    Partial Private Sub OnSentChanged()
    End Sub
    Partial Private Sub OnSizeChanging(value As Long)
    End Sub
    Partial Private Sub OnSizeChanged()
    End Sub
    Partial Private Sub OnHasAttachmentChanging(value As Boolean)
    End Sub
    Partial Private Sub OnHasAttachmentChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ID", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property ID() As Integer
		Get
			Return Me._ID
		End Get
		Set
			If ((Me._ID = value)  _
						= false) Then
				Me.OnIDChanging(value)
				Me.SendPropertyChanging
				Me._ID = value
				Me.SendPropertyChanged("ID")
				Me.OnIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Subject", DbType:="VarChar(100) NOT NULL", CanBeNull:=false)>  _
	Public Property Subject() As String
		Get
			Return Me._Subject
		End Get
		Set
			If (String.Equals(Me._Subject, value) = false) Then
				Me.OnSubjectChanging(value)
				Me.SendPropertyChanging
				Me._Subject = value
				Me.SendPropertyChanged("Subject")
				Me.OnSubjectChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_From", DbType:="VarChar(32) NOT NULL", CanBeNull:=false)>  _
	Public Property [From]() As String
		Get
			Return Me._From
		End Get
		Set
			If (String.Equals(Me._From, value) = false) Then
				Me.OnFromChanging(value)
				Me.SendPropertyChanging
				Me._From = value
				Me.SendPropertyChanged("[From]")
				Me.OnFromChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Sent", DbType:="DateTime NOT NULL")>  _
	Public Property Sent() As Date
		Get
			Return Me._Sent
		End Get
		Set
			If ((Me._Sent = value)  _
						= false) Then
				Me.OnSentChanging(value)
				Me.SendPropertyChanging
				Me._Sent = value
				Me.SendPropertyChanged("Sent")
				Me.OnSentChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Size", DbType:="BigInt NOT NULL")>  _
	Public Property Size() As Long
		Get
			Return Me._Size
		End Get
		Set
			If ((Me._Size = value)  _
						= false) Then
				Me.OnSizeChanging(value)
				Me.SendPropertyChanging
				Me._Size = value
				Me.SendPropertyChanged("Size")
				Me.OnSizeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_HasAttachment", DbType:="Bit NOT NULL")>  _
	Public Property HasAttachment() As Boolean
		Get
			Return Me._HasAttachment
		End Get
		Set
			If ((Me._HasAttachment = value)  _
						= false) Then
				Me.OnHasAttachmentChanging(value)
				Me.SendPropertyChanging
				Me._HasAttachment = value
				Me.SendPropertyChanged("HasAttachment")
				Me.OnHasAttachmentChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class
