using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> indexes = new List<int>();
            CalculateIndexes(numbers, indexes);

            string text = Console.ReadLine();

            StringBuilder result = new StringBuilder(indexes.Count);

            for (int i = 0; i < indexes.Count; i++)
            {
                int index = indexes[i];

                while (index >= text.Length)
                {
                    index -= text.Length;
                }

                char letter = text[index];
                text = text.Remove(index, 1);

                result.Append(letter.ToString());
            }

            Console.WriteLine(result);

        }

        private static void CalculateIndexes(List<int> numbers, List<int> indexes)
        {
            foreach (int element in numbers)
            {
                int sum = 0;
                int num = element;

                while (num != 0)
                {
                    sum += num % 10;
                    num /= 10;
                }

                indexes.Add(sum);
            }
        }
    }
}
