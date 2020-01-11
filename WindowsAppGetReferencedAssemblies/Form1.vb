Imports System.Reflection
Imports System.Text

Public Class Form1
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim sb As New StringBuilder

        Dim groups = Assembly.
                GetExecutingAssembly().
                GetReferencedAssemblies().
                Select(Function(assembleName) Assembly.Load(assembleName)).
                SelectMany(Function(asm) asm.GetExportedTypes()).
                GroupBy(Function(t) t.Namespace).
                OrderByDescending(Function(g) g.Count()).Take(10)

        For Each group In groups
            sb.AppendLine($"{group.Key} ({group.Count()})")
            For Each type In group
                sb.AppendLine(vbTab & type.Name)
            Next
        Next

        TextBox1.Text = sb.ToString()
    End Sub
End Class
Public Class DataOperations
    Inherits BaseConnectionLibrary.ConnectionClasses.SqlServerConnection

End Class
