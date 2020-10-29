using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] studentInfo = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string courseName = studentInfo[0];
                string studentName = studentInfo[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses[courseName] = new List<string>();
                }

                courses[courseName].Add(studentName);
            }

            foreach (var kvp in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                foreach (string student in kvp.Value.OrderBy(s => s))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
