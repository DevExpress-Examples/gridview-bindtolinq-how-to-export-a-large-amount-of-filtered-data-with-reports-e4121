@functions
    Public Property TableKey As String
    Public ReadOnly Property RecordCount As Integer
        Get
            Return E4121VB.DatabaseGenerator.GetTable(TableKey).RecordCount
        End Get
    End Property
End functions

    <script type="text/javascript">
        var createTimer = -1;
        var progressTimer = -1;
        var tableKey = "@Model";

        function CreateDatabase() {
            $(".CreateDatabasePanel .text").html("Creating Database...");
            btnCreateDatabase.SetVisible(false);
            pbCreateDatabase.SetVisible(true);
            CreateDatabaseAsync();
            window.setInterval(GetRecordCountAsync, 1000);
        }

        function CreateDatabaseAsync() {
            $.ajax({
                type: 'POST',
                url: '@DevExpressHelper.GetUrl(New With {.Controller = "DbGenerator", .Action = "Create"})',
                data: { tableKey: tableKey },
                dataType: 'json',

                success: function(created) {
                    window.clearTimeout(createTimer);
                    if (created) {
                        window.clearInterval(progressTimer);
                        document.location.reload();
                    } else {
                        createTimer = window.setTimeout(CreateDatabaseAsync, 1000);
                    }
                },

                error: function(response) {
                    window.clearInterval(progressTimer);
                    alert(response.responseText);
                    document.location.reload();
                }

            });
        }

        function GetRecordCountAsync() {
            $.ajax({
                type: 'POST',
                url: '@DevExpressHelper.GetUrl(New With {.Controller = "DbGenerator", .Action = "GetRecordCount"})',
                dataType: 'json',
                data: { tableKey: tableKey },

                success: function (count) {
                    pbCreateDatabase.SetPosition(count);
                },

                error: function (response) {
                    window.clearInterval(progressTimer);
                    alert(response.responseText);
                    document.location.reload();
                }

            });
        }
</script>

<div class="CreateDatabasePanel">
    @Code TableKey = Model End Code
    <div class="text">
        This demo requires a large database. To create a sample database, click the Create Database button below. This may take a few minutes.
    </div>
    @Html.DevExpress().Button(Sub(settings)
                                   settings.Name = "btnCreateDatabase"
                                   settings.Text = "Create Database"
                                   settings.ClientSideEvents.Click = "function (s,e) { CreateDatabase(); }"
                               End Sub).GetHtml()
    @Html.DevExpress().ProgressBar(Sub(settings)
                                        settings.Name = "pbCreateDatabase"
                                        settings.ClientVisible = False
                                        settings.Width = Unit.Percentage(100)
                                        settings.Properties.DisplayFormatString = "0"
                                        settings.Properties.Minimum = 0
                                        settings.Properties.Maximum = RecordCount
                                    End Sub).GetHtml()
</div>
