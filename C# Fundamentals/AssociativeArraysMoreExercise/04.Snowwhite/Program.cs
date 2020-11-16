using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                string[] dwarfData = command.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

                string colorPlusName = dwarfData[1] + " " + dwarfData[0];
                int physics = int.Parse(dwarfData[2]);

                if (!dwarfs.ContainsKey(colorPlusName))
                {
                    dwarfs.Add(colorPlusName, physics);
                }
                else
                {
                    if (dwarfs[colorPlusName] < physics)
                    {
                        dwarfs[colorPlusName] = physics;
                    }
                }
            }

            List<Dwarf> allDwarfs = new List<Dwarf>(dwarfs.Count);

            foreach (var kvp in dwarfs)
            {
                string color = kvp.Key.Split()[0];
                string name = kvp.Key.Split()[1];
                int physics = kvp.Value;

                Dwarf dwarf = new Dwarf(color, name, physics);

                if (allDwarfs.FirstOrDefault(x => x.Color == color) != null)
                {
                    foreach (Dwarf item in allDwarfs.Where(x => x.Color == color))
                    {
                        item.ColorCounter++;
                    }

                    dwarf.ColorCounter = allDwarfs.FirstOrDefault(x => x.Color == color).ColorCounter;
                }

                allDwarfs.Add(dwarf);
            }


            foreach (Dwarf dwarf in allDwarfs.OrderByDescending(x => x.Physics)
                .ThenByDescending(x => x.ColorCounter))
            {
                Console.WriteLine(dwarf);
            }

        }
    }

    class Dwarf
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public int Physics { get; set; }
        public int ColorCounter { get; set; }

        public Dwarf(string color, string name, int physics)
        {
            Color = color;
            Name = name;
            Physics = physics;
            ColorCounter = 1;
        }

        public override string ToString()
        {
            return $"({Color}) {Name} <-> {Physics}";
        }
    }
}
