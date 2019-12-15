Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Namespace Models

    Partial Public Class Category
        Public Sub New()
            Products = New HashSet(Of Product)()
        End Sub

        Public Property CategoryID As Integer

        <Required>
        <StringLength(15)>
        Public Property CategoryName As String
        Public Property Description As String

        Public Overridable Property Products As ICollection(Of Product)
    End Class
End Namespace