using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] studentData = Console.ReadLine().Split();

                string name = studentData[0];
                decimal grade = decimal.Parse(studentData[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }

                students[name].Add(grade);
            }

            foreach (var kvp in students)
            {
                StringBuilder grades = new StringBuilder();

                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    grades.Append($"{kvp.Value[i]:f2} ");
                }

                Console.WriteLine($"{kvp.Key} -> {grades}(avg: {kvp.Value.Average():f2})");
            }
        }
    }
}
