using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookTitle = Console.ReadLine();
            int numberOfBooks = int.Parse(Console.ReadLine());

            string currentBookTitle = Console.ReadLine();
            int counter = 0;

            while (currentBookTitle != bookTitle)
            {
                counter++;
                if (counter == numberOfBooks)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    return;
                }

                currentBookTitle = Console.ReadLine();
            }

            Console.WriteLine($"You checked {counter} books and found it.");
        }
    }
}
