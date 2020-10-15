using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] boxData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string serialNum = boxData[0];
                string itemName = boxData[1];
                int itemQuantity = int.Parse(boxData[2]);
                double itemPrice = double.Parse(boxData[3]);

                Item currentItem = new Item(itemName, itemPrice);
                Box currentBox = new Box(serialNum, currentItem, itemQuantity);

                boxes.Add(currentBox);
            }

            foreach (Box box in boxes.OrderByDescending(p => p.BoxPrice))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Item()
        {

        }
        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double BoxPrice { get; set; }

        public Box()
        {
            Item item = new Item();
            BoxPrice = ItemQuantity * item.Price;
        }

        public Box(string serialNumber, Item item, int itemQuantity)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            BoxPrice = itemQuantity * item.Price;
        }
    }
}
