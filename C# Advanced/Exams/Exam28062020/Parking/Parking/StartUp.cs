using System;

namespace Parking
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car first = new Car("VW", "Golf", 2003);
            Car second = new Car("Renault", "Megane", 2010);
            Car third = new Car("Ford", "Mustang", 1967);

            Parking parking = new Parking("Open Parking", 4);

            parking.Add(first);
            parking.Add(second);
            parking.Add(third);

            Console.WriteLine(parking.Remove("Dacia", "Logan"));
            Console.WriteLine(parking.Remove("Ford", "Mustang"));

            Console.WriteLine(parking.GetLatestCar());

            Console.WriteLine(parking.Count);

            Console.WriteLine(parking.GetStatistics());
        }
    }
}
