using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            AddEmployees(companies);

            foreach (var kvp in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);

                foreach (string id in kvp.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }

        static void AddEmployees(Dictionary<string, List<string>> companies)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] companyInfo = command.Split(" -> ");
                string companyName = companyInfo[0];
                string employeeId = companyInfo[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies[companyName] = new List<string>();
                }

                if (!companies[companyName].Contains(employeeId))
                {
                    companies[companyName].Add(employeeId);
                }
            }
        }
    }
}
