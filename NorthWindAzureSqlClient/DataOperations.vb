Imports System.Data.SqlClient
Imports BaseConnectionLibrary.ConnectionClasses

Public Class DataOperations
    Inherits SqlServerConnection

    Public Sub New()
        DefaultCatalog = "NorthWindAzure"
        DatabaseServer = "KARENS-PC"
    End Sub
    Public Function CustomerList() As List(Of Customer)
        Dim customersList As New List(Of Customer)

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}

            Using cmd As New SqlCommand With {.Connection = cn}

                cmd.CommandText =
                    "SELECT Cust.CustomerIdentifier , Cust.CompanyName , Cust.ContactName , Cust.Country , Cust.City " &
                    "FROM dbo.Customers AS Cust"

                cn.Open()
                Dim reader = cmd.ExecuteReader()

                While reader.Read()
                    customersList.Add(New Customer() With {
                                         .CustomerIdentifier = reader.GetInt32(0),
                                         .CompanyName = reader.GetString(1),
                                         .ContactName = reader.GetString(2),
                                         .Country = reader.GetString(3),
                                         .City = reader.GetString(4)
                                         })
                End While

            End Using
        End Using


        Return customersList

    End Function
    Public Function CustomerDataTable() As DataTable
        Dim customerTable As New DataTable

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}

            Using cmd As New SqlCommand With {.Connection = cn}

                cmd.CommandText =
                    "SELECT Cust.CustomerIdentifier , Cust.CompanyName , Cust.ContactName , Cust.Country , Cust.City " &
                    "FROM dbo.Customers AS Cust"

                cn.Open()

                customerTable.Load(cmd.ExecuteReader())

            End Using
        End Using

        Return customerTable

    End Function
End Class
