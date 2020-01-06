Imports System.Runtime.CompilerServices

Namespace Classes
    ''' <summary>
    ''' Given a Person class with City and Country, the task is to group by City
    ''' or group by City and Country with LINQ an Lambda examples.
    ''' </summary>
    Public Class PersonGroupByMultipleProperties

        Public Sub LinqGroupByCityGroupingAnonymous()

            Dim personList = People.List()

            Dim groupResults = From person In personList
                               Group By personCity = person.City Into group = Group
                               Select New PersonGroup With {.City = personCity, .List = group.ToList()}


            For Each personGroup As PersonGroup In groupResults
                Console.WriteLine(personGroup.City)
                For Each person In personGroup.List
                    Console.WriteLine($"   {person}")
                Next
            Next

            Console.WriteLine()

        End Sub
        Public Function LambdaGroupByCity() As List(Of PersonGroup)

            Dim personList = People.List()

            Dim groupResults As IEnumerable(Of PersonGroup) = personList.
                    GroupBy(Function(person) New With {Key person.City}).
                    Select(Function(dataIGrouping) New PersonGroup With {
                                  .PersonCount = dataIGrouping.Count(),
                                  .City = dataIGrouping.Key.City,
                                  .List = dataIGrouping.ToList()
                              })


            Return groupResults.ToList()

        End Function
        ''' <summary>
        ''' This method groups by two properties, City and Country into an anonymous type 
        ''' which is only available within this procedure
        ''' </summary>
        Public Sub LambdaGroupByCityCountryAnonymous()

            Dim personList = People.List()

            Dim groupResults = personList.
                    GroupBy(Function(person) New With {Key person.City, Key person.Country}).
                    Where(Function(grp) grp.Count() > 1).ToList()


            For Each grouping In groupResults

                Console.WriteLine($"{grouping.Key.City}, {grouping.Key.Country}")

                For Each anonymous As Person In grouping
                    Console.WriteLine($"    {anonymous.Id}  {anonymous.FirstName} {anonymous.LastName}")
                Next

            Next

        End Sub
        ''' <summary>
        ''' This method groups by two properties, City and Country into a strong type result
        ''' </summary>
        Public Function LambdaGroupByCityCountry() As List(Of PersonGroup)
            Dim personList = People.List()


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



            Return groupResults.ToList()

        End Function

        Public Sub ExampleGroupBy_Count_Min_Max()
            Dim personList = People.List1()

            Dim query = personList.GroupBy(
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
                output.AppendLine("Number of pets in this age group: " & result.Count)
                output.AppendLine("Minimum age: " & result.Min)
                output.AppendLine("Maximum age: " & result.Max)
            Next

            ' Display the output.
            Console.WriteLine(output.ToString)
        End Sub
        ''' <summary>
        ''' This method groups by two properties to a strong typed class definition
        ''' Where count on each group is more than one in the List.
        ''' </summary>
        ''' <returns></returns>
        Public Function LambdaGroupByCityCountryWithCountGreaterThan() As List(Of PersonGroup)
            Dim personList = People.List()

            Dim groupResults = personList.GroupBy(Function(person) New With {Key person.City, Key person.Country}).
                Where(Function(group) group.Count() > 1).
                Select(Function(group) New PersonGroup With {
                              .City = group.Key.City,
                              .Country = group.Key.Country,
                              .List = group.ToList()
                          }).ToList()

            Return groupResults

        End Function
        ''' <summary>
        ''' This method groups by FirstName only
        ''' </summary>
        ''' <returns></returns>
        Public Function LambdaGroupByFirstNameOnlyGreaterThan() As List(Of PersonGroup)
            Dim personList = People.List()

            Return personList.GroupBy(Function(person)
                                          Return New With {Key person.FirstName}
                                      End Function).Where(Function(group) group.Count() > 1).
                Select(Function(grp)
                           Return New PersonGroup With {.City = grp.Key.FirstName, .List = grp.ToList()}
                       End Function).ToList()


        End Function
        ''' <summary>
        ''' Group by age and sex as anonymous type, see Example4a for
        ''' strong typed results.
        ''' </summary>
        Public Sub LamdbaGroupByAgeAndSexAnonymous()
            Dim personList = People.List1()

            Dim results = personList.GroupBy(
                Function(person)
                    Return New With {
                    Key .Age = person.Age, Key .Sex = person.Sex}
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
            Next

        End Sub
        ''' <summary>
        ''' Strong typed version of Example4.
        ''' Note, Visual Studio may indicate that Key can be simplified, this is not
        ''' true, Key indicates which properties make up the group.
        ''' </summary>
        ''' <returns></returns>
        Public Function LamdbaGroupByAgeAndSex() As IEnumerable(Of PeopleGroupedByAgeGender)

            Dim personList = People.List1()

            Dim PeopleGroupedByAgeGender As IEnumerable(Of PeopleGroupedByAgeGender) = personList.
                    GroupBy(Function(person)
                                Return New With {Key .Age = person.Age, Key .Sex = person.Sex}
                            End Function).
                    Select(Function(grouping) New PeopleGroupedByAgeGender With {
                              .Age = grouping.Key.Age,
                              .Sex = grouping.Key.Sex,
                              .PeopleList = grouping.ToList()})


            Console.WriteLine("Group by age and sex strong typed")
            Console.WriteLine()


            For Each group As PeopleGroupedByAgeGender In PeopleGroupedByAgeGender
                Console.WriteLine($"Age {group.Age} Gender {group.Sex}")
                For Each person As Person In group.PeopleList
                    Console.WriteLine($"   {person}")
                Next

                Console.WriteLine()

            Next

            Return PeopleGroupedByAgeGender

        End Function
    End Class
End Namespace