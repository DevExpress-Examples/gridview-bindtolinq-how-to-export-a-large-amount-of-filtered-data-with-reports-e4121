@Code
    Dim grid = Html.DevExpress().
        GridView(Of E4121VB.Email)(Sub(settings)
                                       settings.Name = "GridView"
                                       settings.Width = Unit.Percentage(100)
                                       settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial"}

                                       settings.KeyFields(Function(m) m.ID)

                                       settings.Settings.ShowFilterRow = True

                                       settings.Columns.Add(Function(m) m.From).Width = Unit.Pixel(200)
                                       settings.Columns.Add(Function(m) m.Subject)
                                       settings.Columns.Add(Function(m) m.Sent, Sub(column)
                                                                                    column.ColumnType = MVCxGridViewColumnType.DateEdit
                                                                                    column.Settings.AutoFilterCondition = AutoFilterCondition.Equals
                                                                                    column.Width = Unit.Pixel(100)
                                                                                    column.Settings.AllowHeaderFilter = DefaultBoolean.True
                                                                                    column.SettingsHeaderFilter.Mode = GridHeaderFilterMode.DateRangePicker
                                                                                    column.Settings.AllowAutoFilter = DefaultBoolean.False
                                                                                End Sub)
                                       settings.Columns.Add(Function(m) m.Size).Settings.AutoFilterCondition = AutoFilterCondition.Equals
                                       settings.Columns.Add(Function(m) m.HasAttachment, Sub(column)
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