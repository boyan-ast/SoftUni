using System;

namespace ImplementingCustomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i * 10);
            }

            Console.WriteLine(list.RemoveAt(1));

            list.Insert(9, 999);
            list.Insert(4, 123);
            list.Insert(3, 345);
            list.Swap(1, 3);
            list.Swap(1, 1);

            Console.WriteLine(list);
        }
    }
}
