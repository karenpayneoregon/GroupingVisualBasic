Imports GroupCharsOccurrences.Classes

Module Module1

    Sub Main()
        'BasicWordExample()
        'BasicExample()
        'BasicExampleStripped()
        'BasicExampleStrongTyped()
        Console.ReadLine()
    End Sub
    Sub BasicExample()
        Dim InputString As String = "T0*A1?0*23aTA3 4T4\+a4 ?407#?A*6T+"

        Dim characterGroup =
                (
                    From character In InputString.ToCharArray()
                    Group characterElement = character By charElement = character Into Group
                    Select New With {.Character = charElement, .Occurrences = Group.Count}
                ).
                ToList.
                OrderBy(Function(anonymous) anonymous.Character)

        Console.WriteLine($"Char    Occurrences")
        For Each currentItem In characterGroup
            Console.WriteLine($"[{currentItem.Character}] {currentItem.Occurrences,5}")
        Next

    End Sub
    ''' <summary>
    ''' This version shows the raw data returned and the type of each element which
    ''' allows the creation of a container class as done in BasicExampleStrongTyped
    ''' function.
    ''' </summary>
    Sub BasicExampleStripped()
        Dim InputString As String = "T0*A1?0*23aTA3 4T4\+a4 ?407#?A*6T+"

        Dim characterGroup =
                (
                    From character In InputString.ToCharArray()
                    Group characterElement = character By charElement = character Into Group
                    Select New With {.Character = charElement, .Occurrences = Group.Count}
                ).
                ToList.
                OrderBy(Function(anonymous) anonymous.Character)

        Console.WriteLine($"Char    Occurrences")
        For Each currentItem In characterGroup
            Console.WriteLine($"{currentItem} - {currentItem.Character.GetType()} - {currentItem.Occurrences.GetType()}")
        Next


    End Sub
    Sub BasicWordExample()
        Dim wordList = New List(Of String) From {"Hello", "Goodnight", "Hello", "Good", "Last"}

        Dim wordGroup =
                (
                    From word In wordList
                    Group wordElement = word By token = word Into Group
                    Select New With {.Word = token, .Occurrences = Group.Count}
                ).
                ToList.
                OrderBy(Function(anonymous) anonymous.Word)


        For Each currentWord In wordGroup
            Console.WriteLine($"{currentWord.Word}, {currentWord.Occurrences}")
        Next

    End Sub
    Function WordExampleStrongTyped() As IOrderedEnumerable(Of WordOccurrenceContainer)
        Dim wordList = New List(Of String) From {"Hello", "Goodnight", "Hello", "Good", "Last"}

        Dim wordGroup As IOrderedEnumerable(Of WordOccurrenceContainer) =
                (
                    From word In wordList
                    Group wordElement = word By token = word Into Group
                    Select New WordOccurrenceContainer With {.Word = token, .Occurrences = Group.Count}
                ).
                ToList.
                OrderBy(Function(anonymous) anonymous.Word)

        Return wordGroup

    End Function
    Sub UnWise()
        Dim InputString As String = "T0*A1?0*23aTA3 4T4\+a4 ?407#?A*6T+"

        Dim results = (From c In InputString.ToCharArray() Group c By c Into Group
                       Select New With {.Item = c, .Occurrences = Group.Count}).ToList.OrderBy(Function(x) x.Item)

    End Sub
    ''' <summary>
    ''' Final version strongly typed
    ''' </summary>
    ''' <returns></returns>
    Function BasicExampleStrongTyped() As IOrderedEnumerable(Of OccurrenceContainer)
        Dim InputString As String = "T0*A1?0*23aTA3 4T4\+a4 ?407#?A*6T+"

        Dim characterGroup As IOrderedEnumerable(Of OccurrenceContainer) =
                (
                    From character In InputString.ToCharArray()
                    Group characterElement = character By charElement = character Into Group
                    Select New OccurrenceContainer With {.Character = charElement, .Occurrences = Group.Count}
                ).
                ToList.
                OrderBy(Function(anonymous) anonymous.Character)

        Console.WriteLine($"Char    Occurrences")
        For Each currentItem As OccurrenceContainer In characterGroup
            Console.WriteLine(
                $"{currentItem} - {currentItem.Character.GetType()} - {currentItem.Occurrences.GetType()}")
        Next

        Return characterGroup

    End Function
End Module