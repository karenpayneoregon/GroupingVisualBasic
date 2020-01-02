Imports NorthWindAzureGroupCustomerByCountry.Classes
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

    Sub Main()

        AnonymousVersion()
        Console.ReadLine()

    End Sub
    ''' <summary>
    ''' The following code example groups a list of customers based on their location 
    ''' (country/region) and provides a count of the customers in each group. The results are ordered 
    ''' by country/region name. The grouped results are ordered by city name.
    ''' </summary>
    Private Sub AnonymousVersion()
        Dim operations = New DataOperations
        Dim customers = operations.CustomerList()

        Dim customersByCountry = From customer In customers
                                 Order By customer.City
                                 Group By CountryName = customer.Country Into regionalCustomers = Group, Count()
                                 Order By CountryName

        For Each country In customersByCountry

            Console.WriteLine($"{country.CountryName} ({country.Count})")

            For Each customer In country.regionalCustomers
                Console.WriteLine($"{customer.CustomerIdentifier,5} {customer.CompanyName} ({customer.City})")
            Next

            Console.WriteLine()

        Next

    End Sub
    Private Sub CustomersDataTableGrouping()
        Dim operations = New DataOperations
        Dim customers = operations.CustomerDataTable()

        Dim baseQuery =
                From customer In customers.AsEnumerable()
                Order By customer.Field(Of String)("City")
                Group By CountryName = customer.Field(Of String)("Country") Into regionalCustomers = Group, Count()
                Order By CountryName


        For Each country In baseQuery

            Console.WriteLine($"{country.CountryName} ({country.Count})")

            For Each customer In country.regionalCustomers

                Console.WriteLine($"{customer.Field(Of Integer)("CustomerIdentifier"),5} " &
                                  $"{customer.Field(Of String)("CompanyName")} " &
                                  $"({customer.Field(Of String)("City")})")
            Next

        Next

        Console.WriteLine()
        Console.WriteLine("DataTable")
        Console.WriteLine()

        Dim customersByCountry =
                baseQuery.Select(Function(customer) New CountryCompanyDataTableContainer With {
                                    .CountryName = customer.CountryName,
                                    .Customers = customer.regionalCustomers,
                                    .Count = customer.regionalCustomers.Count()
                                    })


        For Each container As CountryCompanyDataTableContainer In customersByCountry
            Console.WriteLine($"{container.CountryName} ({container.Count})")
            For Each dataRow As DataRow In container.Customers
                Console.WriteLine($"     {dataRow.Values()}")
            Next
        Next

    End Sub

    Sub AnonymousToStrongTypedVersion()
        Dim operations = New DataOperations
        Dim customers = operations.CustomerList()

        Dim baseQuery =
                From customer In customers Order By customer.City
                Group By CountryName = customer.Country Into regionalCustomers = Group
                Order By CountryName

        Dim customersByCountry As IEnumerable(Of CountryCompanyContainer) =
                baseQuery.Select(Function(customer) New CountryCompanyContainer With {
                                    .CountryName = customer.CountryName,
                                    .Customers = customer.regionalCustomers,
                                    .Count = customer.regionalCustomers.Count()
                                    })

        For Each TopGroup In customersByCountry
            Console.WriteLine($"{TopGroup.CountryName} ({TopGroup.Count})")
            For Each innerGroup In TopGroup.Customers
                Console.WriteLine($"{innerGroup.CustomerIdentifier,5} {innerGroup.CompanyName} ({innerGroup.City})")
            Next
        Next


    End Sub
    ''' <summary>
    ''' Given code from AnonymousToStrongTypedVersion procedure
    ''' above the base query is now simply the starting point
    ''' </summary>
    Sub AnonymousToStrongTypedVersionToMuch()
        Dim operations = New DataOperations
        Dim customers = operations.CustomerList()


        Dim customersByCountry =
                (
                    From customer In customers
                    Order By customer.City
                    Group By CountryName = customer.Country Into regionalCustomers = Group
                    Order By CountryName).Select(Function(customer) New CountryCompanyContainer With {
                                                    .CountryName = customer.CountryName,
                                                    .Customers = customer.regionalCustomers,
                                                    .Count = customer.regionalCustomers.Count()
                    }
                )

        For Each TopGroup In customersByCountry

            Console.WriteLine($"{TopGroup.CountryName} ({TopGroup.Count})")

            For Each innerGroup In TopGroup.Customers
                Console.WriteLine($"{innerGroup.CustomerIdentifier,5} {innerGroup.CompanyName} ({innerGroup.City})")
            Next

        Next


    End Sub
End Module
