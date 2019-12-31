Namespace Classes
    Public Class Students
        Public Shared Function List() As List(Of Student)
            Dim studentList As New List(Of Student)

            studentList.Add(New Student() With {.FirstName = "Mary", .LastName = "Lee", .Year = 2019})
            studentList.Add(New Student() With {.FirstName = "Jerry", .LastName = "Foster", .Year = 2019})
            studentList.Add(New Student() With {.FirstName = "Chris", .LastName = "Scott", .Year = 2020})
            studentList.Add(New Student() With {.FirstName = "Jason", .LastName = "Wong", .Year = 2019})
            studentList.Add(New Student() With {.FirstName = "James", .LastName = "Lang", .Year = 2020})
            studentList.Add(New Student() With {.FirstName = "Ming", .LastName = "Lee", .Year = 2019})
            studentList.Add(New Student() With {.FirstName = "Karen", .LastName = "Scott", .Year = 2020})
            studentList.Add(New Student() With {.FirstName = "Edward", .LastName = "Lee", .Year = 2019})
            studentList.Add(New Student() With {.FirstName = "Mary", .LastName = "Smith", .Year = 2019})

            Return studentList

        End Function
    End Class
End Namespace