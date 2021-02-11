using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 1930, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            List<Book> orderedBooks = new List<Book>
            {
                bookOne,
                bookTwo,
                bookThree
            };

            orderedBooks.Sort();

            foreach (Book book in libraryTwo)
            {
                Console.WriteLine($"{book.Title} {book.Year}");
            }
        }
    }
}
