using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int moves = 0;
            bool hasWon = false;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                if (elements.Count == 0)
                {
                    continue;
                }

                int[] indexes = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                moves++;

                int firstIndex = indexes[0];
                int secondIndex = indexes[1];

                if ((firstIndex == secondIndex
                    || firstIndex < 0 || firstIndex >= elements.Count
                    || secondIndex < 0 || secondIndex >= elements.Count))
                {
                    string newElement = "-" + moves + "a";
                    elements.InsertRange(elements.Count / 2, new string[] { newElement, newElement });

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else if (elements[firstIndex] == elements[secondIndex])
                {
                    string matchingElement = elements[firstIndex];
                    Console.WriteLine($"Congrats! You have found matching elements - {matchingElement}!");
                    elements.RemoveAll(e => e == matchingElement);
                    if (elements.Count == 0)
                    {
                        Console.WriteLine($"You have won in {moves} turns!");
                        hasWon = true;
                    }
                }
                else if (elements[firstIndex] != elements[secondIndex])
                {
                    Console.WriteLine("Try again!");
                }

            }

            if (!hasWon)
            {
                Console.WriteLine($"Sorry you lose :(");
                Console.WriteLine(string.Join(" ", elements));
            }
        }
    }
}
