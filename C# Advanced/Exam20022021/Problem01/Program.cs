using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            string orcsLeft = string.Empty;

            bool orcsWin = false;

            //Stack<int> orcs = new Stack<int>();

            bool samePlate = false;
            int currentPlate = 0;

            for (int i = 1; i <= waves; i++)
            {
                Stack<int> orcs = new Stack<int>(
                        Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse));

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(extraPlate);
                }                

                while (plates.Count > 0 && orcs.Count > 0)
                {
                    if (!samePlate)
                    {
                        currentPlate = plates.Dequeue();
                    }

                    int currentOrc = orcs.Pop();

                    if (currentOrc >= currentPlate)
                    {
                        currentOrc -= currentPlate;

                        samePlate = false;

                        if (currentOrc > 0)
                        {
                            orcs.Push(currentOrc);
                        }
                    }
                    else
                    {
                        currentPlate -= currentOrc;
                        samePlate = true;
                    }
                }

                if (plates.Count == 0 && !orcsWin)
                {
                    orcsWin = true;
                    orcsLeft = string.Join(", ", orcs);
                    //Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                    //Console.WriteLine($"Orcs left: " + string.Join(", ", orcs));                    
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
