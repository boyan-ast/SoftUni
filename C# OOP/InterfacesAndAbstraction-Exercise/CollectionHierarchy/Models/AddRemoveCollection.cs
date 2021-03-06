using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private const int AddIndex = 0;

        private List<string> items;

        public AddRemoveCollection()
        {
            this.items = new List<string>();
        }

        public IReadOnlyCollection<string> Collection => this.items.AsReadOnly();

        public int Add(string item)
        {
            this.items.Insert(AddIndex, item);

            return AddIndex;
        }

        public string Remove()
        {
            string element = string.Empty; 

            if (this.items.Count > 0)
            {
                element = this.items[this.items.Count - 1];

                this.items.RemoveAt(this.items.Count - 1);
            }

            return element;
        }
    }
}
