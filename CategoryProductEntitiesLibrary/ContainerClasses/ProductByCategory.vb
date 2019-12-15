Imports CategoryProductEntitiesLibrary.Models

Namespace ContainerClasses
    Public Class ProductByCategory
        Public Property Category() As Category
        Public Property GroupCategoryProducts() As IGrouping(Of Category, Product)
    End Class
End Namespace