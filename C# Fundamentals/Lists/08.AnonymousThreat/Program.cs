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

            if (partitions == 0)
            {
                return;
            }

            string element = data[index];
            int position = index;

            data.RemoveAt(index);

            int newElementLength = element.Length / partitions;
            //int lastNewElementLength = (element.Length / 3) + (element.Length % 3);

            StringBuilder newElement = new StringBuilder();

            newElement.Append(element[0].ToString());

            for (int i = 1; i < element.Length; i++)
            {
                if (i % newElementLength == 0 && partitions > 1)
                {
                    data.Insert(position, newElement.ToString());
                    position++;
                    partitions--;

                    newElement.Length = 0;

                    if (partitions == 1)
                    {
                        string lastNewElement = element.Substring(i);
                        data.Insert(position, lastNewElement);
                    }
                    else
                    {
                        newElement.Append(element[i]);

                    }
                }
                else
                {
                    newElement.Append(element[i]);
                }
            }
        }

        private static void MergeElements(List<string> data, int start, int end)
        {
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
