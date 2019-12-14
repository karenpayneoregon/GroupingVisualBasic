Imports SqlServerDuplicates
Imports SqlServerDuplicates.Classes
Imports SqlServerHelpers
Imports SqlServerHelpers.Classes
Imports WinFormsLanguageExtensions

Public Class Form1
    ''' <summary>
    ''' Contains code logic to find duplicate records
    ''' </summary>
    Private ReadOnly DuplicateFinder As New DuplicateFinder
    ''' <summary>
    ''' Load Customer table in both a DataTable and a List(Of Customers)
    ''' showing duplicate rows using a group by LINQ statements
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CustomerListDataGridView.DataSource = DuplicateFinder.GetCustomerDuplicatesAsList

        Dim descriptions As New ColumnDescriptions
        Dim descriptionResults = descriptions.ColumnDetails("Customers1")
        For Each dataColumn As DescriptionColumn In descriptionResults
            CustomerListDataGridView.Columns(dataColumn.Name).HeaderText = dataColumn.Description
        Next

        CustomerListDataGridView.ExpandColumns()

        DataTableDataGridView.DataSource = DuplicateFinder.GetCustomerDuplicatesAsDataTable
        For Each dataColumn As DescriptionColumn In descriptionResults
            DataTableDataGridView.Columns(dataColumn.Name).HeaderText = dataColumn.Description
        Next

        DataTableDataGridView.DataTable().Columns.Add(New DataColumn() With {
             .ColumnName = "Process",
             .DataType = GetType(Boolean),
             .DefaultValue = False
         })

        DataTableDataGridView.Columns("Process").DisplayIndex = 0
        DataTableDataGridView.ExpandColumns()

    End Sub
    ''' <summary>
    ''' Only permit the first column, process column to be edited/checked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) _
        Handles CustomerListDataGridView.CellBeginEdit, DataTableDataGridView.CellBeginEdit

        If CType(sender, DataGridView).Columns(e.ColumnIndex).Name <> "Process" Then
            e.Cancel = True
        End If

    End Sub
    ''' <summary>
    ''' Quick and dirty export of checked rows
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataTableCheckedButton_Click(sender As Object, e As EventArgs) Handles DataTableCheckedButton.Click
        DataTableDataGridView.CustomersExportRows("CustomersFromDataTable.txt")
    End Sub
    ''' <summary>
    ''' Quick and dirty export of checked rows
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ListCheckedButton_Click(sender As Object, e As EventArgs) Handles ListCheckedButton.Click
        CustomerListDataGridView.CustomersExportRows("CustomersFromList.txt")
    End Sub
    Private Sub ExitApplicationButton_Click(sender As Object, e As EventArgs) Handles ExitApplicationButton.Click
        Close()
    End Sub
End Class
