@Code
    ViewData("Title") = "Home Page"
End Code

@Code If Not E4121VB.DatabaseGenerator.IsReady("GeneratedEmailTable") Then
        @Html.Partial("_CreateDatabasePartial", "GeneratedEmailTable")
    Else
End Code
    <script type="text/javascript">
        function onClick(s, e) {
            var actionParams = $("form").attr("action").split("?filterString=");
            actionParams[1] = encodeURIComponent(GridView.cpGridFilterExpression);
            $("form").attr("action", actionParams.join("?filterString="));
        }
    </script>

    @Using (Html.BeginForm(New With {.Controller = "Home", .Action = "ExportTo"}))

        Html.DevExpress().Button(Sub(btn)

                                     btn.Name = "btnExportToXLSX"
                                     btn.Text = "Export to XLSx"
                                     btn.UseSubmitBehavior = True
                                     btn.ClientSideEvents.Click = "onClick"
                                 End Sub).Render()
        ViewContext.Writer.Write("<br />")
        Html.RenderAction("GridViewPartial")
    End Using
@Code
    End If
End Code