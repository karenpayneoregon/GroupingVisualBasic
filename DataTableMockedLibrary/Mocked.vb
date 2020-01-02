Imports DataTableMockedLibrary.Classes

Public Class Mocked
    Public Function TaxTable() As DataTable
        Dim dt As New DataTable With {.TableName = "TaxDemoTable"}

        dt.Columns.Add(New DataColumn With {
                          .ColumnName = "Identifier",
                          .DataType = GetType(Integer),
                          .AutoIncrement = True, .AutoIncrementSeed = 1})

        dt.Columns.Add(New DataColumn With {.ColumnName = "Product", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Tax", .DataType = GetType(Decimal)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Amount", .DataType = GetType(Decimal)})

        dt.Rows.Add(New Object() {Nothing, "Product A", 5D, 500D})
        dt.Rows.Add(New Object() {Nothing, "Product B", 13.5D, 1200D})
        dt.Rows.Add(New Object() {Nothing, "Product C", 17.5D, 1800D})
        dt.Rows.Add(New Object() {Nothing, "Product D", 17.5D, 200D})
        dt.Rows.Add(New Object() {Nothing, "Product E", 13.5D, 150D})
        dt.Rows.Add(New Object() {Nothing, "Product F", 13.5D, 350D})

        Return dt

    End Function
    ''' <summary>
    ''' Group data to an anonymous result set, can not be
    ''' used outside of this procedure but the DataTable can
    ''' yet in many cases a DataTable is overkill when grouping
    ''' data.
    ''' 
    ''' See Example2 which performs the same grouping to a strongly typed
    ''' class.
    ''' </summary>
    ''' <remarks>
    ''' Group by serial number and order by serial number
    ''' </remarks>
    Public Sub Example1()
        Dim originalTable = New DataTable With {.TableName = "CompanySerialNumber"}

        originalTable.Columns.Add(New DataColumn With {.ColumnName = "Serial", .DataType = GetType(Integer)})
        originalTable.Columns.Add(New DataColumn With {.ColumnName = "Name", .DataType = GetType(String)})
        originalTable.Columns.Add(New DataColumn With {.ColumnName = "Date", .DataType = GetType(Date)})

        Dim resultTable As DataTable = originalTable.Clone()

        originalTable.Rows.Add(New Object() {222, "IBM", New DateTime(2016, 1, 13)})
        originalTable.Rows.Add(New Object() {111, "Microsoft", New DateTime(2017, 1, 12)})
        originalTable.Rows.Add(New Object() {333, "Apple", New DateTime(2010, 5, 15)})
        originalTable.Rows.Add(New Object() {111, "Microsoft", New DateTime(2017, 1, 1)})
        originalTable.Rows.Add(New Object() {222, "IBM", New DateTime(1980, 12, 12)})

        ' anonymous result set
        ' only lives in this procedure
        Dim results = originalTable.AsEnumerable().
                GroupBy(Function(dataRow) dataRow.Field(Of Integer)("Serial")).
                Select(Function(group) New With {
                     Key .Serial = group.Key,
                     Key .DataRow = group.OrderByDescending(Function(row) row.Field(Of Date)("Date")).FirstOrDefault()
                     }).OrderBy(Function(group) group.DataRow.Field(Of Integer)("Serial"))

        ' copy group data to new DataTable
        ' can be passed (when using a function) to a caller method
        For Each group In results

            resultTable.Rows.Add(New Object() _
                {
                    group.Serial,
                    group.DataRow.Field(Of String)("Name"),
                    group.DataRow.Field(Of Date)("Date")
                })

        Next

        For Each group In results
            Console.WriteLine(group.Serial)


        Next

        Console.WriteLine()
    End Sub
    Public Sub Example2()
        Dim dt = New DataTable With {.TableName = "CompanySerialNumber"}

        dt.Columns.Add(New DataColumn With {.ColumnName = "Serial", .DataType = GetType(Integer)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Name", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Date", .DataType = GetType(Date)})

        Dim resultTable As DataTable = dt.Clone()

        dt.Rows.Add(New Object() {222, "IBM", New DateTime(2016, 1, 13)})
        dt.Rows.Add(New Object() {111, "Microsoft", New DateTime(2017, 1, 12)})
        dt.Rows.Add(New Object() {333, "Apple", New DateTime(2010, 5, 15)})
        dt.Rows.Add(New Object() {111, "Microsoft", New DateTime(2017, 1, 1)})
        dt.Rows.Add(New Object() {222, "IBM", New DateTime(1980, 12, 12)})

        ' strong typed result set which can be used by a caller if this procedure
        ' was a function.
        Dim results As IOrderedEnumerable(Of ExampleResultsSet) = dt.AsEnumerable().
                GroupBy(Function(dataRow) dataRow.Field(Of Integer)("Serial")).
                Select(Function(group) New ExampleResultsSet With {
                          .Serial = group.Key,
                          .DataRow = group.OrderByDescending(Function(row) row.Field(Of Date)("Date")).FirstOrDefault()
                          }).OrderBy(Function(group) group.DataRow.Field(Of Integer)("Serial"))

        For Each group In results

            resultTable.Rows.Add(New Object() _
                {
                    group.Serial,
                    group.DataRow.Field(Of String)("Name"),
                    group.DataRow.Field(Of Date)("Date")
                })

        Next

    End Sub
End Class