Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Person")>
Partial Public Class Person
    Public Property Id As Integer

    Public Property FirstName As String

    Public Property LastName As String

    <StringLength(1)>
    Public Property Sex As String

    Public Property BirthDate As Date?

    Public Property City As String

    Public Property Country As String
End Class
