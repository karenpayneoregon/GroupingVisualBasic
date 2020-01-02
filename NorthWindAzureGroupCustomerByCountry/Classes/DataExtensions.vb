Imports System.Runtime.CompilerServices

Namespace Classes
    Public Module DataExtensions
        <Extension>
        Public Function Values(sender As DataRow) As String
            Return String.Join(",", sender.ItemArray)
        End Function
    End Module
End NameSpace