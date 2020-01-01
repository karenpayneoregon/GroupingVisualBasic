Namespace Classes
    Public Class Students
        Public Shared Function List() As List(Of Student)
            Dim studentList As New List(Of Student)

            studentList.Add(New Student() With {.FirstName = "Mary", .LastName = "Lee", .Year = 2019, .ExamScores = New List(Of Integer) From {97, 72, 81, 60}})
            studentList.Add(New Student() With {.FirstName = "Jerry", .LastName = "Foster", .Year = 2019, .ExamScores = New List(Of Integer) From {75, 84, 91, 39}})
            studentList.Add(New Student() With {.FirstName = "Chris", .LastName = "Scott", .Year = 2020, .ExamScores = New List(Of Integer) From {88, 94, 65, 85}})
            studentList.Add(New Student() With {.FirstName = "Jason", .LastName = "Wong", .Year = 2019, .ExamScores = New List(Of Integer) From {97, 89, 85, 82}})
            studentList.Add(New Student() With {.FirstName = "James", .LastName = "Lang", .Year = 2020, .ExamScores = New List(Of Integer) From {35, 72, 91, 70}})
            studentList.Add(New Student() With {.FirstName = "Ming", .LastName = "Lee", .Year = 2019, .ExamScores = New List(Of Integer) From {55, 62, 95, 75}})
            studentList.Add(New Student() With {.FirstName = "Karen", .LastName = "Scott", .Year = 2020, .ExamScores = New List(Of Integer) From {45, 82, 81, 80}})
            studentList.Add(New Student() With {.FirstName = "Edward", .LastName = "Lee", .Year = 2019, .ExamScores = New List(Of Integer) From {55, 72, 81, 90}})
            studentList.Add(New Student() With {.FirstName = "Mary", .LastName = "Smith", .Year = 2019, .ExamScores = New List(Of Integer) From {75, 77, 91, 80}})

            Return studentList

        End Function
    End Class
End Namespace