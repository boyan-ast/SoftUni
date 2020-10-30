using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine()
                .Split("&", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            ManipulateTheBooks(books);

            Console.WriteLine(string.Join(", ", books));
        }

        private static void ManipulateTheBooks(List<string> books)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] tokens = command
                    .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0].Split()[0];

                if (action == "Check")
                {
                    int index = int.Parse(tokens[1]);

                    if (index >= 0 && index < books.Count)
                    {
                        Console.WriteLine(books[index]);
                    }

                    continue;
                }

                string bookName = tokens[1];

                if (action == "Add")
                {
                    if (!books.Contains(bookName))
                    {
                        books.Insert(0, bookName);
                    }
                }
                else if (action == "Take")
                {
                    if (books.Contains(bookName))
                    {
                        books.Remove(bookName);
                    }
                }
                else if (action == "Swap")
                {
                    string secondBook = tokens[2];

                    int firstBookIndex = books.IndexOf(bookName);
                    int secondBookIndex = books.IndexOf(secondBook);

                    if (firstBookIndex != -1 && secondBookIndex != -1)
                    {
                        books[firstBookIndex] = secondBook;
                        books[secondBookIndex] = bookName;
                    }
                }
                else if (action == "Insert")
                {
                    books.Add(bookName);
                }
            }
        }
    }
}
