Public Module EmailDataGenerator
    Dim _table As DatabaseGenerator.TableData
    ReadOnly subjects As String() = New String() {"Integrating Developer Express MasterView control into an Accounting System.", "Web Edition: Data Entry Page. There is an issue with date validation.", "Payables Due Calculator is ready for testing.", "Web Edition: Search Page is ready for testing.", "Main Menu: Duplicate Items. Somebody has to review all menu items in the system.", "Receivables Calculator. Where can I find the complete specs?", "Ledger: Inconsistency. Please fix it.", "Receivables Printing module is ready for testing.", "Screen Redraw. Somebody has to look at it.", "Email System. What library are we going to use?", "Cannot add new vendor. This module doesn't work!", "History. Will we track sales history in our system?", "Main Menu: Add a File menu. File menu item is missing.", "Currency Mask. The current currency mask in completely unusable.", "Drag & Drop operations are not available in the scheduler module.", "Data Import. What database types will we support?", "Reports. The list of incomplete reports.", "Data Archiving. We still don't have this features in our application.", "Email Attachments. Is it possible to add multiple attachments? I haven't found a way to do this.", "Check Register. We are using different paths for different modules.", "Data Export. Our customers asked us for export to Microsoft Excel"}
    ReadOnly names As String() = New String() {"Peter Dolan", "Ryan Fischer", "Richard Fisher", "Tom Hamlett", "Mark Hamilton", "Steve Lee", "Jimmy Lewis", "Jeffrey W McClain", "Andrew Miller", "Dave Murrel", "Bert Parkins", "Mike Roller", "Ray Shipman", "Paul Bailey", "Brad Barnes", "Carl Lucas", "Jerry Campbell"}

    Public ReadOnly Property Table As DatabaseGenerator.TableData
        Get
            Return _table
        End Get
    End Property

    Sub Register()
        _table = New DatabaseGenerator.TableData()
        _table.Name = "Emails"
        _table.ConnectionStringName = "LargeDatabaseConnectionString"
        _table.Fields.Add(New DatabaseGenerator.FieldData("Subject", subjects))
        _table.Fields.Add(New DatabaseGenerator.FieldData("From", names))
        _table.Fields.Add(New DatabaseGenerator.FieldData("Sent", AddressOf GenerateSent))
        _table.Fields.Add(New DatabaseGenerator.FieldData("Size", AddressOf GenerateSize))
        _table.Fields.Add(New DatabaseGenerator.FieldData("HasAttachment", AddressOf GenerateHasAttachment))
        _table.RecordCount = 100000
        DatabaseGenerator.RegisterTable("GeneratedEmailTable", _table)
    End Sub

    Private Function GenerateSent(ByVal rnd As Random) As Object
        Return DateTime.Now.Date.Subtract(TimeSpan.FromDays(rnd.Next(50)))
    End Function

    Private Function GenerateSize(ByVal rnd As Random) As Object
        Return CLng((1000 + rnd.Next(300000)))
    End Function

    Private Function GenerateHasAttachment(ByVal rnd As Random) As Object
        Return rnd.Next(10) > 5
    End Function
End Module
