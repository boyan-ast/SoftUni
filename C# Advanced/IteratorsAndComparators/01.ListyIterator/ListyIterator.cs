using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> elements;
        private int index = 0;

        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
        }

        public bool Move()
        {
            return ++index < elements.Count;
        }

        public bool HasNext()
        {
            return index < elements.Count;
        }

        public void Print()
        {
            if (elements.Count == 0 || !HasNext())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(elements[index]);
        }
    }
}
