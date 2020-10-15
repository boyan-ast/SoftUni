using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog vehicleCatalog = new Catalog();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] vehicleData = command.Split('/', StringSplitOptions.RemoveEmptyEntries);

                string type = vehicleData[0];
                string brand = vehicleData[1];
                string model = vehicleData[2];
                int powerOrWeight = int.Parse(vehicleData[3]);

                if (type == "Car")
                {
                    Car car = new Car(brand, model, powerOrWeight);
                    vehicleCatalog.AllCars.Add(car);
                    
                }
                else if (type == "Truck")
                {
                    Truck truck = new Truck(brand, model, powerOrWeight);
                    vehicleCatalog.AllTrucks.Add(truck);
                }
            }

            Console.WriteLine(vehicleCatalog);
        }
    }

    class Catalog
    {
        public List<Car> AllCars;
        public List<Truck> AllTrucks;

        public Catalog()
        {
            AllCars = new List<Car>();
            AllTrucks = new List<Truck>();
        }

        public override string ToString()
        {
            StringBuilder resultString = new StringBuilder();

            if (AllCars.Count > 0)
            {
                resultString.AppendLine("Cars:");

                foreach (Car car in AllCars.OrderBy(x => x.Brand))
                {
                    resultString.AppendLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (AllTrucks.Count > 0)
            {
                resultString.AppendLine("Trucks:");

                foreach (Truck truck in AllTrucks.OrderBy(x => x.Brand))
                {
                    resultString.AppendLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }           

            return resultString.ToString();
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;            
        }
    }
}
