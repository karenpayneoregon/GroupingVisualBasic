Imports System.Data.Entity
Imports System.Data.Entity.Core.Metadata.Edm
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports NorthWindEntityLibrary.Classes

Public Class NorthOperations
    ''' <summary>
    ''' Example of a GroupJoin on customers/order where customer name begins with
    ''' a single character specified in firstCharacter parameter
    ''' </summary>
    ''' <param name="context">Active NorthWindContext context</param>
    ''' <param name="startsWithValue"></param>
    ''' <returns>List(Of CustomerOrder)</returns>
    Public Function GroupJoinCustomersWithCompanyNameStartsWith(context As NorthWindContext, startsWithValue As String) As List(Of CustomerOrder)

        context.Configuration.LazyLoadingEnabled = True

        '
        ' Note to use Include the following Import is needed
        '   Imports System.Data.Entity 
        '
        Dim results As List(Of CustomerOrder) = context.CustomerIncludes().
                Where(Function(customer) customer.CompanyName.StartsWith(startsWithValue)).
                GroupJoin(context.Orders, Function(c) c.CustomerIdentifier,
                          Function(order) order.CustomerIdentifier,
                          Function(customer, order) New With {
                             Key .Customer = customer,
                             Key .Order = order}).
                Select(Function(customerData) New CustomerOrder With {
                          .Customer = customerData.Customer,
                          .Order = customerData.Order}).
                ToList()

        Return results

    End Function
    ''' <summary>
    ''' Get average order count for all cities
    ''' </summary>
    ''' <param name="context">NorthWindContext in using statement</param>
    ''' <remarks>
    ''' Modified from Microsoft code sample
    ''' https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/linq/how-to-count-sum-or-average-data-by-using-linq
    ''' </remarks>
    Public Sub AverageCustomersByCity(context As NorthWindContext)

        Dim averageCustomersByCity = From customer In context.Customers
                                     Group By customer.City
                                     Into Average(customer.Orders.Count)
                                     Order By Average

        ' create a result set that can be used in the caller
        ' where the caller must use .ToList or First etc to execute
        Dim results As IQueryable(Of CityAverage) =
                averageCustomersByCity.Select(
                    Function(item) New CityAverage With {
                                                 .City = item.City,
                                                 .Average = item.Average
                                                 })


    End Sub
    ''' <summary>
    ''' Example for max orders by county with three versions
    ''' </summary>
    ''' <param name="context"></param>
    ''' <remarks>
    ''' Modified from Microsoft code sample
    ''' https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/linq/how-to-find-the-minimum-or-maximum-value-in-a-query-result
    ''' </remarks>
    Public Sub MaxOrdersByCountry(context As NorthWindContext)

        '
        ' This attempt brings across too much information e.g. the entire Country data
        '
        Dim maximumOrdersByCountry =
                From customer In context.Customers
                Group By customer.Country
                Into MaxOrders = Max(customer.Orders.Count)

        Dim results = maximumOrdersByCountry.ToList()

        For Each item In results
            Console.WriteLine($"{item.Country.Name} - {item.MaxOrders}")
        Next


        '
        ' This attempt does not bring country data, results are anonymous 
        '
        Dim maximumOrdersByCountry1 =
                From customer In context.Customers
                Group customer By customer.Country Into grouping = Group
                Select
                    Country.Name,
                    MaxOrders = grouping.Max(Function(x) x.Orders.Count)


        Dim results1 = maximumOrdersByCountry1.ToList()

        '
        ' Final attempt is strong typed
        '
        Dim maximumOrdersByCountry3 =
                From customer In context.Customers
                Group customer By customer.Country Into grouping = Group
                Select New CustomerMaxOrder With {
                    .Country = Country.Name,
                    .MaxOrders = grouping.Max(Function(x) x.Orders.Count)
                }

        Dim results3 As List(Of CustomerMaxOrder) = maximumOrdersByCountry3.ToList()
        Console.WriteLine()

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="north"></param>
    Public Sub ThreeTablesGrouping(north As NorthWindContext)

        Dim query = From order In north.Orders
                    From customer In north.Customers.
                        Where(Function(customer) CBool(customer.CustomerIdentifier = order.CustomerIdentifier)).DefaultIfEmpty()
                    From orderDetail In north.OrderDetails.Where(Function(d) d.OrderID = order.OrderID).DefaultIfEmpty()
                    Group New With {
                    Key .order = order,
                    Key .customer = customer,
                    Key .details = orderDetail
                    } By GroupKey = New With {Key order.OrderDate.Value.Year, Key customer.CompanyName
                    } Into group = Group
                    Select New With {
                        Key .Company = GroupKey.CompanyName,
                        Key .OrderYear = GroupKey.Year,
                        Key .Amount = group.Sum(Function(order) order.details.UnitPrice * order.details.Quantity)
                    }

        Dim queryResults = query.ToList()
        Console.WriteLine()

    End Sub

End Class