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
            List<string> data = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "3:1")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    MergeElements(data, startIndex, endIndex);
                }
                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);
                    DivideElements(data, index, partitions);
                }
            }

            Console.WriteLine(string.Join(" ", data));
        }

        private static void DivideElements(List<string> data, int index, int partitions)
        {

            if (index < 0 || index >= data.Count)
            {
                return;
            }

            if (partitions == 0 || data[index].Length / partitions == 0)
            {
                return;
            }

            string element = data[index];
            int partitionLength = element.Length / partitions;
            StringBuilder dividedElement = new StringBuilder();

            for (int i = 0; i < element.Length; i++)
            {
                if (i % partitionLength == 0 && i > 0)
                {
                    dividedElement.Append(" ");
                    partitions--;

                    if (partitions == 1)
                    {
                        string lastDividedElement = element.Substring(i);
                        dividedElement.Append(lastDividedElement);
                        break;
                    }
                }
                dividedElement.Append(element[i].ToString());
            }

            data.RemoveAt(index);
            List<string> elementParts = dividedElement.ToString().Split(" ").ToList();

            for (int i = elementParts.Count - 1; i >= 0; i--)
            {
                data.Insert(index, elementParts[i]);
            }
        }

        private static void MergeElements(List<string> data, int start, int end)
        {
            if (start >= data.Count)
            {
                return;
            }

            if (start < 0)
            {
                start = 0;
            }
            if (end >= data.Count)
            {
                end = data.Count - 1;
            }

            StringBuilder mergedElement = new StringBuilder();

            for (int i = start; i <= end; i++)
            {
                mergedElement.Append(data[start]);
                data.RemoveAt(start);
            }

            data.Insert(start, mergedElement.ToString());
        }
    }
}
