using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            int count = 0;

            string input = Console.ReadLine();
            int distance = 0;

            bool hasFailed = false;

            while (int.TryParse(input, out distance))
            {
                if (energy - distance < 0)
                { 
                    hasFailed = true;
                    break;
                }
                else
                {
                    energy -= distance;
                    count++;

                    if (count % 3 == 0)
                    {
                        energy += count;
                    }
                }
                input = Console.ReadLine();
            }

            if (hasFailed)
            {
                Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {energy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {count}. Energy left: {energy}");
            }

        }
    }
}
