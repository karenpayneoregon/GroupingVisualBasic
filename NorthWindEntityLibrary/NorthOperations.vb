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
    ''' <param name="context"></param>
    ''' <param name="firstCharacter"></param>
    ''' <returns>List(Of CustomerOrder)</returns>
    Public Function GroupJoinCustomersWithCompanyNameStartsWith(
        context As NorthWindContext,
        firstCharacter As String) As List(Of CustomerOrder)

        context.Configuration.LazyLoadingEnabled = True


        Dim source As List(Of CustomerOrder) = context.Customers.
                Include(Function(customer) customer.Contact).
                Include(Function(customer) customer.Contact).
                Where(Function(customer) customer.CompanyName.StartsWith(firstCharacter)).
                GroupJoin(context.Orders, Function(c) c.CustomerIdentifier,
                          Function(order) order.CustomerIdentifier,
                          Function(customer, order) New With {
                             Key .Customer = customer,
                             Key .Order = order}).
                Select(Function(customerData) New CustomerOrder With {
                          .Customer = customerData.Customer,
                          .Order = customerData.Order}).
                ToList()

        Return source


    End Function
End Class