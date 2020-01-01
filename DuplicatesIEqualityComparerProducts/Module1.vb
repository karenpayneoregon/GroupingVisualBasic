Imports DuplicatesIEqualityComparerProducts.Classes

Module Module1
    ''' <summary>
    ''' Example to first get distinct products in one query
    ''' followed by grouping on make property in a second query.
    ''' </summary>
    Sub Main()
        Dim productList = Products.List()

        Dim query As IEnumerable(Of Product) =
                productList.Distinct(New ProductComparer).OrderBy(Function(product) product.Make)

        For Each product As Product In query
            Console.WriteLine(product)
        Next

        Console.WriteLine()
        Console.WriteLine("Group by make")

        Dim grouped As IEnumerable(Of IGrouping(Of String, Product)) = query.GroupBy(Function(product) product.Make)
        For Each grouping As IGrouping(Of String, Product) In grouped
            Console.WriteLine(grouping.Key)
            For Each product As Product In grouping
                Console.WriteLine($"   {product}")
            Next
        Next

        Console.ReadLine()

    End Sub

End Module