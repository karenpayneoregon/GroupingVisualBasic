Imports System.Runtime.CompilerServices

Namespace Extensions
    Public Module DataExtensions
        <Extension>
        Public Function GetStringSafe(Reader As IDataReader, Field As String) As String
            Return If(TypeOf Reader(Field) Is DBNull, Nothing, Reader(Field).ToString())
        End Function
        <Extension>
        Public Function GetInt32Safe(pReader As IDataReader, pField As String) As Integer
            Return pReader.GetInt32Safe(pField, 0)
        End Function
        <Extension>
        Public Function GetInt32Safe(Reader As IDataReader, Field As String, DefaultValue As Integer) As Integer

            Dim value = Reader(Field)
            Return If(TypeOf value Is Integer, CInt(Fix(value)), DefaultValue)

        End Function
        <Extension>
        Public Function GetDoubleSafe(pReader As IDataReader, pField As String) As Double
            Return pReader.GetDoubleSafe(pField, 0)
        End Function
        <Extension>
        Public Function GetDoubleSafe(Reader As IDataReader, Field As String, DefaultValue As Long) As Double

            Dim value = Reader(Field)
            Return If(TypeOf value Is Double, CDbl(value), DefaultValue)

        End Function

        <Extension>
        Public Function GetDateTimeSafe(Reader As IDataReader, Field As String) As Date

            Return Reader.GetDateTimeSafe(Field, Date.MinValue)

        End Function
        <Extension>
        Public Function GetDateTimeSafe(Reader As IDataReader, Field As String, DefaultValue As Date) As Date

            Dim value = Reader(Field)
            Return If(TypeOf value Is Date, CDate(value), DefaultValue)

        End Function

    End Module
End Namespace