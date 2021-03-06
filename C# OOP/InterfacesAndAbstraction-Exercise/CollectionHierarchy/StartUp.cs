using CollectionHierarchy.Contracts;
using CollectionHierarchy.Models;
using System;
using System.Text;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int count = int.Parse(Console.ReadLine());

            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            Console.WriteLine(PrintAddIndexes(addCollection, input));
            Console.WriteLine(PrintAddIndexes(addRemoveCollection, input));
            Console.WriteLine(PrintAddIndexes(myList, input));

            Console.WriteLine(PrintRemovedElements(addRemoveCollection, count));
            Console.WriteLine(PrintRemovedElements(myList, count));
        }

        static string PrintRemovedElements(IAddRemoveCollection collection, int count)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                sb.Append($"{collection.Remove()} ");
            }

            return sb.ToString().TrimEnd();
        }

        static string PrintAddIndexes(IAddCollection collection, string[] input)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in input)
            {
                sb.Append($"{collection.Add(item)} ");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
