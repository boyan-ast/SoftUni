using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "merge")
                {
                    MergeElements(strings, tokens);
                }
                else if (tokens[0] == "divide")
                {
                    DivideElemenents(strings, tokens);
                }
            }

            Console.WriteLine(string.Join(" ", strings));
        }

        private static void DivideElemenents(List<string> strings, string[] tokens)
        {
            int index = int.Parse(tokens[1]);
            int partitions = int.Parse(tokens[2]);
            string element = strings[index];
            strings.RemoveAt(index);

            List<string> newElements = new List<string>(partitions);
            int partitionLength = element.Length / partitions;
            StringBuilder allNewElementsInStr = new StringBuilder();

            for (int i = 0; i < element.Length; i++)
            {
                allNewElementsInStr.Append(element[i]);
                if (((i + 1) % partitionLength == 0) & partitions > 1)
                {
                    allNewElementsInStr.Append(" ");
                    partitions--;
                }
            }

            newElements = allNewElementsInStr.ToString().Split(" ").ToList();
            strings.InsertRange(index, newElements);
        }

        private static void MergeElements(List<string> strings, string[] tokens)
        {
            int startIndex = int.Parse(tokens[1]);
            int endIndex = int.Parse(tokens[2]);

            if (startIndex < 0 || startIndex >= strings.Count)
            {
                startIndex = 0;
            }
            if (endIndex >= strings.Count)
            {
                endIndex = strings.Count - 1;
            }

            StringBuilder newElement = new StringBuilder();

            for (int i = 0; i <= (endIndex - startIndex); i++)
            {
                newElement.Append(strings[startIndex]);
                strings.RemoveAt(startIndex);
            }

            strings.Insert(startIndex, newElement.ToString());
        }
    }
}