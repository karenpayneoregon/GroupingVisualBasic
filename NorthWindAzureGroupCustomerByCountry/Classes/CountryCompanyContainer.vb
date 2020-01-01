Imports NorthWindAzureSqlClient

Namespace Classes

    Friend Class CountryCompanyContainer
        Public Property CountryName As String
        Public Property Customers As IEnumerable(Of Customer)
        Public Property Count As Integer
    End Class
End Namespace