Partial Public Class Person

    Public ReadOnly Property Age() As Integer
        Get
            Return Convert.ToInt32(Date.UtcNow.Date.Year - BirthDate.Value.Year)
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return $"{FirstName} {LastName}"
    End Function
End Class
