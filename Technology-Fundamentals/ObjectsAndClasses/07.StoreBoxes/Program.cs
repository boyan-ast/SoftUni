using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> allBoxes = new List<Box>();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] boxData = command.Split();

                int serialNumber = int.Parse(boxData[0]);
                string itemName = boxData[1];
                int itemQuantity = int.Parse(boxData[2]);
                double itemPrice = double.Parse(boxData[3]);

                double boxPrice = itemQuantity * itemPrice;

                Box box = new Box();
                box.SerailNumber = serialNumber;
                box.Item.Name = itemName;
                box.Item.Price = itemPrice;
                box.ItemQuantity = itemQuantity;
                box.BoxPrice = boxPrice;

                allBoxes.Add(box);
            }

            foreach (Box box in allBoxes.OrderByDescending(x => x.BoxPrice))
            {
                Console.WriteLine(box.SerailNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");
            }
        }

        class Item
        {
            private string name;
            private double price;

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public double Price
            {
                get { return this.price; }
                set { this.price = value; }
            }
        }
        class Box
        {
            public int SerailNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }
            public double BoxPrice { get; set; }

            public Box()
            {
                Item = new Item();
            }
        }

    }
}
