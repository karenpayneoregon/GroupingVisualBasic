Namespace Classes

    Public Class Products
        Public Shared Function List() As List(Of Product)
            Dim products As New List(Of Product) From {
                New Product With {.Id = 1, .Make = "Samsung", .Model = "Galaxy S3"},
                New Product With {.Id = 2, .Make = "Samsung", .Model = "Galaxy S4"},
                New Product With {.Id = 3, .Make = "Samsung", .Model = "Galaxy S5"},
                New Product With {.Id = 4, .Make = "Apple", .Model = "iPhone 5"},
                New Product With {.Id = 5, .Make = "Apple", .Model = "iPhone 6"},
                New Product With {.Id = 6, .Make = "Apple", .Model = "iPhone 6"},
                New Product With {.Id = 7, .Make = "Apple", .Model = "iPhone 6"},
                New Product With {.Id = 8, .Make = "HTC", .Model = "Sensation"},
                New Product With {.Id = 9, .Make = "HTC", .Model = "Desire"},
                New Product With {.Id = 11, .Make = "HTC", .Model = "Desire"},
                New Product With {.Id = 12, .Make = "Nokia", .Model = "Lumia 735"},
                New Product With {.Id = 13, .Make = "Nokia", .Model = "Lumia 930"},
                New Product With {.Id = 14, .Make = "Nokia", .Model = "Lumia 930"},
                New Product With {.Id = 15, .Make = "Sony", .Model = "Xperia Z3"}
            }

            Return products

        End Function

    End Class
End Namespace