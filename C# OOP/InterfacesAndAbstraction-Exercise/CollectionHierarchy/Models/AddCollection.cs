using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private List<string> items;

        public AddCollection()
        {
            this.items = new List<string>();
        }

        public IReadOnlyCollection<string> Collection => this.items.AsReadOnly();

        public int Add(string item)
        {
            this.items.Add(item);

            return this.items.Count - 1;
        }
    }
}
