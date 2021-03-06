Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Namespace Models

    Partial Public Class Order
        Public Sub New()
            OrderDetails = New HashSet(Of OrderDetail)()
        End Sub

        Public Property OrderID As Integer

        Public Property CustomerIdentifier As Integer?

        Public Property EmployeeID As Integer?

        Public Property OrderDate As Date?

        Public Property RequiredDate As Date?

        Public Property ShippedDate As Date?

        Public Property ShipVia As Integer?

        <Column(TypeName:="money")>
        Public Property Freight As Decimal?

        <StringLength(60)>
        Public Property ShipAddress As String

        <StringLength(15)>
        Public Property ShipCity As String

        <StringLength(15)>
        Public Property ShipRegion As String

        <StringLength(10)>
        Public Property ShipPostalCode As String

        <StringLength(15)>
        Public Property ShipCountry As String

        Public Overridable Property Customer As Customer

        Public Overridable Property Employee As Employee

        Public Overridable Property OrderDetails As ICollection(Of OrderDetail)

        Public Overridable Property Shipper As Shipper
    End Class
End Namespace