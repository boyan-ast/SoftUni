using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public static class Services
    {
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var filteredDepartments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(x => new
                    {
                        DepartmentName = x.Name,
                        ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
                        Employees = x.Employees
                    })
                .ToList();


            foreach (var department in filteredDepartments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerName}");

                foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            Employee selectedEmployee = context.Employees.Find(147);

            result.AppendLine($"{selectedEmployee.FirstName} {selectedEmployee.LastName} - {selectedEmployee.JobTitle}");

            var projects = context.EmployeesProjects
                .Where(x => x.EmployeeId == 147)
                .OrderBy(x => x.Project.Name)
                .Select(ep => ep.Project.Name).ToList();

            result.Append(string.Join("\r\n", projects));

            return result.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(x => new { x.AddressText, Town = x.Town.Name, EmployeesCount = x.Employees.Count })
                .ToList();

            foreach (var address in addresses)
            {
                result.AppendLine($"{address.AddressText}, {address.Town} - {address.EmployeesCount} employees");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var filteredEmployees = context.Employees
                .Where(x => x.EmployeesProjects.Any(y => y.Project.StartDate.Year >= 2001 && y.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    Manager = x.Manager.FirstName + " " + x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(y => new { y.Project.Name, y.Project.StartDate, y.Project.EndDate }).ToList()
                })
                .ToList();

            foreach (var employee in filteredEmployees)
            {
                result.AppendLine($"{employee.FullName} - Manager: {employee.Manager}");

                foreach (var project in employee.Projects)
                {
                    string endDate = project.EndDate != null ? ((DateTime)project.EndDate).ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";
                    result.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");
                }
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context.Employees.Select(x => new { x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary }).ToList();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return result.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName);

            foreach (Employee employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .Select(x => new { FullName = x.FirstName + " " + x.LastName, Department = x.Department.Name, Salary = x.Salary })
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FullName} from {e.Department} - ${e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAddress = new Address();
            newAddress.AddressText = "Vitoshka 15";
            newAddress.TownId = 4;

            Employee employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            context.Addresses.Add(newAddress);
            employee.Address = newAddress;
            context.SaveChanges();

            var filteredEmployeesAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(x => new { x.Address.AddressText });


            foreach (var address in filteredEmployeesAddresses)
            {
                sb.Append(address.AddressText + "\r\n");
            }

            return sb.ToString().Trim();
        }
    }
}
