Imports DuplicatesIEqualityComparerProducts.Classes

Module Module1
    ''' <summary>
    ''' Example to first get distinct products in one query
    ''' followed by grouping on make property in a second query.
    ''' </summary>
    Sub Main()
        Dim productList = Products.List()

        Console.WriteLine("Original list")

        productList.ForEach(Sub(product) Console.WriteLine(product))

        Console.WriteLine()
        Console.WriteLine("ProductComparer results")

        Dim productsQuery As IEnumerable(Of Product) =
                productList.Distinct(New ProductComparer).
                OrderBy(Function(product) product.Make)


        For Each product As Product In productsQuery
            Console.WriteLine(product)
        Next

        Console.WriteLine()
        Console.WriteLine("Group by make")

        Dim grouped As IEnumerable(Of IGrouping(Of String, Product)) =
                productsQuery.GroupBy(Function(product) product.Make)

        For Each grouping As IGrouping(Of String, Product) In grouped
            Console.WriteLine(grouping.Key)
            For Each product As Product In grouping
                Console.WriteLine($"   {product}")
            Next
        Next

        Console.ReadLine()

    End Sub

End Module