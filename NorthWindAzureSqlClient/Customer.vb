Public Class Customer
    Public Property CustomerIdentifier() As Integer
    Public Property CompanyName() As String
    Public Property ContactName() As String
    Public Property Address() As String
    Public Property City() As String
    Public Property PostalCode() As String
    Public Property Country() As String
    Public Property Phone() As String
    Public Property ModifiedDate() As DateTime

    Public Overrides Function ToString() As String
        Return $"{CompanyName}"
    End Function
End Class
