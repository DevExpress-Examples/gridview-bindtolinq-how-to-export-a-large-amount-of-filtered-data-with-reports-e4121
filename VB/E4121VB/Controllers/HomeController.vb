Imports System.IO
Imports DevExpress.Data.Filtering
Imports DevExpress.Web.Mvc
Imports DevExpress.XtraReports.UI
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        EmailDataGenerator.Register()
        Return View()
    End Function

    <ValidateInput(False)>
    Public Function GridViewPartial() As ActionResult
        Return PartialView("_GridViewPartial")
    End Function

    Public Function ExportTo(ByVal filterString As String) As ActionResult
        Dim filterCriteria As CriteriaOperator = CriteriaOperator.Parse(filterString)
        Dim emails As IList(Of Email) = LargeDatabaseDataProvider.GetEmailsByFilter(filterCriteria)
        Dim report As XtraReport1 = New XtraReport1()
        report.DataSource = emails
        ExportReport(report, "largeData", True, "Xlsx")
        Return GridViewPartial()
    End Function

    Public Sub ExportReport(ByVal report As XtraReport, ByVal fileName As String, ByVal saveAsFile As Boolean, ByVal fileFormat As String)
        Using stream As MemoryStream = New MemoryStream()
            report.ExportToXlsx(stream)
            Dim disposition As String = If(saveAsFile, "attachment", "inline")
            Response.Clear()
            Response.Buffer = False
            Response.AppendHeader("Content-Type", String.Format("application/{0}", fileFormat))
            Response.AppendHeader("Content-Transfer-Encoding", "binary")
            Response.AppendHeader("Content-Disposition", String.Format("{0}; filename={1}.{2}", disposition, HttpUtility.UrlEncode(fileName).Replace("+", "%20"), fileFormat))
            Response.BinaryWrite(stream.ToArray())
            Response.End()
        End Using
    End Sub
End Class