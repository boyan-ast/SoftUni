using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int wreaths = 0;
            int flowersLeft = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int currentLily = lilies.Pop();
                int currentRose = roses.Dequeue();

                int sum = currentLily + currentRose;

                while (sum > 15)
                {
                    sum -= 2;
                }

                if (sum == 15)
                {
                    wreaths++;
                }
                else if (sum < 15)
                {
                    flowersLeft += sum;
                }
            }

            int additionalWreaths = flowersLeft / 15;

            wreaths += additionalWreaths;

            Console.WriteLine(wreaths >= 5 ?
                $"You made it, you are going to the competition with {wreaths} wreaths!" :
                $"You didn't make it, you need {5 - wreaths} wreaths more!");
        }
    }
}
