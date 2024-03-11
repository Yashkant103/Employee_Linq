using Employee_Linq;

var context = new ApplicationDBContext();
//For example, Display FirstName of all Employee.
//var q1 = context.Employee.Select(x => x.FirstName);
//foreach (var employee in q1)
//{
//    Console.WriteLine("\n {0}", employee);
//}

#region  LINQ Queries on Projection operators
// LINQ Queries on Projection operators::
// 1. Display data of all Employee.
var allEmployee = context.Employee.Select(e => e);
foreach (var employee in allEmployee)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Email: {employee.Email}");
}
Console.WriteLine("====================================================================================");

// 2. Select ActNo, FirstName and Salary of all Employee to a new class and display it.
var selectedData = context.Employee.Select(e => new { e.AccountNo, e.FirstName, e.Salary });
foreach (var employee in selectedData)
{
    Console.WriteLine($"ActNo: {employee.AccountNo}, FirstName: {employee.FirstName}, Salary:{employee.Salary} ");
}
Console.WriteLine("====================================================================================");

// 3. Display data in following format => {Anil} works in {Admin} Department.
var employeeDepartment = context.Employee.Select(e => new { e.FirstName, e.Department });
foreach (var employee in employeeDepartment)
{
    Console.WriteLine($"{employee.FirstName} works in {employee.Department} Department");
}
Console.WriteLine("====================================================================================");

// 4. Select Employee Full Name, Email and Department as anonymous and display it.
var employeeDetails = context.Employee.Select(e => new { FullName = $"{e.FirstName} {e.LastName}", e.Email, e.Department });
foreach (var employee in employeeDetails)
{
    Console.WriteLine($"Full Name: {employee.FullName}, Email: {employee.Email}, Department: {employee.Department}");
}
Console.WriteLine("====================================================================================");

// 5. Display employees with their joining date
var employeeJoiningDate = context.Employee.Select(e => new { e.FirstName, e.LastName, e.JoiningDate });
foreach (var employee in employeeJoiningDate)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Joining Date: {employee.JoiningDate}");
}
Console.WriteLine("====================================================================================");

#endregion  LINQ Queries on Projection operators

#region  LINQ Queries on Filtering operators
// 6. Display employees between age 20 to 30.
var employeesAge20To30 = context.Employee.Where(e => e.Age >= 20 && e.Age <= 30);
foreach (var employee in employeesAge20To30)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Age: {employee.Age}");
}
Console.WriteLine("====================================================================================");

// 7. Display female employees.
var femaleEmployees = context.Employee.Where(e => e.Gender == "Female");
foreach (var employee in femaleEmployees)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Gender: {employee.Gender}");
}
Console.WriteLine("====================================================================================");

// 8. Display employees with salary more than 35000.
var highSalaryEmployees = context.Employee.Where(e => e.Salary > 35000);
foreach (var employee in highSalaryEmployees)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Salary: {employee.Salary}");
}
Console.WriteLine("====================================================================================");

// 9. Display employees whose account no is less than 110.
var accountLessThan110 = context.Employee.Where(e => e.AccountNo < 110);
foreach (var employee in accountLessThan110)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Account No: {employee.AccountNo}");
}
Console.WriteLine("====================================================================================");

// 10. Display employees who belongs to either Rajkot or Morbi city.
var employeesFromRajkotOrMorbi = context.Employee.Where(e => e.City == "Rajkot" || e.City == "Morbi");
foreach (var employee in employeesFromRajkotOrMorbi)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, City: {employee.City}");
}
Console.WriteLine("====================================================================================");

// 11. Display employees whose salary is less than 20000.
var lowSalaryEmployees = context.Employee.Where(e => e.Salary < 20000);
foreach (var employee in lowSalaryEmployees)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Salary: {employee.Salary}");
}
Console.WriteLine("====================================================================================");

// 12. Display employees whose salary is more than equal to 30000 and less than equal to 60000.
var midSalaryEmployees = context.Employee.Where(e => e.Salary >= 30000 && e.Salary <= 60000);
foreach (var employee in midSalaryEmployees)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Salary: {employee.Salary}");
}
Console.WriteLine("====================================================================================");

// 13. Display ActNo, FirstName and Amount of employees who belong to Morbi or Ahmedabad or Surat city and Account No greater than 120.
var selectedEmployees = context.Employee.Where(e => (e.City == "Morbi" || e.City == "Ahmedabad" || e.City == "Surat") && e.AccountNo > 120)
                                 .Select(e => new { e.AccountNo, e.FirstName, e.Salary });
foreach (var employee in selectedEmployees)
{
    Console.WriteLine($"ActNo: {employee.AccountNo}, FirstName: {employee.FirstName}, Salary:{employee.Salary} ");
}
Console.WriteLine("====================================================================================");

// 14. Display male employees of age between 30 to 35 and belongs to Rajkot city.
var selectedMaleEmployees = context.Employee.Where(e => e.Gender == "Male" && e.Age >= 30 && e.Age <= 35 && e.City == "Rajkot");
foreach (var employee in selectedMaleEmployees)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Age: {employee.Age}, City: {employee.City}");
}
Console.WriteLine("====================================================================================");

// 15. Display Unique Cities. (use Distinct())
var uniqueCities = context.Employee.Select(e => e.City).Distinct();
foreach (var city in uniqueCities)
{
    Console.WriteLine($"City: {city}");
}
Console.WriteLine("====================================================================================");

// 16. Display employees whose joining is between 15/07/2018 to 16/09/2019.
DateTime startDate = new DateTime(2018, 7, 15);
DateTime endDate = new DateTime(2019, 9, 16);
var employeesJoinedInPeriod = context.Employee.Where(e => e.JoiningDate >= startDate && e.JoiningDate <= endDate);
foreach (var employee in employeesJoinedInPeriod)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Joining Date: {employee.JoiningDate}");
}
Console.WriteLine("====================================================================================");

// 17. Display female employees who works in Sales department.
var femaleSalesEmployees = context.Employee.Where(e => e.Gender == "Female" && e.Department == "Sales");
foreach (var employee in femaleSalesEmployees)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}");
}
Console.WriteLine("====================================================================================");

// 18. Display employees with their Age who belong to Rajkot city and more than 35 years old.
var oldEmployeesFromRajkot = context.Employee.Where(e => e.City == "Rajkot" && e.Age > 35)
                                      .Select(e => new { e.FirstName, e.LastName, e.Age });
foreach (var employee in oldEmployeesFromRajkot)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Age: {employee.Age}");
}
Console.WriteLine("====================================================================================");

#endregion  LINQ Queries on Filtering operators

#region LINQ Queries on Aggregate 
//19. Find total salary and display it.
var totalSalary = context.Employee.Sum(e => e.Salary);
Console.WriteLine($"Total Salary: {totalSalary}");
Console.WriteLine("====================================================================================");

//20. Find total number of employees of Admin department who belong to Rajkot city.
var adminRajkotEmployeesCount = context.Employee
    .Count(e => e.Department == "Admin" && e.City == "Rajkot");
Console.WriteLine($"Total Admin employees in Rajkot: {adminRajkotEmployeesCount}");
Console.WriteLine("====================================================================================");

//21. Find total salary of Distribution department.
var distributionDepartmentTotalSalary = context.Employee
    .Where(e => e.Department == "Distribution")
    .Sum(e => e.Salary);
Console.WriteLine($"Total Salary of Distribution department: {distributionDepartmentTotalSalary}");
Console.WriteLine("====================================================================================");

//22. Find average salary of IT department.
var averageITDepartmentSalary = context.Employee
    .Where(e => e.Department == "IT")
    .Average(e => e.Salary);
Console.WriteLine($"Average Salary of IT department: {averageITDepartmentSalary}");
Console.WriteLine("====================================================================================");

//23. Find minimum salary of Customer Relationship department.
var minCustomerRelationshipSalary = context.Employee
    .Where(e => e.Department == "Customer Relationship")
    .Min(e => e.Salary);
Console.WriteLine($"Minimum Salary of Customer Relationship department: {minCustomerRelationshipSalary}");
Console.WriteLine("====================================================================================");

//24. Find maximum salary of Distribution department who belongs to Baroda city.
var maxDistributionBarodaSalary = context.Employee
    .Where(e => e.Department == "Distribution" && e.City == "Baroda")
    .Max(e => e.Salary);
Console.WriteLine($"Maximum Salary of Distribution department in Baroda: {maxDistributionBarodaSalary}");
Console.WriteLine("====================================================================================");

//25. Find number of employees whose Age is more than 40.
var employeesAbove40Count = context.Employee.Count(e => e.Age > 40);
Console.WriteLine($"Number of employees above 40: {employeesAbove40Count}");
Console.WriteLine("====================================================================================");

//26. Find total female employees working in Ahmedabad city.
var totalFemaleAhmedabadEmployees = context.Employee
    .Count(e => e.Gender == "Female" && e.City == "Ahmedabad");
Console.WriteLine($"Total Female employees in Ahmedabad: {totalFemaleAhmedabadEmployees}");
Console.WriteLine("====================================================================================");

//27. Find total salary of male employees who belong to Gandhinagar city and work in IT department.
var totalMaleGandhinagarITSalary = context.Employee
    .Where(e => e.Gender == "Male" && e.City == "Gandhinagar" && e.Department == "IT")
    .Sum(e => e.Salary);
Console.WriteLine($"Total Salary of Male employees in Gandhinagar working in IT department: {totalMaleGandhinagarITSalary}");
Console.WriteLine("====================================================================================");

//28. Find average salary of male employees whose age is between 21 to 35.
var averageSalaryMale21to35 = context.Employee
    .Where(e => e.Gender == "Male" && e.Age >= 21 && e.Age <= 35)
    .Average(e => e.Salary);
Console.WriteLine($"Average Salary of Male employees aged 21 to 35: {averageSalaryMale21to35}");
Console.WriteLine("====================================================================================");

#endregion LINQ Queries on Aggregate 

#region LINQ Queries on Sorting operators
//29. Display employees by their first name in ascending order.
var employeesByFirstNameAscending = context.Employee.OrderBy(e => e.FirstName).ToList();
foreach (var employee in employeesByFirstNameAscending)
{
    Console.WriteLine($"Name: {employee.FirstName}, Last Name: {employee.LastName}");
}
Console.WriteLine("====================================================================================");

//30. Display employees by department name in descending order.
var employeesByDepartmentDescending = context.Employee.OrderByDescending(e => e.Department).ToList();
foreach (var employee in employeesByDepartmentDescending)
{
    Console.WriteLine($"Name: {employee.FirstName}, Department: {employee.Department}");
}
Console.WriteLine("====================================================================================");

//31. Display employees by department name descending and first name in ascending order.
var employeesByDepartmentAndFirstName = context.Employee
    .OrderByDescending(e => e.Department)
    .ThenBy(e => e.FirstName)
    .ToList();

foreach (var employee in employeesByDepartmentAndFirstName)
{
    Console.WriteLine($"Name: {employee.FirstName}, Department: {employee.Department}");
}
Console.WriteLine("====================================================================================");

//32. Display employees by their first name in ascending order and last name in descending order.
var employeesByFirstNameAndLastNameDescending = context.Employee
    .OrderBy(e => e.FirstName)
    .ThenByDescending(e => e.LastName)
    .ToList();

foreach (var employee in employeesByFirstNameAndLastNameDescending)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}");
}
Console.WriteLine("====================================================================================");

//33. Display employees by their Joining Date using Reverse() operator.
var employeesByJoiningDateDescending = context.Employee
    .OrderBy(e => e.JoiningDate)
    .Reverse()
    .ToList();

foreach (var employee in employeesByJoiningDateDescending)
{
    Console.WriteLine($"Name: {employee.FirstName}, Joining Date: {employee.JoiningDate}");
}
Console.WriteLine("====================================================================================");

#endregion LINQ Queries on Sorting operators
