Imports System.Text
Imports CategoryProductEntitiesLibrary.ContainerClasses
Imports CategoryProductEntitiesLibrary.Models
Imports CategoryProductEntitiesLibrary.Samples

Public Class Form1
    Private operations As New ProductsCategory
    Private Sub ProductCatagoryGroupSortButton_Click(sender As Object, e As EventArgs) Handles ProductCatagoryGroupSortButton.Click

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
    Private Sub GroupProductByCategoryButton_Click(sender As Object, e As EventArgs) Handles GroupProductByCategoryButton.Click

        ListView1.Items.Clear()

        Dim results As List(Of ProductByCategory) = operations.GroupProductByCategory()

        For Each group As ProductByCategory In results
            ListView1.Items.Add(New ListViewItem(group.Category.CategoryName))
            For Each product As Product In group.GroupCategoryProducts
                ListView1.Items.Add(New ListViewItem(New String() {"", product.ProductName}))
            Next
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
End Class
