Imports NorthWindEntityLibrary
Imports NorthWindEntityLibrary.Classes
Imports NorthWindEntityLibrary.Models

Module Module1
    Private operation As New NorthOperations
    Sub Main()

        Dim standardColor = Console.ForegroundColor

        Using context = New NorthWindContext

            operation.ThreeTablesGrouping(context)


        End Using

        Console.ReadLine()

    End Sub
    Public Sub GroupJoinCustomersWithCompanyNameStartsWith()
        Dim standardColor = Console.ForegroundColor

        Using context = New NorthWindContext

            Dim results As List(Of CustomerOrder) =
                    operation.GroupJoinCustomersWithCompanyNameStartsWith(context, "A")

            For Each current As CustomerOrder In results

                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine($"{current.Customer.CompanyName} - {current.Customer.Contact.FullName}")
                Console.ForegroundColor = standardColor

                For Each order As Order In current.Order

                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine($"   {order.OrderID}, {order.OrderDate.Value.ToShortDateString()}")
                    Console.ForegroundColor = standardColor

                    For Each orderDetail As OrderDetail In order.OrderDetails
                        Console.WriteLine($"      {orderDetail.Product.ProductName}, {orderDetail.Quantity}")
                    Next
                Next

                Console.WriteLine()

            Next

        End Using

    End Sub

End Module
