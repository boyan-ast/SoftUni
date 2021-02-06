using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<double>[] boxes = new Box<double>[n]; 

            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));

                boxes[i] = box;
            }

            Box<double> element = new Box<double>(double.Parse(Console.ReadLine()));            

            Console.WriteLine(Compare(boxes, element));
        }

        static int Compare<T>(T[] items, T element) where T : IComparable<T>
        {
            int count = 0;

            for (int i = 0; i < items.Length; i++)
            {
                if (element.CompareTo(items[i]) < 0)
                {
                    count++;
                }
            }

            return count;
        }

        static void Swap<T>(T[] items, int firstIndex, int secondIndex)
        {
            T temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
    }
}
