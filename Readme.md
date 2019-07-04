<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/E4121/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/E4121VB/Controllers/HomeController.vb))
* [XtraReport1.cs](./CS/E4121/Controllers/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/E4121VB/Controllers/XtraReport1.vb))
* [LargeDatabaseDataProvider.cs](./CS/E4121/Models/LargeDatabaseDataProvider.cs) (VB: [LargeDatabaseDataProvider.vb](./VB/E4121VB/Models/LargeDatabaseDataProvider.vb))
* [GridViewPartial.cshtml](./CS/E4121/Views/Home/GridViewPartial.cshtml) (VB: [GridViewPartial.vbhtml](./VB/E4121VB/Views/Home/GridViewPartial.vbhtml))
* [Index.cshtml](./CS/E4121/Views/Home/Index.cshtml)(VB: [Index.vbhtml](./VB/E4121VB/Views/Home/Index.vbhtml)
<!-- default file list end -->
# GridView - BindToLINQ - How to export a large amount of filtered data with Reports


<p>At present our MVCxGridView export mechanism has some limitations: it is impossible to export a lot of filtered data, because the mechanism requests all data from a database and then filters it. Thus, a request can be fulfilled, and the 'System.OutOfMemoryException' exception occurs. As a solution, request filtered data yourself and export it using the XtraReports Suite. This example demonstrates how you can do this using LINQ-to-SQL.</p>
<p>To pass the FilterExpression to a Controller's Action, obtain and save it to GridView CustomJSProperties in CustomJSProperties:</p>
<br>


```cs
settings.CustomJSProperties = (s, e) =>
{
	MVCxGridView gridView = (MVCxGridView)s;
	e.Properties["cpGridFilterExpression"] = gridView.FilterExpression;
};
```

```vbnet
settings.CustomJSProperties = Sub(s, e)
	Dim gridView = TryCast(s, MVCxGridView)
	e.Properties("cpGridFilterExpression") = gridView.FilterExpression
End Sub
```


<p>When a user clicks the Export data, take the filter expression from GridView CustomJSProperties and add it to the collection of jQuery selector parameters.</p>


```js
function onClick(s, e) {
	var actionParams = $("form").attr("action").split("?filterString=");
	actionParams[1] = encodeURIComponent(GridView.cpGridFilterExpression);
	$("form").attr("action", actionParams.join("?filterString="));
}
```


<p>The XtraReport class instance that's used in this Code Example is added as described in the <a href="https://documentation.devexpress.com/XtraReports/CustomDocument9974.aspx">Lesson 1 - Create a Static Report in ASP.NET MVC</a> tutorial. The report controls are bound to data using the <a href="https://documentation.devexpress.com/XtraReports/CustomDocument2433.aspx">Embedded Fields (Mail Merge)</a> feature.<br><br>You can learn more about approaches used in this example in the following resources:</p>
<p><a href="http://documentation.devexpress.com/#XtraReports/CustomDocument4784"><u>How to: Create a Table Report</u></a><br> <a href="https://www.devexpress.com/Support/Center/p/E573">How to create a web based report at runtime</a><br> <a href="https://www.devexpress.com/Support/Center/p/E2596">How to convert the CriteriaOperator to a lambda expression, so, the latter expression can be used in the IQueriable source</a></p>
<p><a href="https://www.devexpress.com/Support/Center/p/S39667">GridView Extension - Provide the capability to export large LINQ data</a></p>

<br/>


