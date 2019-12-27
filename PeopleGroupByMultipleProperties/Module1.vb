Imports PersonLibrary
Imports PersonLibrary.Classes

Module Module1
    ''' <summary>
    ''' Given a Person class with City and Country, the task is to group by City and Country.
    ''' </summary>
    Sub Main()
        Dim standardColor = Console.ForegroundColor

        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Anonymous")
        Console.ForegroundColor = standardColor

        Dim operations = New PersonGroupByMultipleProperties
        operations.Example1()

        Console.WriteLine()

        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Strongly typed")
        Console.ForegroundColor = standardColor

        Dim result = operations.Example2()

        For Each personGroup As PersonGroup In result
            Console.WriteLine(personGroup)
            For Each person As Person In personGroup.Grouping
                Console.WriteLine($"    {person.Id} - {person.FirstName} {person.LastName}")
            Next
        Next

        Console.ReadLine()

    End Sub

End Module
