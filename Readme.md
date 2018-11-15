<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [XtraReport1.cs](./CS/Controllers/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/Controllers/XtraReport1.vb))
* [Model.cs](./CS/Models/Model.cs) (VB: [Model.vb](./VB/Models/Model.vb))
* [GridViewPartial.cshtml](./CS/Views/Home/GridViewPartial.cshtml)
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - BindToLINQ - How to export a large amount of filtered data with Reports


<p>At present our MVCxGridView export mechanism has some limitations: it is impossible to export a lot of filtered data, because the mechanism requests all data from a database and then filters it. Thus, a request can be fulfilled, and the 'System.OutOfMemoryException' exception occurs. As a solution, request filtered data yourself and export it using the XtraReports Suite. This example demonstrates how you can do this using LINQ-to-SQL.</p>
<p>To pass the FilterExpression to a Controller's Action, obtain and save it to GridView CustomJSProperties in CustomJSProperties:</p>
<br>


```cs
settings.CustomJSProperties = (s, e) =>   {
     ASPxGridView grid = (ASPxGridView)s;
     e.Properties["cpGridFilterExpression"] = grid.FilterExpression;
};

settings.CustomJSProperties = Sub(s, e)
         Dim grid As ASPxGridView = DirectCast(s, ASPxGridView)
         e.Properties("cpGridFilterExpression") = grid.FilterExpression
End Sub

```


<p>When a user clicks the Export data, take the filter expression from GridView CustomJSProperties and add it to the collection of jQuery selector parameters.</p>


```js
function OnClick(s, e) {
    var actionParams = $("form").attr("action").split("?filterString=");
    actionParams[1] = gvDataBindingToLinq.cpGridFilterExpression;
    $("form").attr("action", actionParams.join("?filterString="));
}

```


<p>The XtraReport class instance that's used in this Code Example is added as described in the <a href="https://documentation.devexpress.com/XtraReports/CustomDocument9974.aspx">Lesson 1 - Create a Static Report in ASP.NET MVC</a> tutorial. The report controls are bound to data using the <a href="https://documentation.devexpress.com/XtraReports/CustomDocument2433.aspx">Embedded Fields (Mail Merge)</a> feature.<br><br>You can learn more about approaches used in this example in the following resources:</p>
<p><a href="http://documentation.devexpress.com/#XtraReports/CustomDocument4784"><u>How to: Create a Table Report</u></a><br> <a href="https://www.devexpress.com/Support/Center/p/E573">How to create a web based report at runtime</a><br> <a href="https://www.devexpress.com/Support/Center/p/E2596">How to convert the CriteriaOperator to a lambda expression, so, the latter expression can be used in the IQueriable source</a></p>
<p><a href="https://www.devexpress.com/Support/Center/p/S39667">GridView Extension - Provide the capability to export large LINQ data</a><br> <a href="http://msdn.microsoft.com/en-us/library/aa992075%28v=vs.80%29.aspx"><u>Walkthrough: Installing the AdventureWorks Database</u></a></p>

<br/>


