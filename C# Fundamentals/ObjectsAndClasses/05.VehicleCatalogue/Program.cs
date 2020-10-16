using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();
            List<Truck> allTrucks = new List<Truck>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] vehicleData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = vehicleData[0];
                string model = vehicleData[1];
                string color = vehicleData[2];
                int horsepower = int.Parse(vehicleData[3]);

                switch (type)
                {
                    case "car": allCars.Add(new Car(model, color, horsepower)); break;
                    case "truck": allTrucks.Add(new Truck(model, color, horsepower)); break;
                    default: break;
                }
            }

            string modelToPrint = string.Empty;

            while ((modelToPrint = Console.ReadLine()) != "Close the Catalogue")
            {
                Car currentCar = allCars.FirstOrDefault(car => car.Model == modelToPrint);
                Truck currentTruck = allTrucks.FirstOrDefault(truck => truck.Model == modelToPrint);

                if (currentCar != null)
                {
                    Console.WriteLine(currentCar);
                }
                else if (currentTruck != null)
                {
                    Console.WriteLine(currentTruck);
                }
            }

            Console.WriteLine($"Cars have average horsepower of: {Car.AverageHorsePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {Truck.AverageHorsePower:f2}.");
        }

        class Car
        {
            public string Model { get; set; }
            public string Color { get; set; }
            public int Horsepower { get; set; }

            private static int totalHorsePower;
            private static int numberOfCars;

            public static double AverageHorsePower
            {
                get
                {
                    if (numberOfCars > 0) { return totalHorsePower * 1.0 / numberOfCars; }
                    else return 0;
                }
            }


            public Car(string model, string color, int horsepower)
            {
                Model = model;
                Color = color;
                Horsepower = horsepower;

                totalHorsePower += horsepower;
                numberOfCars++;
            }

            public override string ToString()
            {
                StringBuilder text = new StringBuilder();

                text.AppendLine("Type: Car");
                text.AppendLine($"Model: {Model}");
                text.AppendLine($"Color: {Color}");
                text.Append($"Horsepower: {Horsepower}");

                return text.ToString();
            }

        }

        class Truck
        {
            public string Model { get; set; }
            public string Color { get; set; }
            public int Horsepower { get; set; }

            private static int totalHorsePower;
            private static int numberOfTrucks;

            public static double AverageHorsePower
            {
                get
                {
                    if (numberOfTrucks > 0) { return totalHorsePower * 1.0 / numberOfTrucks; }
                    else return 0;
                }
            }

            public Truck(string model, string color, int horsepower)
            {
                Model = model;
                Color = color;
                Horsepower = horsepower;

                totalHorsePower += horsepower;
                numberOfTrucks++;
            }

            public override string ToString()
            {
                StringBuilder text = new StringBuilder();

                text.AppendLine("Type: Truck");
                text.AppendLine($"Model: {Model}");
                text.AppendLine($"Color: {Color}");
                text.Append($"Horsepower: {Horsepower}");

                return text.ToString();
            }
        }
    }
}
