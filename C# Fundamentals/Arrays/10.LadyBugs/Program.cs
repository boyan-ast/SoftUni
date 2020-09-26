using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] field = new int[fieldSize];

            int[] initialIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => (x >= 0 && x < fieldSize))
                .ToArray();

            for (int i = 0; i < initialIndexes.Length; i++)
            {
                field[initialIndexes[i]] = 1;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] instructions = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int startIndex = int.Parse(instructions[0]);
                string direction = instructions[1];
                int flightLength = int.Parse(instructions[2]);

                Fly(field, direction, startIndex, flightLength);

            }
            Console.WriteLine(string.Join(" ", field));
        }

        private static void Fly(int[] field, string direction, int startIndex, int flightLength)
        {

            int endIndex = -1;

            if (direction == "left")
            {
                endIndex = startIndex - flightLength;
            }
            else if (direction == "right")
            {
                endIndex = startIndex + flightLength;
            }
            else
            {
                return;
            }

            bool isNotValid = startIndex < 0 || startIndex >= field.Length || field[startIndex] == 0;

            if (isNotValid)
            {
                return;
            }
            else
            {
                field[startIndex] = 0;
            }

            if (endIndex < 0 || endIndex >= field.Length)
            {
                return;
            }

            if (field[endIndex] == 0)
            {
                field[endIndex] = 1;
            }
            else
            {
                if (direction == "left")
                {
                    endIndex = endIndex - flightLength;

                    while (endIndex >= 0 && endIndex < field.Length)
                    {
                        if (field[endIndex] == 0)
                        {
                            field[endIndex] = 1;
                            break;
                        }

                        endIndex -= flightLength;
                    }
                }
                else if (direction == "right")
                {
                    endIndex = endIndex + flightLength;

                    while (endIndex >= 0 && endIndex < field.Length)
                    {
                        if (field[endIndex] == 0)
                        {
                            field[endIndex] = 1;
                            break;
                        }

                        endIndex += flightLength;
                    }
                }
            }
        }
    }
}
