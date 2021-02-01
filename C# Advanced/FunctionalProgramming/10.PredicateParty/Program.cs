using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandArgs = command.Split();

                string action = commandArgs[0];
                string criteria = commandArgs[1];
                string attribute = commandArgs[2];

                Predicate<string> filterFunc = NameFilter(criteria, attribute);

                if (action == "Remove")
                {
                    guests.RemoveAll(filterFunc);
                }
                else if (action == "Double")
                {
                    List<string> selectedGuests = guests.Where(x => filterFunc(x)).ToList();

                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (selectedGuests.Contains(guests[i]))
                        {
                            guests.Insert(i, guests[i]);
                            i++;
                        }
                    }

                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> NameFilter(string command, string attribute)
        {
            switch (command)
            {
                case "StartsWith":
                    return n => n.StartsWith(attribute);
                case "EndsWith":
                    return n => n.EndsWith(attribute);
                case "Length":
                    int length = int.Parse(attribute);
                    return n => n.Length == length;
                default: return null;
            }
        }
    }
}
