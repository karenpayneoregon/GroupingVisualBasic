Namespace Classes
    Public Class Employee
        Inherits Person
        Public Property Id() As String
        Public Property Department() As String
        Public Overrides Function ToString() As String
            Return $"{FirstName} {LastName}"
        End Function

    End Class
End Namespace