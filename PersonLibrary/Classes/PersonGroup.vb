Namespace Classes
    Public Class PersonGroup
        Public Property City() As String
        Public Property Country() As String
        Public Property Grouping As List(Of Person)

        Public Overrides Function ToString() As String
            Return $"{City}, {Country}"
        End Function
    End Class
End NameSpace