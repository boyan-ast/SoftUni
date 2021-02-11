using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2]);
                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            Person theMan = people[n - 1];

            int equal = 0;
            int notEqual = 0;

            for (int i = 0; i < people.Count; i++)
            {
                Person currentPerson = people[i];

                if (currentPerson.CompareTo(theMan) == 0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }

            if (equal != 1)
            {
                Console.WriteLine($"{equal} {notEqual} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
