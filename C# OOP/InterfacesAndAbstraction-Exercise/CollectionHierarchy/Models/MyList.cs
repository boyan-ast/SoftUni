using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private Stack<string> items;

        public MyList()
        {
            this.items = new Stack<string>();
        }

        public int Used => this.items.Count;

        public IReadOnlyCollection<string> Collection => new List<string>(this.items).AsReadOnly();

        public int Add(string item)
        {
            this.items.Push(item);

            return 0;
        }

        public string Remove()
        {
            string element = string.Empty;

            if (this.items.Count > 0)
            {
                element = items.Pop();
            }

            return element;
        }
    }
}
