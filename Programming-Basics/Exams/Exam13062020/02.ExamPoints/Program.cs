using System;
using System.Drawing;

namespace _02.ExamPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int problemNumber = int.Parse(Console.ReadLine());
            int points = int.Parse(Console.ReadLine());
            string course = Console.ReadLine();

            int factor = CalculateTheFactor(problemNumber, course);

            double resultPoints = points * (factor * 1.0 / 100);

            if (course == "Advanced")
            {
                resultPoints *= 1.2;
            }
            else if (course == "Basics" && problemNumber == 1)
            {
                resultPoints *= 0.8;
            }

            Console.WriteLine($"Total points: {resultPoints:f2}");
        }

        private static int CalculateTheFactor(int number, string course)
        {
            if (number == 1)
            {
                if (course == "Basics")
                {
                    return 8;
                }
                else if (course == "Fundamentals")
                {
                    return 11;
                }
                else if (course == "Advanced")
                {
                    return 14;
                }
                else
                {
                    return 0;
                }
            }
            else if (number == 2)
            {

                if (course == "Basics")
                {
                    return 9;
                }
                else if (course == "Fundamentals")
                {
                    return 11;
                }
                else if (course == "Advanced")
                {
                    return 14;
                }
                else
                {
                    return 0;
                }
            }
            else if (number == 3)
            {

                if (course == "Basics")
                {
                    return 9;
                }
                else if (course == "Fundamentals")
                {
                    return 12;
                }
                else if (course == "Advanced")
                {
                    return 15;
                }
                else
                {
                    return 0;
                }
            }
            else if (number == 4)
            {

                if (course == "Basics")
                {
                    return 10;
                }
                else if (course == "Fundamentals")
                {
                    return 13;
                }
                else if (course == "Advanced")
                {
                    return 16;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
