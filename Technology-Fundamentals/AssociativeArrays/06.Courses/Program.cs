using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> registeredStuents = new Dictionary<string, List<string>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] userInfo = command.Split(" : ");
                string courseName = userInfo[0];
                string studentName = userInfo[1];

                if (!registeredStuents.ContainsKey(courseName))
                {
                    registeredStuents[courseName] = new List<string>();
                }

                registeredStuents[courseName].Add(studentName);
            }

            foreach (var kvp in registeredStuents.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                foreach (string student in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
