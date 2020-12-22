using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularGuests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();

            string guest = string.Empty;

            while ((guest = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(guest[0]))
                {
                    vipGuests.Add(guest);
                }
                else
                {
                    regularGuests.Add(guest);
                }
            }

            while ((guest = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(guest[0]))
                {
                    vipGuests.Remove(guest);
                }
                else
                {
                    regularGuests.Remove(guest);
                }
            }

            vipGuests.UnionWith(regularGuests);

            Console.WriteLine(vipGuests.Count);

            foreach (string person in vipGuests)
            {
                Console.WriteLine(person);
            }
        }
    }
}
