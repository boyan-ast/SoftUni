using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList myList = new RandomList();

            myList.Add("Yantra");
            myList.Add("Tryavna");
            myList.Add("Vidima");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(myList.RandomString());
            }
        }
    }
}
