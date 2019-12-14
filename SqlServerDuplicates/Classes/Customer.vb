Namespace Classes
    Public Class Customer
        Public Property Identifier As Integer
        Public Property CompanyName As String
        Public Property ContactName As String
        Public Property ContactTitle As String
        Public Property Address As String
        Public Property City As String
        Public Property PostalCode As String
        Public ReadOnly Property ItemArray() As String()
            Get
                Return {CStr(Identifier).PadLeft(3, "0"c), CompanyName, ContactName, ContactTitle, Address, City, PostalCode}
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return $"'{CompanyName}' '{ContactName}' '{ContactTitle}' '{Address}' '{City}' '{PostalCode}'"
        End Function
    End Class
End Namespace