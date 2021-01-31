using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> allCars = new List<Car>(n);

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double firstTirePressure = double.Parse(carInfo[5]);
                int firstTireAge = int.Parse(carInfo[6]);
                double secondTirePressure = double.Parse(carInfo[7]);
                int secondTireAge = int.Parse(carInfo[8]);
                double thirdTirePressure = double.Parse(carInfo[9]);
                int thirdTireAge = int.Parse(carInfo[10]);
                double fourthTirePressure = double.Parse(carInfo[11]);
                int fourthTireAge = int.Parse(carInfo[12]);

                Engine carEngine = new Engine(engineSpeed, enginePower);
                Cargo carCargo = new Cargo(cargoWeight, cargoType);

                Tire[] carTires = new Tire[]
                {
                    new Tire(firstTirePressure, firstTireAge),
                    new Tire(secondTirePressure, secondTireAge),
                    new Tire(thirdTirePressure, thirdTireAge),
                    new Tire(fourthTirePressure, fourthTireAge)
                };

                Car car = new Car(model, carEngine, carCargo, carTires);

                allCars.Add(car);
            }

            string command = Console.ReadLine();

            Func<Car, bool> filter = FilterCars(command);

            List<Car> selectedCars = allCars.Where(filter).ToList();

            foreach (Car car in selectedCars)
            {
                Console.WriteLine(car.Model);
            }
        }

        private static Func<Car, bool> FilterCars(string command)
        {
            if (command == "fragile")
            {
                return c => (
                c.Cargo.Type == "fragile" &&
                (c.Tires.Min(t => t.Pressure) < 1));
            }
            else if (command == "flamable")
            {
                return c => (c.Cargo.Type == "flamable" 
                && c.Engine.Power > 250);
            }

            return null;
        }
    }
}
