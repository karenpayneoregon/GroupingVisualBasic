Namespace Classes
    Public Class Product
        Public Property Id() As Integer
        Public Property Make() As String
        Public Property Model() As String

        Public Overrides Function ToString() As String
            Return $"{Id,3}, {Make,-7}, {Model}"
        End Function
    End Class
End Namespace