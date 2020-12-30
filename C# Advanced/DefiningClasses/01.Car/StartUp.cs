using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(2018, 1.4),
                new Tire(2018, 1.4),
                new Tire(2018, 1.4),
                new Tire(2018, 1.4)
            };

            Engine engine = new Engine(90, 1.6);

            Car car = new Car("Ford", "Focus", 2007, 60, 4.2, engine, tires);
         }
    }
}
