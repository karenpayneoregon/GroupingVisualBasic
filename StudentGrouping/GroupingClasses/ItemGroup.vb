Imports PersonLibrary.Classes

Namespace GroupingClasses

    Public Class ItemGroup
        Public Property LastName() As String
        Public Property Students() As IEnumerable(Of Student)

        Public Sub New()
            Students = New List(Of Student)()
        End Sub
    End Class
End Namespace