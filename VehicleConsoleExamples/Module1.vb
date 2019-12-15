Imports VehicleLibrary

Module Module1

    Sub Main()
        Dim standardColor = Console.ForegroundColor
        Dim operations = New VehicleExamples

        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Group By Manufacturer Then By Year")
        Console.ForegroundColor = standardColor


        operations.GroupByManufacturerThenByYear()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Group By Manufacturer Then By Year")
        Console.ForegroundColor = standardColor
        operations.GroupByManufacturerOrderByManufacturer()

        Console.ReadLine()
    End Sub

End Module
