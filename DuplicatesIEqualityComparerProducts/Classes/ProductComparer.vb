Namespace Classes
    ''' <summary>
    ''' Comparer on Make and Model properties
    ''' </summary>
    Public Class ProductComparer
        Implements IEqualityComparer(Of Product)

        Public Shadows Function Equals(p1 As Product, p2 As Product) As Boolean _
            Implements IEqualityComparer(Of Product).Equals

            If ReferenceEquals(p1, p2) Then
                Return True
            End If

            If ReferenceEquals(p1, Nothing) OrElse ReferenceEquals(p2, Nothing) Then
                Return False
            End If

            Return p1.Make = p2.Make AndAlso p1.Model = p2.Model

        End Function
        Public Shadows Function GetHashCode(product As Product) As Integer _
            Implements IEqualityComparer(Of Product).GetHashCode

            If ReferenceEquals(product, Nothing) Then
                Return 0
            End If

            Dim hashProductName As Integer = If(product.Make Is Nothing, 0, product.Make.GetHashCode())
            Dim hashProductCode As Integer = product.Model.GetHashCode()

            Return hashProductName Xor hashProductCode

        End Function
    End Class
End Namespace