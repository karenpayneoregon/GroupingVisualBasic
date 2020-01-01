Imports DuplicatesIEqualityComparerProducts.Classes

Module Module1

    Sub Main()
        Dim productList = Products.List()

        Dim query As IEnumerable(Of Product) =
                productList.Distinct(New ProductComparer).OrderBy(Function(product) product.Make)

        For Each product As Product In query
            Console.WriteLine(product)
        Next

        Console.ReadLine()
    End Sub

End Module