using System;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            string train = string.Empty;
            int totalPeople = 0;

            for (int i = 0; i < wagons; i++)
            {
                int people = int.Parse(Console.ReadLine());

                train += people + " ";
                totalPeople += people;
            }

            Console.WriteLine(train.Trim());
            Console.WriteLine(totalPeople);
        }
    }
}
