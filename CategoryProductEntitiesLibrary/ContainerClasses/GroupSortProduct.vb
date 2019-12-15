Imports CategoryProductEntitiesLibrary.Models

Namespace ContainerClasses
    Public Class GroupSortProduct
        Public Property CategoryName() As String
        Public Property Products() As IOrderedEnumerable(Of Product)
    End Class
End Namespace