using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = String.Empty;
            VehiclesCatalogue catalogue = new VehiclesCatalogue();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] vehicleData = command.Split('/');

                string type = vehicleData[0];
                string brand = vehicleData[1];
                string model = vehicleData[2];

                if (type == "Car")
                {
                    int horsePower = int.Parse(vehicleData[3]);

                    Car car = new Car(brand, model, horsePower);

                    catalogue.AllCars.Add(car);
                }
                else if (type == "Truck")
                {
                    int weight = int.Parse(vehicleData[3]);

                    Truck truck = new Truck(brand, model, weight);

                    catalogue.AllTrucks.Add(truck);
                }
            }


            if (catalogue.AllCars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in catalogue.AllCars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalogue.AllTrucks.Count > 0)
            {
            Console.WriteLine("Trucks:");
            foreach (Truck truck in catalogue.AllTrucks.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
            }
        }

        class VehiclesCatalogue
        {
            public List<Truck> AllTrucks { get; set; }
            public List<Car> AllCars { get; set; }

            public VehiclesCatalogue()
            {
                AllTrucks = new List<Truck>();
                AllCars = new List<Car>();
            }
        }

        class Truck
        {
            private string brand;
            private string model;
            private int weight;

            public string Brand
            {
                get { return this.brand; }
                set { this.brand = value; }
            }
            public string Model
            {
                get { return this.model; }
                set { this.model = value; }
            }
            public int Weight
            {
                get { return this.weight; }
                set { this.weight = value; }
            }

            public Truck(string brand, string model, int weight)
            {
                Brand = brand;
                Model = model;
                Weight = weight;
            }
        }
        class Car
        {
            private string brand;
            private string model;
            private int horsePower;

            public string Brand
            {
                get { return this.brand; }
                set { this.brand = value; }
            }
            public string Model
            {
                get { return this.model; }
                set { this.model = value; }
            }
            public int HorsePower
            {
                get { return this.horsePower; }
                set { this.horsePower = value; }
            }

            public Car(string brand, string model, int horsePower)
            {
                Brand = brand;
                Model = model;
                HorsePower = horsePower;
            }
        }

    }
}
