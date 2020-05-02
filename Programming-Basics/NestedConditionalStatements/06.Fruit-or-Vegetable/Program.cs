using System;
using System.Linq;

namespace _06.Fruit_or_Vegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            string[] fruits = { "banana", "apple", "kiwi", "cherry", "lemon", "grapes" };
            string[] vegetables = { "tomato", "cucumber", "pepper", "carrot" };

            if (fruits.Contains(product))
            {
                Console.WriteLine("fruit");
            }
            else if (vegetables.Contains(product))
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
