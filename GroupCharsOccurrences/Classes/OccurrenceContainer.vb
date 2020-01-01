Namespace Classes
    Public Class OccurrenceContainer
        Property Character() As Char
        Property Occurrences() As Integer

        Public Overrides Function ToString() As String
            Return $"{Character} {Occurrences}"
        End Function
    End Class
End Namespace