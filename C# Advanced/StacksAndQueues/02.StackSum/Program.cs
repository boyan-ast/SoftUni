using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string command = string.Empty;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandArgs = command.Split();

                string action = commandArgs[0];

                if (action == "add")
                {
                    int firstNum = int.Parse(commandArgs[1]);
                    int secondNum = int.Parse(commandArgs[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (action == "remove")
                {
                    int count = int.Parse(commandArgs[1]);

                    if (count > 0 && count <= stack.Count)
                    {
                        while (count > 0)
                        {
                            stack.Pop();
                            count--;
                        }
                    }                    
                }
            }

            int sum = stack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
