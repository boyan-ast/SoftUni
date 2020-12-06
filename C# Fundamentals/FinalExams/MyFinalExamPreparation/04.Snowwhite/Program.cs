using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> allDwarfs = new List<Dwarf>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                string[] dwarfData = command
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

                string name = dwarfData[0];
                string hatColor = dwarfData[1];
                int physics = int.Parse(dwarfData[2]);

                Dwarf existingDwarf = allDwarfs.FirstOrDefault(x => x.Name == name && x.HatColor == hatColor);

                if (existingDwarf != null && existingDwarf.Physics < physics)
                {
                    existingDwarf.Physics = physics;
                }
                else if (existingDwarf == null)
                {
                    Dwarf newDwarf = new Dwarf(name, hatColor, physics);
                    allDwarfs.Add(newDwarf);
                }
            }

            List<Dwarf> orderedDwarfs = allDwarfs
                .OrderByDescending(x => x.Physics)
                .ThenByDescending
                (x =>
                {
                    string currentColor = x.HatColor;
                    int count = 0;
                    foreach (Dwarf dwarf in allDwarfs)
                    {
                        if (dwarf.HatColor == currentColor)
                        {
                            count++;
                        }
                    }
                    return count;
                }
                )
                .ToList();

            foreach (Dwarf dwarf in orderedDwarfs)
            {
                Console.WriteLine(dwarf);
            }
        }
    }

    class Dwarf
    {
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }

        public Dwarf(string name, string hatColor, int physics)
        {
            Name = name;
            HatColor = hatColor;
            Physics = physics;
        }

        public override string ToString()
        {
            return $"({HatColor}) {Name} <-> {Physics}";
        }
    }
}
