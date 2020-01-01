Module Module1
    ''' <summary>
    ''' Given two weeks of weather get 
    ''' low, high and average temperatures
    ''' </summary>
    Sub Main()

        Dim temperaturesDictionary As New Dictionary(Of Integer, Integer) From
                {
                    {1, 55},
                    {2, 50},
                    {3, 56},
                    {4, 50},
                    {5, 60},
                    {6, 60},
                    {7, 65},
                    {8, 90},
                    {9, 80},
                    {10, 40},
                    {11, 40},
                    {12, 35},
                    {13, 37},
                    {14, 30}
                }

        Dim statistics =
                (
                    From grouping In temperaturesDictionary.GroupBy(Function(keyValuePair) 3 > 0)) _
                    .Select(Function(groupBooleanKeyValuePair) _
                               New With
                               {
                                   .High = groupBooleanKeyValuePair.Max(Function(keyValuePair) keyValuePair.Value),
                                   .Low = groupBooleanKeyValuePair.Min(Function(keyValuePair) keyValuePair.Value),
                                   .Average = CInt(groupBooleanKeyValuePair.Average(Function(keyValuePair) keyValuePair.Value))
                               }
                ).FirstOrDefault

        Console.WriteLine($"Average: {statistics.Average} High: {statistics.High} Low: {statistics.Low}")

        Console.ReadLine()

    End Sub

End Module
