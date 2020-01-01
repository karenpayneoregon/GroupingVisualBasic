Namespace Classes
    Public Class ProductComparer
        Implements IEqualityComparer(Of Product)

        Public Function Equals(x As Product, y As Product) As Boolean Implements IEqualityComparer(Of Product).Equals
            If Object.ReferenceEquals(x, y) Then
                Return True
            End If

            If Object.ReferenceEquals(x, Nothing) OrElse Object.ReferenceEquals(y, Nothing) Then
                Return False
            End If

            Return x.Make = y.Make AndAlso x.Model = y.Model
        End Function
        Public Function GetHashCode(product As Product) As Integer Implements IEqualityComparer(Of Product).GetHashCode
            If Object.ReferenceEquals(product, Nothing) Then
                Return 0
            End If
            Dim hashProductName As Integer = If(product.Make Is Nothing, 0, product.Make.GetHashCode())
            Dim hashProductCode As Integer = product.Model.GetHashCode()
            Return hashProductName Xor hashProductCode
        End Function
    End Class
End Namespace