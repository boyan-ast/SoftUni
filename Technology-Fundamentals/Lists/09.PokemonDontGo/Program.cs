using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDontGo
{
    class Program
    {
        public static int allRemovedElementsSum = 0;

        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToList();

            while (sequence.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                RemoveElement(sequence, index);
            }

            Console.WriteLine(allRemovedElementsSum);
        }

        private static void RemoveElement(List<int> sequence, int index)
        {
            int elementValue = 0;

            if (index < 0)
            {
                elementValue = sequence[0];
                sequence.RemoveAt(0);
                sequence.Insert(0, sequence[sequence.Count - 1]);
            }
            else if (index >= sequence.Count)
            {
                elementValue = sequence[sequence.Count - 1];
                sequence.RemoveAt(sequence.Count - 1);
                sequence.Add(sequence[0]);
            }
            else
            {
                elementValue = sequence[index];
                sequence.RemoveAt(index);
            }

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] <= elementValue)
                {
                    sequence[i] += elementValue;
                }
                else
                {
                    sequence[i] -= elementValue;
                }
            }

            allRemovedElementsSum += elementValue;
        }
    }
}