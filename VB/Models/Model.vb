Imports System.Web
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Web.ASPxEditors
Imports System.Collections
Imports DevExpress.Data.Linq
Imports DevExpress.Data.Linq.Helpers
Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Filtering.Helpers


Public NotInheritable Class LargeDatabaseDataProvider
    Private Sub New()
    End Sub
    Shared m_db As LargeDatabaseDataContextDataContext
    Public Shared ReadOnly Property DB() As LargeDatabaseDataContextDataContext
        Get
            If m_db Is Nothing Then
                m_db = New LargeDatabaseDataContextDataContext()
            End If
            Return m_db
        End Get
    End Property
    Public Shared Function GetProducts() As IEnumerable
        Return From product In DB.Products Select product
    End Function

    Public Shared Function GetSalesOrderDetails() As IEnumerable
        Return From salesOrderDetail In DB.SalesOrderDetails Select salesOrderDetail
    End Function

    Public Shared Function GetProductsByFilter(filterCriteria As CriteriaOperator) As IList(Of Product)
        Dim converter As New CriteriaToExpressionConverter()

        Dim source As IQueryable(Of Product) = From product In DB.Products Select product
        Dim filteredData As IQueryable(Of Product) = TryCast(source.AppendWhere(converter, filterCriteria), IQueryable(Of Product))

        Return filteredData.ToList()
    End Function
End Class
