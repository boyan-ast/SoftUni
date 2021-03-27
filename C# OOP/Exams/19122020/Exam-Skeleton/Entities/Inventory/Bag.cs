using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private ICollection<Item> items;

        public Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity 
        { 
            get => this.capacity; 
            set { this.capacity = value; }
        }

        public int Load
        {
            get => this.CalculateLoad();  
        }

        public IReadOnlyCollection<Item> Items => this.items.ToList().AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            //bool exists = false;
            Item selectedItem = null;

            foreach (Item item in items)
            {
                if (item.GetType().Name == name)
                {
                    selectedItem = item;
                    break;
                }
            }

            if (selectedItem == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(selectedItem);

            return selectedItem;
        }

        private int CalculateLoad()
        {
            int sum = 0;

            foreach (Item item in this.items)
            {
                sum += item.Weight;
            }

            return sum;
        }
    }
}
