<script type="text/javascript">
    function OnClick(s, e) {

        var actionParams = $("form").attr("action").split("?filterString=");
        actionParams[1] = gvDataBindingToLinq.cpGridFilterExpression;
        $("form").attr("action", actionParams.join("?filterString="));
    }
</script>

@Using (Html.BeginForm(New With {.Controller = "Home", .Action = "ExportTo"}))  
    @Html.DevExpress().Button( _
        Sub(btn)
            btn.Name = "btnExportToXLSX"
            btn.Text = "Export to XLSx"
            btn.UseSubmitBehavior = True
            btn.ClientSideEvents.Click = "OnClick"
        End Sub).GetHtml()
    @<br />
    @Html.Partial("GridViewPartial")
End Using