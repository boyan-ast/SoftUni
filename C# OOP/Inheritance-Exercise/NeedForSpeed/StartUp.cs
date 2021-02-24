using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car(101, 55);

            car.Drive(100);

            Console.WriteLine(car.Fuel);

            RaceMotorcycle mator = new RaceMotorcycle(200, 50);

            mator.Drive(100);

            Console.WriteLine(mator.Fuel);

        }
    }
}
