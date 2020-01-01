Imports NorthWindAzureSqlClient
''' <summary>
''' Code sample taken from
''' https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/queries/group-by-clause
''' In the page above there was no code to get customers from a data source, here data is read from
''' a SQL-Server database.
''' 
''' Some name changes were done.
''' </summary>
Module Module1
    ''' <summary>
    ''' The following code example groups a list of customers based on their location 
    ''' (country/region) and provides a count of the customers in each group. The results are ordered 
    ''' by country/region name. The grouped results are ordered by city name.
    ''' </summary>
    Sub Main()
        Dim operations = New DataOperations
        Dim customers = operations.CustomerList()

        Dim customersByCountry = From customer In customers
                                 Order By customer.City
                                 Group By CountryName = customer.Country
                                 Into regionalCustomers = Group, Count()
                                 Order By CountryName

        For Each country In customersByCountry

            Console.WriteLine(country.CountryName & " (" & country.Count & ")" & vbCrLf)

            For Each customer In country.regionalCustomers
                Console.WriteLine($"{customer.CustomerIdentifier,5} {customer.CompanyName} ({customer.City})")
            Next
            Console.WriteLine()
        Next

        Console.ReadLine()

    End Sub

End Module
