Namespace Classes
    Public Class People
        Public Shared Function List() As List(Of Person)
            Dim personList = New List(Of Person)

            personList.Add(New Person() With {.Id = 1, .FirstName = "Jim", .LastName = "Gallagher", .City = "Wyndmoor", .Country = "USA"})
            personList.Add(New Person() With {.Id = 2, .FirstName = "Rebecca", .LastName = "Adams", .City = "Chestnut hill", .Country = "USA"})
            personList.Add(New Person() With {.Id = 3, .FirstName = "Mary", .LastName = "Gallagher", .City = "Wyndmoor", .Country = "USA"})
            personList.Add(New Person() With {.Id = 4, .FirstName = "Mary", .LastName = "Gallagher", .City = "Philadelphia", .Country = "USA"})

            Return personList

        End Function
        Public Shared Function List1() As List(Of Person)
            Dim personList = New List(Of Person)

            personList.Add(New Person() With {.Id = 1, .FirstName = "Jim", .LastName = "Smith", .BirthDate = #09/01/2000#, .Sex = "M"})
            personList.Add(New Person() With {.Id = 2, .FirstName = "Rebecca", .LastName = "Adams", .BirthDate = #05/01/1990#, .Sex = "F"})
            personList.Add(New Person() With {.Id = 3, .FirstName = "Mike", .LastName = "Jenkins", .BirthDate = #09/01/1990#, .Sex = "M"})
            personList.Add(New Person() With {.Id = 4, .FirstName = "Karen", .LastName = "Jones", .BirthDate = #09/01/1980#, .Sex = "F"})
            personList.Add(New Person() With {.Id = 5, .FirstName = "Jerry", .LastName = "Williams", .BirthDate = #09/01/2000#, .Sex = "M"})
            personList.Add(New Person() With {.Id = 6, .FirstName = "Lisa", .LastName = "Hallbrook", .BirthDate = #09/01/2000#, .Sex = "F"})
            personList.Add(New Person() With {.Id = 7, .FirstName = "Amy", .LastName = "White", .BirthDate = #12/01/2000#, .Sex = "F"})

            Return personList

        End Function
    End Class
End NameSpace