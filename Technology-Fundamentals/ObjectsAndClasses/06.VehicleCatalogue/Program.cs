using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();
            List<Truck> allTrucks = new List<Truck>();
            AddVehiclesToTheCatalogue(allCars, allTrucks);
            PrintVehiclesData(allCars, allTrucks);
        }

        private static void PrintVehiclesData(List<Car> cars, List<Truck> trucks)
        {
            string model = Console.ReadLine();

            while (model != "Close the Catalogue")
            {
                if (cars.Select(x => x.Model).Contains(model))
                {
                    Car car = cars.FirstOrDefault(x => x.Model == model);
                    Console.WriteLine("Type: Car");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Color: {car.Color}");
                    Console.WriteLine($"Horsepower: {car.HorsePower}");
                }
                else if (trucks.Select(x => x.Model).Contains(model))
                {
                    Truck truck = trucks.FirstOrDefault(x => x.Model == model);
                    Console.WriteLine("Type: Truck");
                    Console.WriteLine($"Model: {truck.Model}");
                    Console.WriteLine($"Color: {truck.Color}");
                    Console.WriteLine($"Horsepower: {truck.HorsePower}");
                }

                model = Console.ReadLine();
            }

            if (Car.numberOfCars > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {(Car.carsHorsePower / Car.numberOfCars):f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (Truck.numberOfTrucks > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {(Truck.trucksHorsePower / Truck.numberOfTrucks):f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }

        }

        private static void AddVehiclesToTheCatalogue(List<Car> cars, List<Truck> trucks)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] vehicleInfo = command.Split();
                string type = vehicleInfo[0];
                string model = vehicleInfo[1];
                string color = vehicleInfo[2];
                int horsePower = int.Parse(vehicleInfo[3]);

                if (type == "car")
                {
                    Car car = new Car(model, color, horsePower);
                    cars.Add(car);
                }
                else if (type == "truck")
                {
                    Truck truck = new Truck(model, color, horsePower);
                    trucks.Add(truck);
                }
            }
        }

        class Car
        {
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }

            public static int numberOfCars;
            public static double carsHorsePower;

            public Car(string model, string color, int horsePower)
            {
                Model = model;
                Color = color;
                HorsePower = horsePower;

                numberOfCars++;
                carsHorsePower += horsePower;
            }
        }
        class Truck
        {
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }

            public static int numberOfTrucks;
            public static double trucksHorsePower;

            public Truck(string model, string color, int horsePower)
            {
                Model = model;
                Color = color;
                HorsePower = horsePower;

                numberOfTrucks++;
                trucksHorsePower += horsePower;
            }
        }
    }
}
