Imports System.Text
Imports CategoryProductEntitiesLibrary.ContainerClasses
Imports CategoryProductEntitiesLibrary.Models
Imports CategoryProductEntitiesLibrary.Samples

Public Class Form1
    Private ReadOnly operations As New ProductsCategory
    Private Sub ProductCategoryGroupSortButton_Click(sender As Object, e As EventArgs) _
        Handles ProductCategoryGroupSortButton.Click

        ListView1.Items.Clear()

        Dim result As List(Of GroupSortProduct) = operations.GroupProductSortCategoryDescending()

        For Each group As GroupSortProduct In result
            ListView1.Items.Add(New ListViewItem(group.CategoryName))
            For Each product As Product In group.Products
                ListView1.Items.Add(New ListViewItem(New String() {"", product.ProductName}))
            Next
        Next

        TidyupListView()

    End Sub
    Private Async Sub GroupProductByCategoryButton_Click(sender As Object, e As EventArgs) _
        Handles GroupProductByCategoryButton.Click

        ListView1.Items.Clear()

        Dim productByCategories As List(Of ProductByCategory) = Await operations.GroupProductByCategoryTask()

        For Each group As ProductByCategory In productByCategories

            ListView1.Items.Add(New ListViewItem(group.Category.CategoryName))

            For Each product As Product In group.GroupCategoryProducts
                ListView1.Items.Add(New ListViewItem(New String() {"", product.ProductName}))
            Next

            Await Task.Delay(1)

        Next

        TidyupListView()

    End Sub
    Private Sub TidyupListView()
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ListView1.EndUpdate()

        ListView1.FocusedItem = ListView1.Items(0)
        ListView1.Items(0).Selected = True

        ActiveControl = ListView1

    End Sub
    ''' <summary>
    ''' Group products by category and sum total units in stock for each category
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GroupCategorySumUnitsInStockButton_Click(sender As Object, e As EventArgs) _
        Handles GroupCategorySumUnitsInStockButton.Click

        Dim results As List(Of ProductsGroupedSummed) = operations.ProductsGroupedSummed()
        Dim form As New GroupSumForm(results)
        form.ShowDialog()

    End Sub
End Class
