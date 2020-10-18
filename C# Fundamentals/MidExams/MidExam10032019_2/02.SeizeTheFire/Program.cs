using System;
using System.Collections.Generic;

namespace _02.SeizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fireLevels = Console.ReadLine().Split("#", StringSplitOptions.RemoveEmptyEntries);
            int water = int.Parse(Console.ReadLine());

            List<int> waterCells = new List<int>(fireLevels.Length);

            double totalEffort = 0;
            int totalFire = 0;

            foreach (string fire in fireLevels)
            {
                string[] fireInfo = fire.Split(" = ");
                string type = fireInfo[0];
                int value = int.Parse(fireInfo[1]);

                if (((type == "High") && (value >= 81 && value <= 125) && ((water - value) >= 0)) ||
                    ((type == "Medium") && (value >= 51 && value <= 80) && ((water - value) >= 0)) ||
                    ((type == "Low") && (value >= 1 && value <= 50) && ((water - value) >= 0)))
                {
                    water -= value;
                    totalEffort += 0.25 * value;
                    totalFire += value;
                    waterCells.Add(value);
                }
            }


            Console.WriteLine("Cells:");
            foreach (int cell in waterCells)
            {
                Console.WriteLine($"- {cell}");
            }
            Console.WriteLine($"Effort: {totalEffort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
