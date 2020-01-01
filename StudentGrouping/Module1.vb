Imports PersonLibrary.Classes
Imports StudentGrouping.GroupingClasses

''' <summary>
''' Samples taken from C# code samples @Microsoft
''' https://docs.microsoft.com/en-us/dotnet/csharp/linq/create-a-nested-group
''' Adapted to fit into this solution
''' </summary>
Module Module1

    Sub Main()

        StrongTypedVersion()
        Console.ReadLine()

    End Sub
    ''' <summary>
    ''' Translated from C#, can never be a function
    ''' </summary>
    Private Sub AnonymousVersion()
        Dim students = PersonLibrary.Classes.Students.List()

        Dim queryNestedGroups =
                From student In students
                Group student By student.Year Into newGroup1 = Group
                From newGroup2 In (From student In newGroup1 Group student By LastName = student.LastName Into Group)
                Group newGroup2 By Year Into Group

        For Each grouping In queryNestedGroups
            Console.WriteLine($"DataClass.Student Level = {grouping.Year}")
            For Each grouping2 In grouping.Group
                Console.WriteLine((ChrW(9) & "Names that begin with: " & grouping2.LastName))
                Dim student As Student
                For Each student In grouping2.Group
                    Console.WriteLine((ChrW(9) & ChrW(9) & student.LastName & " " & student.FirstName))
                Next
            Next
        Next

    End Sub
    ''' <summary>
    ''' Revised from AnonymousVersion which means this version can be a function
    ''' </summary>
    Private Sub StrongTypedVersion()
        Dim studentGroup As New List(Of StudentGroup)

        Dim students = PersonLibrary.Classes.Students.List()

        Dim queryNestedGroups =
                From student In students
                Group student By student.Year Into newGroup1 = Group
                From newGroup2 In (From student In newGroup1
                                   Group student By LastName = student.LastName Into Group)
                Group newGroup2 By Year Into Group


        For Each outerGrouping In queryNestedGroups
            Dim currentStudent As New StudentGroup With {.Year = outerGrouping.Year, .ItemGroup = New List(Of ItemGroup)()}

            For Each innerGrouping In outerGrouping.Group
                currentStudent.ItemGroup.Add(New ItemGroup() With {.LastName = innerGrouping.LastName, .Students = innerGrouping.Group})
            Next

            studentGroup.Add(currentStudent)

        Next


        For Each studentGrouping As StudentGroup In studentGroup
            Console.WriteLine($"{studentGrouping.Year}")
            For Each itemGroup As ItemGroup In studentGrouping.ItemGroup
                Console.WriteLine($"   {itemGroup.LastName}")
                For Each student As Student In itemGroup.Students
                    Console.WriteLine($"      {student}")
                Next
            Next

        Next

    End Sub

End Module