Namespace Models
    Partial Public Class Contact

        Public ReadOnly Property FullName() As String
            Get
                Return $"{FirstName} {LastName}"
            End Get
        End Property
    End Class
End Namespace