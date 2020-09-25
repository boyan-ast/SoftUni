using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int maxCount = 1;
            int maxCountElement = elements[0];
            int count = 1;

            for (int i = 0; i < elements.Length - 1; i++)
            {
                if (elements[i] == elements[i+1])
                {
                    count++;

                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxCountElement = elements[i];                        
                    }
                }
                else
                {
                    count = 1;
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(maxCountElement + " ");
            }
        }
    }
}
