# Visual Basic .NET Group by examples

[Article location](https://social.technet.microsoft.com/wiki/contents/articles/53538.introduction-to-grouping-with-linqlambda-vb-net.aspx)

## Note
- This is a work in progress, many more code samples to follow.
- In some cases mirror examples will be done, one for anonymous type result set, another for strongly typed result set.

Advance sample: **nested group by** which in the article there will be a walkthrough to show how to start with a anonymous LINQ statement and learn how to go to a strong typed result set.
```csharp
Imports PersonLibrary.Classes
Imports StudentGrouping.GroupingClasses

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
```
