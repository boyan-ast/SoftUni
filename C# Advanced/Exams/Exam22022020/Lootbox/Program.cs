using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int totalSum = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstNum = firstBox.Peek();
                int secondNum = secondBox.Pop();

                int sum = firstNum + secondNum;

                if (sum % 2 == 0)
                {
                    totalSum += sum;
                    firstBox.Dequeue();
                }
                else
                {
                    firstBox.Enqueue(secondNum);
                }
            }

            Console.WriteLine(firstBox.Count == 0 ?
                "First lootbox is empty" :
                "Second lootbox is empty");

            Console.WriteLine(totalSum >= 100 ?
                $"Your loot was epic! Value: {totalSum}" :
                $"Your loot was poor... Value: {totalSum}");
        }
    }
}
