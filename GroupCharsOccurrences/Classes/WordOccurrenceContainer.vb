Namespace Classes
    Public Class WordOccurrenceContainer
        Property Word() As String
        Property Occurrences() As Integer

        Public Overrides Function ToString() As String
            Return $"{Word} {Occurrences}"
        End Function
    End Class
End NameSpace