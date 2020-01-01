Namespace Classes

    Public Class Products
        Public Shared Function List() As List(Of Product)

            Dim products As New List(Of Product)()

            products.Add(New Product With {.Id = 1, .Make = "Samsung", .Model = "Galaxy S3"})
            products.Add(New Product With {.Id = 2, .Make = "Samsung", .Model = "Galaxy S4"})
            products.Add(New Product With {.Id = 3, .Make = "Samsung", .Model = "Galaxy S5"})
            products.Add(New Product With {.Id = 4, .Make = "Apple", .Model = "iPhone 5"})
            products.Add(New Product With {.Id = 5, .Make = "Apple", .Model = "iPhone 6"})
            products.Add(New Product With {.Id = 6, .Make = "Apple", .Model = "iPhone 6"})
            products.Add(New Product With {.Id = 7, .Make = "HTC", .Model = "Sensation"})
            products.Add(New Product With {.Id = 8, .Make = "HTC", .Model = "Desire"})
            products.Add(New Product With {.Id = 9, .Make = "HTC", .Model = "Desire"})
            products.Add(New Product With {.Id = 10, .Make = "Nokia", .Model = "Lumia 735"})
            products.Add(New Product With {.Id = 11, .Make = "Nokia", .Model = "Lumia 930"})
            products.Add(New Product With {.Id = 12, .Make = "Nokia", .Model = "Lumia 930"})
            products.Add(New Product With {.Id = 13, .Make = "Sony", .Model = "Xperia Z3"})

            Return products

        End Function

    End Class
End Namespace