Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Data.Entity
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading.Tasks
Imports NorthWindEntityLibrary.Models
Imports NorthWindEntityLibrary.Classes

Public Module LanguageExtensions

    ''' <summary>
    ''' Get customer details without orders
    ''' </summary>
    ''' <param name="context"></param>
    ''' <returns></returns>
    <Extension>
    Public Function PartialCompleteCustomers(context As NorthWindContext) As IQueryable(Of Customer)
        Return context.Customers.Include(Function(customer) customer.Country).Include(Function(customer) customer.Contact).Include(Function(customer) customer.ContactType)
    End Function
    ''' <summary>
    ''' Get single customer by customer identifier and return customer data and order data
    ''' excluding complete order details.
    ''' </summary>
    ''' <param name="context"></param>
    ''' <param name="customerIdentifier"></param>
    ''' <returns></returns>
    <Extension>
    Public Function CustomerById(context As NorthWindContext, customerIdentifier As Integer) As Customer
        Return context.Customers.Include(Function(customer) customer.Country).
            Include(Function(customer) customer.Contact).
            Include(Function(customer) customer.ContactType).
            Include(Function(customer) customer.Orders).
            FirstOrDefault(Function(c) c.CustomerIdentifier = customerIdentifier)
    End Function
    <Extension>
    Public Function CustomerIncludes(context As NorthWindContext) As IQueryable(Of Customer)
        Return context.Customers.Include(Function(customer) customer.Country).
            Include(Function(customer) customer.Contact).
            Include(Function(customer) customer.ContactType).
            Include(Function(customer) customer.Orders)
    End Function

End Module
