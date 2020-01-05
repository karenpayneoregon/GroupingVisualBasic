﻿Imports System.Data.Entity
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
    Public Function GroupJoinCustomersWithCompanyNameStartsWith(
        context As NorthWindContext,
        startsWithValue As String) As List(Of CustomerOrder)

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
End Class