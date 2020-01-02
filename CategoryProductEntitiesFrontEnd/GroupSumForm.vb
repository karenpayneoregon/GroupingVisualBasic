Imports CategoryProductEntitiesLibrary.ContainerClasses

Public Class GroupSumForm
    Private _productsGroupedSummed As List(Of ProductsGroupedSummed)

    Public Sub New(productGroupSumList As List(Of ProductsGroupedSummed))

        InitializeComponent()

        _productsGroupedSummed = productGroupSumList

    End Sub

    Private Sub GroupSumForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item As ProductsGroupedSummed In _productsGroupedSummed

            ListView1.Items.Add(New ListViewItem(
                New String() {item.Category, item.TotalUnitsInStock.Value.ToString()}))

        Next
    End Sub
End Class