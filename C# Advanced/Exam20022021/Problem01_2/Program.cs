using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem01_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            bool orcsWin = false;
            string orcsLeft = string.Empty;

            for (int i = 1; i <= waves; i++)
            {
                Stack<int> orcs = new Stack<int>(
                        Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse));

                if (orcsWin)
                {
                    continue;
                }

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    plates.Add(extraPlate);
                }                

                while (true)
                {
                    int currentOrc = orcs.Pop();
                    int currentPlate = plates[0];

                    if (currentOrc > currentPlate)
                    {
                        currentOrc -= currentPlate;
                        orcs.Push(currentOrc);

                        plates.RemoveAt(0);
                    }
                    else if (currentOrc == currentPlate)
                    {
                        plates.RemoveAt(0);
                    }
                    else
                    {
                        plates[0] -= currentOrc;
                    }

                    if (orcs.Count == 0)
                    {
                        break;
                    }

                    if (plates.Count == 0)
                    {
                        orcsWin = true;
                        orcsLeft = string.Join(", ", orcs);
                        break;
                    }
                }
                
            }


            if (orcsWin)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: " + orcsLeft);
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine("Plates left: " + string.Join(", ", plates));
            }
        }
    }
}
