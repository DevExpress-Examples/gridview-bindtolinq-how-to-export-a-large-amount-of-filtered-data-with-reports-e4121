Imports System.Web.Mvc

Namespace Controllers
    Public Class DbGeneratorController
        Inherits Controller

        Public Function Create() As ActionResult
            Return New JsonResult With {
                .Data = DatabaseGenerator.TryCreateDatabase(GetTableKey())
            }
        End Function

        Public Function GetRecordCount() As ActionResult
            Return New JsonResult With {
                .Data = DatabaseGenerator.GetCreatingDatabaseRecordCount(GetTableKey())
            }
        End Function

        Private Function GetTableKey() As String
            Return Request.Params("tableKey")
        End Function

        Protected Overrides Sub OnException(ByVal filterContext As ExceptionContext)
            filterContext.Result = New ContentResult() With {
                .Content = filterContext.Exception.Message,
                .ContentType = "text/plain"
            }
            filterContext.ExceptionHandled = True
            Response.StatusCode = 500
        End Sub
    End Class
End Namespace