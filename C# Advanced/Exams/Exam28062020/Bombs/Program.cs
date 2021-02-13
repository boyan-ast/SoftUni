using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> casings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> bombs = new Dictionary<string, int>
            {
                { "Cherry Bombs", 0 },
                { "Datura Bombs", 0 },
                { "Smoke Decoy Bombs", 0}
            };

            bool isComplete = false;

            while (effects.Count > 0 && casings.Count > 0)
            {
                int effect = effects.Peek();
                int casing = casings.Pop();

                int sum = effect + casing;

                string bomb = string.Empty;
                bool isSuccessful = false;

                if (sum == 40)
                {
                    bomb = "Datura Bombs";
                    isSuccessful = true;
                }
                else if (sum == 60)
                {
                    bomb = "Cherry Bombs";
                    isSuccessful = true;
                }
                else if (sum == 120)
                {
                    bomb = "Smoke Decoy Bombs";
                    isSuccessful = true;
                }
                else
                {
                    casings.Push(casing - 5);
                }

                if (isSuccessful)
                {
                    effects.Dequeue();
                    bombs[bomb]++;

                    if (bombs.Min(b => b.Value) == 3)
                    {
                        isComplete = true;
                        break;
                    }
                }
            }

            if (isComplete)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            Console.Write($"Bomb Effects: ");
            Console.WriteLine(effects.Count == 0 ? "empty" : string.Join(", ", effects));

            Console.Write($"Bomb Casings: ");
            Console.WriteLine(casings.Count == 0 ? "empty" : string.Join(", ", casings));

            foreach(var bomb in bombs)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
