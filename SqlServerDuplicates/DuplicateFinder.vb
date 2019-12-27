Imports SqlServerDuplicates.Classes

Public Class DuplicateFinder
    ''' <summary>
    ''' Responsible for obtaining duplication Customer records by
    ''' Company name, contact name, contact title and return the following fields
    ''' Identifier - important if work needs to be done later in the presentation layer
    ''' CompanyName, ContactName, ContactTitle, Address, City, PostalCode
    ''' </summary>
    ''' <returns></returns>
    Public Function GetCustomerDuplicatesAsDataTable() As DataTable
        Dim dataOperations As New DataOperations

        Dim dt As DataTable = dataOperations.ReadCustomersFromDatabase()

        Dim duplicateTable As DataTable = dt.Clone()

        duplicateTable.Columns("Identifier").AutoIncrement = False

        Dim duplicates = From dataRow In dt.AsEnumerable() Select item = New With {
                Key .Identifier = dataRow.Field(Of Integer)("Identifier"),
                Key .CompanyName = dataRow.Field(Of String)("CompanyName"),
                Key .ContactName = dataRow.Field(Of String)("ContactName"),
                Key .ContactTitle = dataRow.Field(Of String)("ContactTitle"),
                Key .Street = dataRow.Field(Of String)("Address"),
                Key .City = dataRow.Field(Of String)("City"),
                Key .PostalCode = dataRow.Field(Of String)("PostalCode")}
                         Group temp = item By Key = New With {
                    Key .CompanyName = item.CompanyName,
                    Key .ContactName = item.ContactName,
                    Key .ContactTitle = item.ContactTitle} Into Group
                         Where Group.Count() > 1
                         Select Group.Select(Function(g) New With {
                                         Key g.Identifier,
                                         Key g.CompanyName,
                                         Key g.ContactName,
                                         Key g.ContactTitle,
                                         Key g.Street,
                                         Key g.City,
                                         Key g.PostalCode
                                  })


        For Each Item In duplicates

            For Each row In Item
                duplicateTable.Rows.Add((New Object() _
                    {
                        row.Identifier,
                        row.CompanyName,
                        row.ContactName,
                        row.ContactTitle,
                        row.Street,
                        row.City,
                        row.PostalCode
                    }))
            Next

        Next

        Return duplicateTable

    End Function
    Public Function GetCustomerDuplicatesAsList() As List(Of CustomerRigger)
        Dim dataOperations As New DataOperations

        Dim dt As DataTable = dataOperations.ReadCustomersFromDatabase()

        Dim duplicates As IEnumerable(Of IEnumerable(Of CustomerRigger)) = From dataRow In dt.AsEnumerable() Select item = New With {
                Key .Identifier = dataRow.Field(Of Integer)("Identifier"),
                Key .CompanyName = dataRow.Field(Of String)("CompanyName"),
                Key .ContactName = dataRow.Field(Of String)("ContactName"),
                Key .ContactTitle = dataRow.Field(Of String)("ContactTitle"),
                Key .Street = dataRow.Field(Of String)("Address"),
                Key .City = dataRow.Field(Of String)("City"),
                Key .PostalCode = dataRow.Field(Of String)("PostalCode")}
                                                                           Group temp = item By Key = New With {
                    Key .CompanyName = item.CompanyName,
                    Key .ContactName = item.ContactName,
                    Key .ContactTitle = item.ContactTitle}
                Into Group Where Group.Count() > 1 Select Group.Select(Function(g) New CustomerRigger With {
                                         .Identifier = g.Identifier,
                                         .CompanyName = g.CompanyName,
                                         .ContactName = g.ContactName,
                                         .ContactTitle = g.ContactTitle,
                                         .Address = g.Street,
                                         .City = g.City,
                                         .PostalCode = g.PostalCode
                                  })


        Return (From item In duplicates From row In item Select row).ToList()

    End Function
End Class

