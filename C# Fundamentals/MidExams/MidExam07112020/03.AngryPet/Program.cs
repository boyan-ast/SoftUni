using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.AngryPet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ratings = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int entryIndex = int.Parse(Console.ReadLine());
            string itemsType = Console.ReadLine();
            string priceType = Console.ReadLine();

            int entryItemValue = ratings[entryIndex];

            List<int> leftRatings = new List<int>();

            for (int i = 0; i < entryIndex; i++)
            {
                leftRatings.Add(ratings[i]);
            }
            
            double leftSum = CalculateSum(leftRatings, itemsType, priceType, entryItemValue);

            List<int> rightRatings = new List<int>();

            for (int i = entryIndex + 1; i < ratings.Length; i++)
            {
                rightRatings.Add(ratings[i]);
            }

            double rightSum = CalculateSum(rightRatings, itemsType, priceType, entryItemValue);

            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }
        }

        private static double CalculateSum(List<int> ratings, string itemsType, string priceType, int entryItemValue)
        {
            int sum = 0;

            if (itemsType == "cheap")
            {
                List<int> cheapItems = ratings.Where(x => x < entryItemValue).ToList();

                List<int> selectedItems = new List<int>();

                if (priceType == "positive")
                {
                    selectedItems = cheapItems.Where(x => x > 0).ToList();
                }
                else if (priceType == "negative")
                {
                    selectedItems = cheapItems.Where(x => x < 0).ToList();
                }
                else if (priceType == "all")
                {
                    selectedItems = cheapItems;
                }

                sum = selectedItems.Sum();
            }
            else if (itemsType == "expensive")
            {
                List<int> expensiceItems = ratings.Where(x => x >= entryItemValue).ToList();

                List<int> selectedItems = new List<int>();

                if (priceType == "positive")
                {
                    selectedItems = expensiceItems.Where(x => x > 0).ToList();
                }
                else if (priceType == "negative")
                {
                    selectedItems = expensiceItems.Where(x => x < 0).ToList();
                }
                else if (priceType == "all")
                {
                    selectedItems = expensiceItems;
                }

                sum = selectedItems.Sum();
            }

            return sum;
        }
    }
}
