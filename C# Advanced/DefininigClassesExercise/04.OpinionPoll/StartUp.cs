using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person person = new Person(name, age);
                people[i] = person;
            }

            Person[] selectedPeople = people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToArray();

            foreach (Person person in selectedPeople)
            {
                Console.WriteLine(person);
            }
        }
    }
}
