using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] tireInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] currentTires = new Tire[4];

                int tireIndex = 0;

                for (int i = 1; i < tireInfo.Length; i += 2)
                {
                    Tire tire = new Tire(int.Parse(tireInfo[i - 1]), double.Parse(tireInfo[i]));
                    currentTires[tireIndex] = tire;
                    tireIndex++;
                }

                tires.Add(currentTires);
            }

            List<Engine> engines = new List<Engine>();

            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                engines.Add(new Engine(int.Parse(engineInfo[0]), double.Parse(engineInfo[1])));
            }

            List<Car> cars = new List<Car>();

            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(make,
                    model,
                    year,
                    fuelQuantity,
                    fuelConsumption,
                    engines[engineIndex],
                    tires[tiresIndex]);

                if (year >= 2017 &&
                    tires[tiresIndex].Sum(x => x.Pressure) > 9 &&
                    tires[tiresIndex].Sum(x => x.Pressure) < 10 &&
                    engines[engineIndex].HorsePower > 330)
                {
                    cars.Add(car);
                }
            }

            foreach (Car car in cars)
            {
                car.Drive(20);
                Console.WriteLine($"{car.WhoAmI()}");
            }
        }
    }
}
