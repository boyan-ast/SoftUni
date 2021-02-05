using System;

namespace ImplementingCustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftUniList myList = new SoftUniList();

            myList.Add(10);
            myList.Add(20);
            myList.Add(30);
            myList.Add(40);
            myList.Add(50);
            myList.Add(60);
            myList.Add(70);
            myList.Add(80);
            myList.Add(90);

            PrintList(myList);

            Console.WriteLine(myList.RemoveAt(0)); 
            PrintList(myList);
            myList.RemoveAt(0);
            PrintList(myList);
            myList.RemoveAt(0);
            PrintList(myList);
            myList.RemoveAt(0);
            PrintList(myList);

            Console.WriteLine(myList.Contains(10)); 
            Console.WriteLine(myList.Contains(90));

            myList.InsertAt(2, 99);
            PrintList(myList);

            myList.InsertAt(6, 77);
            PrintList(myList);
            Console.WriteLine(myList.Count);

            myList.Swap(0, myList.Count - 1);
            PrintList(myList);
        }

        private static void PrintList(SoftUniList myList)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
