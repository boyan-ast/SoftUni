using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Func<string, bool>> filters = new Dictionary<string, Func<string, bool>>();

            string[] names = Console.ReadLine().Split();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Print")
            {
                string[] commandArgs = command.Split(";");
                string action = commandArgs[0];
                string type = commandArgs[1];
                string parameter = commandArgs[2];
                string filterName = string.Empty;

                string[] typeToName = type.Split();

                if (typeToName.Length == 2)
                {
                    filterName = $"{typeToName[0]}{typeToName[1]}{parameter}";
                }
                else
                {
                    filterName = $"{typeToName[0]}{parameter}";
                }

                Func<string, bool> newfilter = FilterCreator(type, parameter);

                if (action == "Add filter")
                {
                    filters.Add(filterName, newfilter);
                }
                else if (action == "Remove filter")
                {
                    filters.Remove(filterName);
                }
            }

            foreach (var filter in filters)
            {
                Func<string, bool> currentFilter = filter.Value;
                names = names.Where(currentFilter).ToArray();
            }

            Console.WriteLine(string.Join(" ", names));

        }

        static Func<string, bool> FilterCreator(string filterType, string parameter)
        {
            switch (filterType)
            {
                case "Starts with": return f => !f.StartsWith(parameter);
                case "Ends with": return f => !f.EndsWith(parameter);
                case "Length":
                    int length = int.Parse(parameter);
                    return f => f.Length != length;
                case "Contains": return f => !f.Contains(parameter);
                default: return null;
            }
        }
    }
}
