using System;
using System.Drawing;

namespace _06.ExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;

            while ((name = Console.ReadLine()) != "Midnight")
            {
                double totalPoints = 0;
                bool isCheating = false;

                for (int i = 0; i < 6; i++)
                {
                    int points = int.Parse(Console.ReadLine());

                    if (points < 0)
                    {
                        isCheating = true;
                        Console.WriteLine($"{name} was cheating!");
                        break;
                    }

                    totalPoints += points;
                }

                if (!isCheating)
                {
                    double grade = Math.Floor(totalPoints / 600 * 100) * 0.06;

                    if (grade < 3)
                    {
                        grade = 2;
                    }

                    if (grade >= 5)
                    {
                        Console.WriteLine("===================");
                        Console.WriteLine("|   CERTIFICATE   |");
                        Console.WriteLine($"|    {grade:f2}/6.00    |");
                        Console.WriteLine("===================");
                        Console.WriteLine($"Issued to {name}");
                    }
                    else
                    {
                        Console.WriteLine($"{name} - {grade:f2}");
                    }
                }              

            }
        }
    }
}
