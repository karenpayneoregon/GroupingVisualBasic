Namespace GroupingClasses
    Public Class StudentGroup
        Public Property Year() As Integer
        Public Property ItemGroup() As List(Of StudentItemGroup)
        Public Sub New()
            ItemGroup = New List(Of StudentItemGroup)()
        End Sub
    End Class
End Namespace