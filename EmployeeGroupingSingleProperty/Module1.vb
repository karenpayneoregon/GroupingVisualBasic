Imports PersonLibrary.Classes

Module Module1

    ''' <summary>
    ''' Purpose
    ''' 
    ''' For learning basics of grouping. Note that each part of the LINQ statement has meaningful
    ''' names e.g. in many examples on the web g grp are used in the group section and rather than
    ''' than singleEmployee (local range variable that represents each element in the source sequence.)
    ''' 
    ''' </summary>
    Sub Main()

        Console.WriteLine("Group by departments")
        '
        ' Group by departments
        '
        Dim groupedEmployees As List(Of EmployeeGroup) =
            (
                From singleEmployee As Employee In Employees.List()
                Group By department = singleEmployee.Department Into enumerableGroupOfEmployee = Group
                Select New EmployeeGroup With
                {
                    .Department = department,
                    .Employees = enumerableGroupOfEmployee
                }
            ).ToList

        '
        ' Working off the above LINQ statement filter department grouping to only those departments
        ' with more than one entry
        '

        For Each employeeGroup As EmployeeGroup In groupedEmployees
            Console.WriteLine(employeeGroup.Department)
            For Each employee As Employee In employeeGroup.Employees
                Console.WriteLine("  {0}", employee.Id)
            Next
        Next


        '
        ' Taking the first group statement append a where condition for departments with more than
        ' one entry
        '
        Console.WriteLine()
        Console.WriteLine("Group by departments greater than one off the first statement")

        Dim departmentCountGreaterThanOne As IEnumerable(Of EmployeeGroup) = groupedEmployees.Where(Function(employee) employee.Employees.Count() > 1)

        For Each employeeGroup As EmployeeGroup In departmentCountGreaterThanOne
            Console.WriteLine(employeeGroup.Department)
            For Each employee As Employee In employeeGroup.Employees
                Console.WriteLine("  {0}", employee.Id)
            Next
        Next

        Console.WriteLine()
        Console.WriteLine("Group by departments greater than one")

        Dim groupedEmployees1 As List(Of EmployeeGroup) =
            (
                From singleEmployee As Employee In Employees.List()
                Group By department = singleEmployee.Department Into enumerableGroupOfEmployee = Group
                Select New EmployeeGroup With
                    {
                        .Department = department,
                        .Employees = enumerableGroupOfEmployee
                    }
                ).
                Where(Function(employeeGroup) employeeGroup.Employees.Count() > 1
            ).ToList()

        For Each employeeGroup As EmployeeGroup In groupedEmployees1
            Console.WriteLine(employeeGroup.Department)
            For Each employee As Employee In employeeGroup.Employees
                Console.WriteLine("  {0}", employee.Id)
            Next
        Next

        Console.ReadLine()

    End Sub

End Module
