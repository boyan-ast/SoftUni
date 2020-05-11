using System;
using System.Globalization;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int allowedFails = int.Parse(Console.ReadLine());

            string command = string.Empty;
            string problemName = string.Empty;
            int numberOfProblems = 0;
            bool hasFailed = false;
            double sumGrade = 0;
            int poorGrades = 0;


            while ((command = Console.ReadLine()) != "Enough")
            {
                problemName = command;
                numberOfProblems++;
                int grade = int.Parse(Console.ReadLine());
                sumGrade += grade;

                if (grade <= 4)
                {
                    poorGrades++;

                    if (poorGrades == allowedFails)
                    {
                        hasFailed = true;
                        break;
                    }
                }
            }

            if (!hasFailed)
            {
                Console.WriteLine($"Average score: {(sumGrade/numberOfProblems):f2}");
                Console.WriteLine($"Number of problems: {numberOfProblems}");
                Console.WriteLine($"Last problem: {problemName}");
            }
            else
            {
                Console.WriteLine($"You need a break, {allowedFails} poor grades.");
            }
        }
    }
}
