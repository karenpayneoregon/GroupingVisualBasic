Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class PeopleContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=PeopleContext")
    End Sub

    Public Overridable Property People As DbSet(Of Person)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Person)() _
            .Property(Function(e) e.Sex) _
            .IsFixedLength()
    End Sub
End Class
