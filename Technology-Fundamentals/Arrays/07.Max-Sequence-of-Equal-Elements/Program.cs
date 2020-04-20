using System;
using System.Linq;

namespace _07.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int maxCount = 0;
            int bestNum = elements[0];
            int count = 0;

            for (int i = 0; i < elements.Length; i += count)
            {
                int num = elements[i];

                count = 1;

                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (num == elements[j])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    bestNum = num;
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write($"{bestNum} ");
            }

        }
    }
}
