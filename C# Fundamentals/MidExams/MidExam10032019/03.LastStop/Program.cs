using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] instructions = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                FollowTheInstructions(numbers, instructions);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void FollowTheInstructions(List<int> numbers, string[] instructions)
        {
            string action = instructions[0];

            if (action == "Change")
            {
                int currentNumber = int.Parse(instructions[1]);
                int newNumber = int.Parse(instructions[2]);

                if (numbers.Contains(currentNumber))
                {
                    numbers[numbers.IndexOf(currentNumber)] = newNumber;
                }
            }
            else if (action == "Hide")
            {
                int paintingNumber = int.Parse(instructions[1]);

                numbers.Remove(paintingNumber);
            }
            else if (action == "Switch")
            {
                int firstNumber = int.Parse(instructions[1]);
                int secondNumber = int.Parse(instructions[2]);

                int firstIndex = numbers.IndexOf(firstNumber);
                int secondIndex = numbers.IndexOf(secondNumber);

                if (firstIndex != -1 && secondIndex != -1)
                {
                    numbers[firstIndex] = secondNumber;
                    numbers[secondIndex] = firstNumber;
                }
            }
            else if (action == "Insert")
            {
                int newIndex = int.Parse(instructions[1]) + 1;
                int paintingNumber = int.Parse(instructions[2]);

                if (newIndex > 0 && newIndex <= numbers.Count)
                {
                    numbers.Insert(newIndex, paintingNumber);
                }
            }
            else if (action == "Reverse")
            {
                numbers.Reverse();
            }
        }
    }
}
