Namespace Classes
    Public Class Employees
        Public Shared Function List() As List(Of Employee)
            Dim employeeList As New List(Of Employee)

            employeeList.Add(New Employee With {.Id = "1", .FirstName = "Jerry", .LastName = "Foster", .Department = "Administrative"})
            employeeList.Add(New Employee With {.Id = "2", .FirstName = "Chris", .LastName = "Scott", .Department = "Sales"})
            employeeList.Add(New Employee With {.Id = "3", .FirstName = "Jason", .LastName = "Wong", .Department = "Sales"})
            employeeList.Add(New Employee With {.Id = "4", .FirstName = "James", .LastName = "Lang", .Department = "Administrative"})
            employeeList.Add(New Employee With {.Id = "5", .FirstName = "Edward", .LastName = "Lee", .Department = "Sales"})
            employeeList.Add(New Employee With {.Id = "6", .FirstName = "Mary", .LastName = "Smith", .Department = "Registration"})

            Return employeeList

        End Function

    End Class
End Namespace