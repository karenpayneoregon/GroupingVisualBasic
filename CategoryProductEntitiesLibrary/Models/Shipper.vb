Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Namespace Models

    Partial Public Class Shipper
        <Key>
        <Column(Order:=0)>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        Public Property ShipperID As Integer

        <Key>
        <Column(Order:=1)>
        <StringLength(40)>
        Public Property CompanyName As String

        <StringLength(24)>
        Public Property Phone As String
    End Class
End Namespace