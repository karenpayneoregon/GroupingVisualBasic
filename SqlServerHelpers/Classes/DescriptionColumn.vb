Namespace Classes
    Public Class DescriptionColumn
        ''' <summary>
        ''' Name of column
        ''' </summary>
        ''' <returns></returns>
        Public Property Name() As String
        ''' <summary>
        ''' Ordinal position of column
        ''' </summary>
        ''' <returns></returns>
        Public Property Ordinal() As Integer
        ''' <summary>
        ''' Description of column
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' May be NULL
        ''' </remarks>
        Public Property Description() As String
        ''' <summary>
        ''' Determines if this column should be visible in the user interface.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Visible() As Boolean
            Get
                Return Description IsNot Nothing
            End Get
        End Property
    End Class
End Namespace