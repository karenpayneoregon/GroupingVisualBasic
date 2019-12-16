Imports ConsoleTables
Imports DataTableMockedLibrary
Module Module1

    Sub Main()
        Dim operations As New Mocked

        Dim dt = operations.TaxTable()

        Dim table = New ConsoleTable("Identifier", "Product", "Tax", "Amount")

        For Each row As DataRow In dt.Rows

            table.AddRow(
                row.Field(Of Integer)("Identifier"),
                row.Field(Of String)("Product"),
                row.Field(Of Decimal)("Tax"),
                row.Field(Of Decimal)("Amount"))

        Next

        table.Write()

        Dim groupSumResults = dt.AsEnumerable.
                GroupBy(Function(row) row.Field(Of Decimal)("Tax")).
                Select(Function(group) New With
                          {
                              Key .Tax = group.Key,
                              .Sum = group.Sum(Function(row) row.Field(Of Decimal)("Amount"))
                          })

        table = New ConsoleTable("Tax amount", "Sum")

        For Each group In groupSumResults
            table.AddRow(group.Tax.ToString("C2"), group.Sum.ToString("C2"))
        Next

        table.Write()

        Console.ReadLine()

    End Sub

End Module
