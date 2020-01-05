Public Class PersonGroup
    Public Property City() As String
    Public Property Country() As String
    Public Property PersonCount() As Integer
    Public Property List As List(Of Person)

    Public Overrides Function ToString() As String
        Return $"{City}, {Country}"
    End Function
End Class