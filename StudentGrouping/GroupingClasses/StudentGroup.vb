Namespace GroupingClasses
    Public Class StudentGroup
        Public Property Year() As Integer
        Public Property ItemGroup() As List(Of ItemGroup)
        Public Sub New()
            ItemGroup = New List(Of ItemGroup)()
        End Sub
    End Class
End Namespace