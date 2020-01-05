Imports System.Runtime.CompilerServices

Namespace Classes
    ''' <summary>
    ''' Given a Person class with City and Country, the task is to group by City and Country.
    ''' </summary>
    Public Class PersonGroupByMultipleProperties
        ''' <summary>
        ''' This method groups by two properties into an anonymous type 
        ''' which is only available within this procedure
        ''' </summary>
        Public Sub Example1()

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
        Public Function Exampe1A() As List(Of PersonGroup)

            Dim personList = People.List()

            Dim groupResults1 As IEnumerable(Of PersonGroup) = personList.
                    GroupBy(Function(person) New With {Key person.City}).
                    Select(Function(dataIGrouping) New PersonGroup With {
                                  .PersonCount = dataIGrouping.Count(),
                                  .City = dataIGrouping.Key.City,
                                  .List = dataIGrouping.ToList()
                              })


            Dim groupResults2 As IEnumerable(Of PersonGroup) = personList.
                    GroupBy(Function(person) New With {Key person.City, Key person.Country}).
                    Select(Function(dataIGrouping) New PersonGroup With {
                              .PersonCount = dataIGrouping.Count(),
                              .City = dataIGrouping.Key.City,
                              .Country = dataIGrouping.Key.Country,
                              .List = dataIGrouping.ToList()
                    })



            For Each personGroup As PersonGroup In groupResults2
                Console.WriteLine($"{personGroup.City} {personGroup.Country} ({personGroup.PersonCount})")
                For Each person As Person In personGroup.List
                    Console.WriteLine($"   {person}")
                Next
            Next

            Dim x = groupResults1

            Return groupResults2.ToList()

        End Function
        Public Sub Example1SingleGrouping_A()

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
        ''' </summary>
        ''' <returns></returns>
        Public Function Example2() As List(Of PersonGroup)
            Dim personList = People.List()

            Dim groupResults = personList.GroupBy(Function(person) New With {Key person.City, Key person.Country}).
                Where(Function(grp) grp.Count() > 1).
                Select(Function(grp) New PersonGroup With {
                          .City = grp.Key.City,
                          .Country = grp.Key.Country, .List = grp.ToList()
                          }).ToList()

            Return groupResults

        End Function
        ''' <summary>
        ''' This method groups by FirstName only
        ''' </summary>
        ''' <returns></returns>
        Public Function Example3() As List(Of PersonGroup)
            Dim personList = People.List()

            Return personList.GroupBy(Function(person)
                                          Return New With {Key person.FirstName}
                                      End Function).Where(Function(grp) grp.Count() > 1).
                Select(Function(grp)
                           Return New PersonGroup With {.City = grp.Key.FirstName, .List = grp.ToList()}
                       End Function).ToList()


        End Function
        ''' <summary>
        ''' Group by age and sex as anonymous type, see Example4a for
        ''' strong typed results.
        ''' </summary>
        Public Sub Example4()
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

                Console.WriteLine()

            Next
        End Sub
        ''' <summary>
        ''' Strong typed version of Example4.
        ''' Note, Visual Studio may indicate that Key can be simplified, this is not
        ''' true, Key indicates which properties make up the group.
        ''' </summary>
        ''' <returns></returns>
        Public Function Example4a() As IEnumerable(Of PeopleGroupedByAgeGender)

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
    Public Class PeopleGroupedByAgeGender

        Public Property PeopleList As List(Of Person)
        Public Property Age() As Integer
        Public Property Sex() As String
    End Class
End Namespace