Imports DuplicatesStringsGroupBy.Classes

Module Module1

    Sub Main()

        Dim wordList As New List(Of String)(New String() _
            {"Ten", "three", "Five", "one", "Eight", "Three", "ten", "two", "four", "Eight", "three"})


        Console.WriteLine("Using anonymous type - shows words upper cased")
        ShowDuplicates()

        Console.WriteLine("--------------------------------")
        Console.WriteLine("Using strong type - reference value in original list, original case")

        Dim queryFirstAttempt = ListDuplicates(wordList)
        For Each duplicates In queryFirstAttempt

            Console.WriteLine(wordList(duplicates.FirstOrDefault().Index))

            For Each duplicate As Duplicate In duplicates
                Console.WriteLine("{0,4}", duplicate.Index)
            Next
        Next

        Console.WriteLine("--------------------------------")
        Console.WriteLine("Using strong type - StringComparer.OrdinalIgnoreCase")
        Dim querySecondAttempt = ListDuplicatesGroupStringCompareIgnoreCase(wordList)
        For Each duplicates In querySecondAttempt

            Console.WriteLine(wordList(duplicates.FirstOrDefault().Index))

            For Each duplicate As Duplicate In duplicates
                Console.WriteLine("{0,4}", duplicate.Index)
            Next
        Next

        Console.ReadLine()

    End Sub
    ''' <summary>
    ''' Given a list of string find duplicates and their index in the list were comparision
    ''' is done via using .ToUpper on each word in the incoming list which means to present
    ''' this the index property of each Duplicate must reference the original list.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    Function ListDuplicates(sender As List(Of String)) As IEnumerable(Of IEnumerable(Of Duplicate))

        Dim query As IEnumerable(Of IEnumerable(Of Duplicate)) =
             From value In sender.Select(Function(word, index) New Duplicate With {.Word = word.ToUpper, .Index = index})
             Group By Word = value.Word Into Group
             Where Group.Count > 1 Select Group


        Return query

    End Function
    ''' <summary>
    ''' Given a list of string find duplicates and their index in the list were comparision is
    ''' done using a Comparer (IEqualityComparer) other than the default to specify to ignore
    ''' case of the elements in the string list.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    Function ListDuplicatesGroupStringCompareIgnoreCase(sender As List(Of String)) As IEnumerable(Of IGrouping(Of String, Duplicate))
        '
        Dim query As IEnumerable(Of IGrouping(Of String, Duplicate)) = sender.
                Select(Function(word, index) New Duplicate With {.Word = word, .Index = index}).
                GroupBy(Function(item) item.Word, StringComparer.OrdinalIgnoreCase).
                Where(Function(grouping) grouping.Count() > 1)

        Return query

    End Function
    Sub ShowDuplicates()
        Dim words As New List(Of String)(New String() {"Ten", "three", "Five", "one", "Eight", "Three", "ten", "two", "four", "Eight", "Three"})
        Dim q = From value In words.Select(Function(v, index) New With {.value = v.ToUpper, .index = index})
                Group By value.value Into Group
                Where Group.Count > 1

        For Each item In q
            ' item with duplicate
            Console.WriteLine(item.value.ToString)

            ' index in the List
            For Each item2 In item.Group
                Console.WriteLine("{0,4}", item2.index.ToString)
            Next
        Next


    End Sub

End Module