using System;

namespace ImplementingCustomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomList<int> myList = new CustomList<int>();

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

            CustomList<string> stringsList = new CustomList<string>();

            stringsList.Add("Lokomotiv");
            stringsList.Add("Yantra");
            stringsList.Add("Beroe");

            PrintList(stringsList);


        }

        private static void PrintList<T>(CustomList<T> myList)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
