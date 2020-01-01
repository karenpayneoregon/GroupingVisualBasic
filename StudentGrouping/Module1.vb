﻿Imports PersonLibrary.Classes
Imports StudentGrouping.GroupingClasses

''' <summary>
''' Some samples taken from C# code samples @Microsoft
''' https://docs.microsoft.com/en-us/dotnet/csharp/linq/create-a-nested-group
''' Others from 
''' https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/queries/group-by-clause
''' Adapted to fit into this solution
''' </summary>
Module Module1

    Sub Main()

        GroupBySinglePropertyLambda()

        Console.ReadLine()

    End Sub
    ''' <summary>
    ''' Translated from C#, can never be a function
    ''' </summary>
    Private Sub AnonymousNestedVersion()
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
    Private Sub StrongTypedNestedVersion()
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
    ''' <summary>
    ''' The following example shows how to group source elements by using a single property, LastName then
    ''' perform an Order By on LastName
    ''' </summary>
    Private Sub GroupBySinglePropertyLinq()

        Dim students = PersonLibrary.Classes.Students.List()

        Dim queryLastNames =
                From student In students
                Group By LastName = student.LastName Into StudentGroup = Group
                Order By LastName


        For Each currentItem In queryLastNames
            Console.WriteLine(currentItem.LastName)
            For Each student As Student In currentItem.StudentGroup
                Console.WriteLine($"   {student}")
            Next
        Next



    End Sub
    Private Sub GroupBySinglePropertyLambda()
        Dim students = PersonLibrary.Classes.Students.List()

        Dim queryLastNames1 As IOrderedEnumerable(Of IGrouping(Of String, Student)) =
                students.GroupBy(Function(student) student.LastName).Select(Function(item) item).OrderBy(Function(item) item.Key)

        For Each current As IGrouping(Of String, Student) In queryLastNames1
            Console.WriteLine($"{current.Key}")
            For Each student As Student In current
                Console.WriteLine($"   {student}")
            Next

        Next

        Console.WriteLine()

        Dim queryLastNames2 = students.GroupBy(Function(student) student.LastName).
                Select(Function(group) New StudentContainer With {
                    .LastName = group.Key,
                    .List = group.ToList()
                    }).
                OrderBy(Function(xItem) xItem.LastName).
                ToList()

        For Each container As StudentContainer In queryLastNames2
            Console.WriteLine($"{container.LastName}")
            For Each student As Student In container.List
                Console.WriteLine($"   {student}")
            Next
        Next

    End Sub

End Module