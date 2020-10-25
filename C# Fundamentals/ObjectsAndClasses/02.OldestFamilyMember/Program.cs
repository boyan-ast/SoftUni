using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(personData[0], int.Parse(personData[1]));
                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    class Family
    {
        public List<Person> Members { get; set; }
        
        public Family()
        {
            Members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            Members.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = Members.OrderByDescending(x => x.Age).ToList().First();
            return oldestMember;
        }
    }
}
