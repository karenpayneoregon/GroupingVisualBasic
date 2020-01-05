Imports System.Linq.Expressions
Imports PersonEntitiesLibrary

Module Module1

    Sub Main()
        Console.ReadLine()
    End Sub
    ''' <summary>
    ''' Strong typed
    ''' </summary>
    Sub GroupByCity()
        Using context As New PeopleContext

            Dim personList = context.People.ToList()

            Dim groupResults As IEnumerable(Of PersonGroup) =
                    From person In personList
                    Group By personCity = person.City Into group = Group
                    Select New PersonGroup With {.City = personCity, .List = group.ToList()}


            For Each personGroup As PersonGroup In groupResults
                Console.WriteLine(personGroup.City)
                For Each person In personGroup.List
                    Console.WriteLine($"   {person}")
                Next
            Next

        End Using

    End Sub
    Sub GroupByCityCountry()
        Using context As New PeopleContext

            Dim personList = context.People.ToList()

            Dim groupResults As IEnumerable(Of PersonGroup) = personList.
                    GroupBy(Function(person) New With {Key person.City, Key person.Country}).
                    Select(Function(dataIGrouping) New PersonGroup With {
                              .PersonCount = dataIGrouping.Count(),
                              .City = dataIGrouping.Key.City,
                              .Country = dataIGrouping.Key.Country,
                              .List = dataIGrouping.ToList()
                              })



            For Each personGroup As PersonGroup In groupResults
                Console.WriteLine($"{personGroup.City} {personGroup.Country} ({personGroup.PersonCount})")
                For Each person As Person In personGroup.List
                    Console.WriteLine($"   {person}")
                Next
            Next

        End Using

    End Sub
    Sub MinMaxCount()
        Using context As New PeopleContext
            Dim people = context.People.ToList()
            Dim query = people.GroupBy(
                Function(person) Math.Floor(person.Age),
                Function(person) person.Age,
                Function(baseAge, ages) New With {
                                          .Key = baseAge,
                                          .Count = ages.Count(),
                                          .Min = ages.Min(),
                                          .Max = ages.Max()}
                )


            Dim output As New System.Text.StringBuilder
            ' Iterate over each anonymous type.
            For Each result In query
                output.AppendLine(vbCrLf & "Age group: " & result.Key)
                output.AppendLine("Number of people in this age group: " & result.Count)
                output.AppendLine("Minimum age: " & result.Min)
                output.AppendLine("Maximum age: " & result.Max)
            Next

            ' Display the output.
            Console.WriteLine(output.ToString)
        End Using

    End Sub
    ''' <summary>
    ''' This method groups by FirstName only
    ''' </summary>
    Sub GroupByFirstName()
        Using context As New PeopleContext

            Dim personList = context.People.ToList()
            Dim results = personList.GroupBy(
                Function(person)
                    Return New With {
                        Key .Age = person.Age, 
                        Key .Sex = person.Sex}
                End Function).
                    Select(Function(grouping) New With {
                              .Item = grouping.Key,
                              .PeopleList = grouping.ToList()
                              })


            Console.WriteLine("Group by age and sex anonymous result")
            Console.WriteLine()

            For Each groupTop In results
                Console.WriteLine($"Age {groupTop.Item.Age} Gender {groupTop.Item.Sex}")
                For Each person As Person In groupTop.PeopleList
                    Console.WriteLine($"   {person}")
                Next

                Console.WriteLine()

            Next
        End Using

    End Sub
End Module
