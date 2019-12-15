Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq
Imports CategoryProductEntitiesLibrary.Models

Partial Public Class ProductContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=CatProdModel")
    End Sub

    Public Overridable Property Categories As DbSet(Of Category)
    Public Overridable Property Products As DbSet(Of Product)
    Public Overridable Property Shippers As DbSet(Of Shipper)
    Public Overridable Property Suppliers As DbSet(Of Supplier)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Product)().Property(Function(e) e.UnitPrice).HasPrecision(19, 4)
    End Sub
End Class
