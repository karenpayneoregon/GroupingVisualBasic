Imports System.Data.SqlClient
Imports BaseConnectionLibrary.ConnectionClasses
Imports SqlServerHelpers.Classes
Imports SqlServerHelpers.Extensions

''' <summary>
''' Retrieve column descriptions for SQL-Server database table
''' </summary>
Public Class ColumnDescriptions
    Inherits SqlServerConnection

    Public Sub New()
        DatabaseServer = "KARENS-PC"
        DefaultCatalog = "Example"
    End Sub

    ''' <summary>
    ''' Get column details, specifically
    ''' - Description for each column
    '''   - Determine if there actually is a description
    '''   - If there is a description it will be used in the header of a DataGridView
    '''   - If no description the column will be hidden in the DataGridView
    ''' </summary>
    ''' <param name="pTableName"></param>
    ''' <returns></returns>
    Public Function ColumnDetails(pTableName As String) As List(Of DescriptionColumn)

        mHasException = False

        Dim columnData = New List(Of DescriptionColumn)
        Dim selectStatement =
                <SQL>
                    SELECT COLUMN_NAME AS ColumnName ,
                           ORDINAL_POSITION AS Postion ,
                           prop.value AS [Description]
                    FROM   INFORMATION_SCHEMA.TABLES AS tbl
                           INNER JOIN INFORMATION_SCHEMA.COLUMNS AS col ON col.TABLE_NAME = tbl.TABLE_NAME
                           INNER JOIN sys.columns AS sc ON sc.object_id = OBJECT_ID(
                                                                              tbl.TABLE_SCHEMA
                                                                              + '.'
                                                                              + tbl.TABLE_NAME)
                                                           AND sc.name = col.COLUMN_NAME
                           LEFT JOIN sys.extended_properties prop ON prop.major_id = sc.object_id
                                                                     AND prop.minor_id = sc.column_id
                                                                     AND prop.name = 'MS_Description'
                    WHERE  tbl.TABLE_NAME = @TableName
                    ORDER BY col.ORDINAL_POSITION;
                </SQL>.Value

        Try

            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn}

                    cmd.CommandText = selectStatement
                    cmd.Parameters.AddWithValue("@TableName", pTableName)

                    cn.Open()

                    Dim reader = cmd.ExecuteReader()

                    While reader.Read()
                        columnData.Add(New DescriptionColumn() With
                                          {
                                              .Name = reader.GetString(0),
                                              .Ordinal = reader.GetInt32(1),
                                              .Description = reader.GetStringSafe("Description")
                                          })
                    End While

                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return columnData

    End Function
End Class
