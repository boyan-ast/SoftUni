using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family theFamily = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personalData = Console.ReadLine().Split();
                theFamily.AddMember(new Person(personalData[0], int.Parse(personalData[1])));
            }

            Person oldestPerson = theFamily.GetOldestMember();

            if (oldestPerson != null)
            {
                Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
            }
        }
    }
}
