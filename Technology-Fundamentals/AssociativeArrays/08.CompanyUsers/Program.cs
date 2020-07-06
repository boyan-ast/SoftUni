using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyUsers = new Dictionary<string, List<string>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] employeeInfo = command.Split(" -> ");

                RegisterEmployees(companyUsers, employeeInfo);
            }

            foreach (var kvp in companyUsers.OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (string id in kvp.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }

        private static void RegisterEmployees(Dictionary<string, List<string>> companyUsers, string[] info)
        {
            string companyName = info[0];
            string employeeId = info[1];

            if (!companyUsers.ContainsKey(companyName))
            {
                companyUsers[companyName] = new List<string>();
                companyUsers[companyName].Add(employeeId);
            }
            else if(!checkIfIdExists(companyUsers, companyName, employeeId))
            {
                companyUsers[companyName].Add(employeeId);
            }            
        }

        private static bool checkIfIdExists(Dictionary<string, List<string>> companyUsers, string company, string id)
        {
            if (companyUsers[company].Contains(id))
            {
                return true;
            }

            return false;
        }
    }
}
