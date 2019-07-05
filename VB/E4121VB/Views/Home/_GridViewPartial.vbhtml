@Code
    Dim grid = Html.DevExpress().
        GridView(Sub(settings)
                     settings.Name = "GridView"
                     settings.Width = Unit.Percentage(100)
                     settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial"}

                     settings.KeyFieldName = "ID"

                     settings.Settings.ShowFilterRow = True

                     settings.Columns.Add("From").Width = Unit.Pixel(200)
                     settings.Columns.Add("Subject")
                     settings.Columns.Add(Sub(column)
                                              column.FieldName = "Sent"
                                              column.ColumnType = MVCxGridViewColumnType.DateEdit
                                              column.Width = Unit.Pixel(100)
                                          End Sub)
                     settings.Columns.Add("Size").Settings.AutoFilterCondition = ASPxGridView.AutoFilterCondition.BeginsWith.Equals
                     settings.Columns.Add(Sub(column)
                                              column.FieldName = "HasAttachment"
                                              column.Caption = "Attachment?"
                                              column.ColumnType = MVCxGridViewColumnType.CheckBox
                                              column.Width = Unit.Pixel(100)
                                          End Sub)
                     settings.CustomJSProperties = Sub(s, e)
                                                       Dim gridView = TryCast(s, MVCxGridView)
                                                       e.Properties("cpGridFilterExpression") = gridView.FilterExpression
                                                   End Sub
                 End Sub)
End Code
@grid.BindToLINQ("E4121VB.LargeDatabaseDataContext", "Emails").GetHtml()