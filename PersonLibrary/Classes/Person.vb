
Namespace Classes
    Public Class Person
        Public Property Id() As Integer
        Public Property FirstName() As String
        Public Property LastName As String
        Public Property BirthDate() As DateTime
        Public ReadOnly Property Age() As Integer
            Get
                Return Convert.ToInt32(Date.UtcNow.Date.Year - BirthDate.Year)
            End Get
        End Property
        Public Property Sex() As String
        Public Property City As String
        Public Property Country As String

        Public Overrides Function ToString() As String
            Return $"{FirstName} {LastName}"
        End Function

    End Class
End Namespace