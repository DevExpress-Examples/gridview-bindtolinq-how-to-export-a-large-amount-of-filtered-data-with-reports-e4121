@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "gvDataBindingToLinq"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "DataBindingToLargeDatabasePartial"}

            settings.KeyFieldName = "ProductID"
            settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)

            settings.Settings.ShowFilterRow = True
            settings.Settings.ShowFilterRowMenu = True
       

            settings.Columns.Add("Name")
            settings.Columns.Add("ProductNumber")
            settings.Columns.Add("StandardCost")
            settings.Columns.Add("Color")
            settings.Columns.Add("SafetyStockLevel")

            settings.CustomJSProperties = Sub(s, e)
                                                  Dim grid As ASPxGridView = DirectCast(s, ASPxGridView)
                                                  e.Properties("cpGridFilterExpression") = grid.FilterExpression
                                          End Sub
       
    End Sub).BindToLINQ("VB.LargeDatabaseDataContextDataContext", "Products").GetHtml()
