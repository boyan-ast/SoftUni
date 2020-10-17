using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                ModifyTheArray(numbers, commandArgs);
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void ModifyTheArray(int[] numbers, string[] commandArgs)
        {
            string action = commandArgs[0];
            int firstIndex = -1;
            int secondIndex = -1;

            switch (action)
            {
                case "swap":
                    firstIndex = int.Parse(commandArgs[1]);
                    secondIndex = int.Parse(commandArgs[2]);

                    int temp = numbers[firstIndex];
                    numbers[firstIndex] = numbers[secondIndex];
                    numbers[secondIndex] = temp;

                    break;
                case "multiply":
                    firstIndex = int.Parse(commandArgs[1]);
                    secondIndex = int.Parse(commandArgs[2]);

                    numbers[firstIndex] *= numbers[secondIndex];
                    break;
                case "decrease":
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] -= 1;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
