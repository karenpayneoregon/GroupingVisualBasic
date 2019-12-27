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

            Dim groupResults = personList.GroupBy(Function(person) New With {Key person.City, Key person.Country}).Where(Function(grp) grp.Count() > 1).ToList()

            For Each grouping In groupResults
                Console.WriteLine($"{grouping.Key.City}, {grouping.Key.Country}")
                For Each anonymous As Person In grouping
                    Console.WriteLine($"    {anonymous.Id}  {anonymous.FirstName} {anonymous.LastName}")
                Next
            Next

        End Sub
        ''' <summary>
        ''' This method groups by two properties to a strong typed class definition
        ''' </summary>
        ''' <returns></returns>
        Public Function Example2() As List(Of PersonGroup)
            Dim personList = People.List()

            Return personList.GroupBy(Function(person) New With {Key person.City, Key person.Country}).Where(Function(grp) grp.Count() > 1).
                Select(Function(grp) New PersonGroup With {.City = grp.Key.City, .Country = grp.Key.Country, .Grouping = grp.ToList()}).ToList()


        End Function
    End Class
End Namespace