
Imports NorthWindAzureSqlClient

Namespace Classes
    Friend Class CountryCompanyDataTableContainer
        Public Property CountryName As String
        Public Property Customers As IEnumerable(Of DataRow)
        Public Property Count As Integer

        Public Overrides Function ToString() As String
            Return $"{CountryName} ({Count})"
        End Function
    End Class
End NameSpace