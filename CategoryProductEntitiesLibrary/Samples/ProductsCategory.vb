Imports System.Text
Imports CategoryProductEntitiesLibrary.ContainerClasses
Namespace Samples
    Public Class ProductsCategory
        ''' <summary>
        ''' Groups the elements of a sequence according to a specified key selector
        ''' function (product.Category.CategoryName) and projects the elements (Products) for each group
        ''' by using a specified function.
        ''' </summary>
        ''' <remarks>
        ''' - See article for importance of understanding IGrouping
        ''' - Must have the IDE output window open to view results
        ''' </remarks>
        Public Function GroupProductSortCategoryDescending() As List(Of GroupSortProduct)
            Dim results As IOrderedQueryable(Of GroupSortProduct)

            Using context As New ProductContext
                '
                ' Here we are grouping by CategoryName under Products
                ' then creating a strong type for the select and within the select
                ' sorting the products by product name followed
                ' by sorting category, the key for the group in descending order.
                '
                results =
                        context.Products.GroupBy(Function(product) product.Category.CategoryName).
                        Select(Function(group) New GroupSortProduct With {
                                  .CategoryName = group.Key,
                                  .Products = group.OrderBy(Function(prod) prod.ProductName)
                                  }).
                        OrderByDescending(Function(group) group.CategoryName)

                Return results.ToList()

            End Using
        End Function
        ''' <summary>
        ''' This sample we are dealing with obtaining all products under a distinct category.
        ''' </summary>
        Public Function GroupProductByCategory() As List(Of ProductByCategory)

            Using context As New ProductContext

                Dim results As IQueryable(Of ProductByCategory) =
                        context.Products.GroupBy(Function(prod) prod.Category).
                        Select(Function(group) New ProductByCategory With {
                                 .Category = group.Key,
                                 .GroupCategoryProducts = group
                             })


                Return results.ToList()

            End Using

        End Function

    End Class
End Namespace