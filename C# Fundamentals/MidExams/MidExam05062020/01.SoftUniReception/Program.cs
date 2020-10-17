using System;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());

            int totalEfficiency = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;

            int students = int.Parse(Console.ReadLine());

            int hours = 0;

            while (students > 0)
            {
                hours++;

                if (hours % 4 == 0)
                {
                    continue;
                }

                students -= totalEfficiency;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
