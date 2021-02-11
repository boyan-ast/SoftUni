using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books, new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book> 
        {
            private int index = -1;
            private readonly List<Book> items;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                items = new List<Book>(books);
            }

            public Book Current => items[index];

            object IEnumerator.Current => items[index];

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return ++index < items.Count;
            }

            public void Reset()
            {
                index = -1;
            }
        }

    }
}


