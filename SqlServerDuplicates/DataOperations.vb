Imports System.Data.SqlClient
Imports BaseConnectionLibrary.ConnectionClasses

Public Class DataOperations
    Inherits SqlServerConnection

    Public Sub New()
        DatabaseServer = "KARENS-PC"
        DefaultCatalog = "Example"
    End Sub
    ''' <summary>
    ''' Return all records from Example.Customers table
    ''' </summary>
    ''' <returns></returns>
    Public Function ReadCustomersFromDatabase() As DataTable
        Dim customerDataTable As New DataTable

        Using cn = New SqlConnection() With {.ConnectionString = ConnectionString}

            Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = CustomerSelectStatement()}

                cn.Open()

                customerDataTable.Load(cmd.ExecuteReader())

            End Using

        End Using

        Return customerDataTable

    End Function
    ''' <summary>
    ''' SQL SELECT for retrieving all Customers using xml literal statement
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' By first writing SQL in SSMS (SQL-Server Management Studio) to ensure
    ''' the SQL functions, format in SSMS so the query is easy to read without
    ''' any need to use a string makes things easier especially with a long SQL
    ''' statement. Be consistent.
    ''' </remarks>
    Private Function CustomerSelectStatement() As String

        Return <SQL>
                SELECT Identifier, 
                    CompanyName, 
                    ContactName, 
                    ContactTitle, 
                    [Address], 
                    City, 
                    PostalCode
                FROM Customers1;
            </SQL>.Value

    End Function
End Class
