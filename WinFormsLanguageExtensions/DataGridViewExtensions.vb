Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Public Module DataGridViewExtensions
    ''' <summary>
    ''' Cast DataGridView DataSource to a DataTable
    ''' </summary>
    ''' <param name="sender">DataGridView</param>
    ''' <returns>DataTable or throws an exception if DataSource is not a DataTable</returns>
    <Extension>
    Public Function DataTable(sender As DataGridView) As DataTable
        Return CType(sender.DataSource, DataTable)
    End Function
    <Extension()>
    Public Sub ExpandColumns(sender As DataGridView)
        For Each col As DataGridViewColumn In sender.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
    End Sub
    ''' <summary>
    ''' Write entire contents, rows and cells to a tex file
    ''' </summary>
    ''' <param name="sender">DataGridView with rows and columns</param>
    ''' <param name="FileName">Path and file name to write too</param>
    ''' <param name="defaultNullValue">Default value for null or empty cells</param>
    <Extension>
    Public Sub ExportRows(
        sender As DataGridView,
        FileName As String,
        Optional ByVal defaultNullValue As String = "(empty)")

        File.WriteAllLines(FileName, (sender.Rows.Cast(Of DataGridViewRow)().
              Where(Function(row) Not row.IsNewRow).
              Select(Function(row) New With {
                        Key row, Key .rowItem = String.Join(",",
                               Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell)().ToArray(),
                                                Function(c) (If(c.Value Is Nothing, defaultNullValue, c.Value.ToString()))))}).
              Select(Function(row) row.rowItem)))
    End Sub
    <Extension>
    Public Sub CustomersExportRows(
                          sender As DataGridView,
                          FileName As String,
                          Optional ByVal defaultNullValue As String = "(empty)")

        File.WriteAllLines(FileName, (sender.Rows.Cast(Of DataGridViewRow)().
                              Where(Function(row) Not row.IsNewRow AndAlso CBool(row.Cells("Process").Value) = True).
                              Select(Function(row) New With {
                                        Key row, Key .rowItem = String.Join(",",
                                                Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell)().ToArray(),
                                                                 Function(c) (If(c.Value Is Nothing, defaultNullValue, c.Value.ToString()))))}).
                              Select(Function(row) row.rowItem)))
    End Sub
End Module
