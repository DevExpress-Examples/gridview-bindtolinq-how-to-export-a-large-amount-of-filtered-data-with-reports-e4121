Imports System.IO
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.Web.Mvc
Imports DevExpress.Web.ASPxGridView
Imports System.Data
Imports DevExpress.XtraReports.UI
Imports System.Collections.Generic
Imports DevExpress.Data.Filtering
Imports VB.WebReportRuntime


Namespace CS.Controllers
    Public Class HomeController
        Inherits Controller
        Public Function Index() As ActionResult
            Return View()
        End Function

        Public Function DataBindingToLargeDatabasePartial() As ActionResult
            Return PartialView("GridViewPartial")
        End Function

        Public Function ExportTo(filterString As String) As ActionResult
            Dim filterCriteria As CriteriaOperator = CriteriaOperator.Parse(filterString)
            Dim products As IList(Of Product) = LargeDatabaseDataProvider.GetProductsByFilter(filterCriteria)

            Dim report As New XtraReport1()
            report.DataSource = products
            ExportReport(report, "largeData", True, "Xlsx")
            Return PartialView("GridViewPartial")
        End Function

        Public Sub ExportReport(report As XtraReport, fileName As String, saveAsFile As Boolean, fileFormat As String)
            Using stream As New MemoryStream()
                report.ExportToXlsx(stream)

                Dim disposition As String = If(saveAsFile, "attachment", "inline")

                Response.Clear()
                Response.Buffer = False
                Response.AppendHeader("Content-Type", String.Format("application/{0}", fileFormat))
                Response.AppendHeader("Content-Transfer-Encoding", "binary")
                Response.AppendHeader("Content-Disposition", String.Format("{0}; filename={1}.{2}", disposition, HttpUtility.UrlEncode(fileName).Replace("+", "%20"), fileFormat))
                Response.BinaryWrite(stream.ToArray())
                Response.[End]()
            End Using
        End Sub

    End Class

End Namespace
