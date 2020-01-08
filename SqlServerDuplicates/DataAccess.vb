Imports System.Data.OleDb
Imports System.IO


Public Class DataAccess

    Private ReadOnly Builder As New OleDbConnectionStringBuilder With
        {
            .Provider = "Microsoft.ACE.OLEDB.12.0",
            .DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
        }
    Public Sub New()

        _AllCustomersDataTable = New DataTable
        _DuplicatesCustomersDataTableFromDatabase = New DataTable
        GetAllCustomerRows()
        GetOnlyDuplicatesFromDatabase()

    End Sub

    Private _AllCustomersDataTable As DataTable
    Public ReadOnly Property AllCustomersDataDataTable As DataTable
        Get
            Return _AllCustomersDataTable
        End Get
    End Property
    ''' <summary>
    ''' Get all rows including duplicates
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetAllCustomerRows()
        Using cn As New OleDbConnection With
                {
                    .ConnectionString = Builder.ConnectionString
                }

            Using cmd As New OleDbCommand With {.Connection = cn}

                cmd.CommandText =
                    <SQL>
                        SELECT Identifier, 
                            CompanyName, 
                            ContactName, 
                            ContactTitle, 
                            Address, 
                            City, 
                            PostalCode
                        FROM Customers;

                    </SQL>.Value

                cn.Open()
                _AllCustomersDataTable.Load(cmd.ExecuteReader)

            End Using
        End Using
    End Sub
    Private _DuplicatesCustomersDataTableFromDatabase As DataTable
    Public ReadOnly Property DuplicatesDataDataTable As DataTable
        Get
            Return _DuplicatesCustomersDataTableFromDatabase
        End Get
    End Property
    ''' <summary>
    ''' Get only duplicates
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetOnlyDuplicatesFromDatabase()
        Using cn As New OleDbConnection With
                {
                    .ConnectionString = Builder.ConnectionString
                }


            Using cmd As New OleDbCommand With {.Connection = cn}

                cmd.CommandText =
                    <SQL>
                    SELECT A.*
                    FROM Customers A
                    INNER JOIN
                        (
                        SELECT 
                            CompanyName,
                            ContactName,
                            ContactTitle,
                            Address,
                            City,
                            PostalCode
                        FROM 
                            Customers
                        GROUP BY 
                            CompanyName,
                            ContactName,
                            ContactTitle,
                            Address,
                            City,
                            PostalCode
                        HAVING COUNT(*) > 1
                        ) B
                    ON
                    A.CompanyName = B.CompanyName AND
                    A.ContactName = B.ContactName AND
                    A.ContactTitle = B.ContactTitle AND
                    A.Address = B.Address AND
                    A.City = B.City AND
                    A.PostalCode = B.PostalCode
                    ORDER BY 
                        A.CompanyName
                    </SQL>.Value


                Try

                    cn.Open()

                    _DuplicatesCustomersDataTableFromDatabase.Load(cmd.ExecuteReader)
                Catch ex As Exception
                    Console.WriteLine()
                End Try


            End Using
        End Using
    End Sub

End Class
