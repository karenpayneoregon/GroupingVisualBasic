Namespace Classes
    Public Class People
        Public Shared Function List() As List(Of Person)
            Dim personList = New List(Of Person)

            personList.Add(New Person() With {.Id = 1, .FirstName = "Jim", .LastName = "Gallagher", .City = "Wyndmoor", .Country = "USA"})
            personList.Add(New Person() With {.Id = 2, .FirstName = "Rebecca", .LastName = "Adams", .City = "Chestnut hill", .Country = "USA"})
            personList.Add(New Person() With {.Id = 3, .FirstName = "Mary", .LastName = "Gallagher", .City = "Wyndmoor", .Country = "USA"})
            personList.Add(New Person() With {.Id = 3, .FirstName = "Mary", .LastName = "Gallagher", .City = "Philadelphia", .Country = "USA"})

            Return personList

        End Function
    End Class
End NameSpace