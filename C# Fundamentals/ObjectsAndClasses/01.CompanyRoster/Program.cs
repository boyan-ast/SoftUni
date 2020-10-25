using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>(n);
            Dictionary<string, List<double>> departments = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] employeeData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = employeeData[0];
                double salary = double.Parse(employeeData[1]);
                string department = employeeData[2];

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new List<double>());
                }

                departments[department].Add(salary);

                Employee employee = new Employee(name, salary, department);

                employees.Add(employee);
            }

            double highestAverageSalary = 0;
            string highestSalaryDepartment = string.Empty;

            foreach (var kvp in departments)
            {
                double averageSalary = (kvp.Value.Sum()) / (kvp.Value.Count);

                if (averageSalary > highestAverageSalary)
                {
                    highestAverageSalary = averageSalary;
                    highestSalaryDepartment = kvp.Key;
                }
            }

            Console.WriteLine($"Highest Average Salary: {highestSalaryDepartment}");

            List<Employee> filteredEmployees = employees
                .Where(d => d.Department == highestSalaryDepartment)
                .OrderByDescending(x => x.Salary)
                .ToList();

            foreach (Employee employee in filteredEmployees)
            {
                Console.WriteLine(employee);
            }
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public override string ToString()
        {
            return $"{Name} {Salary:f2}";
        }
    }
}
