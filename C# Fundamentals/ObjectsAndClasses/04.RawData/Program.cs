using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> allCars = new List<Car>(numberOfCars);

            AddCars(numberOfCars, allCars);

            string type = Console.ReadLine();
            List<Car> filteredCars = FilterTheCars(allCars, type);

            foreach (Car car in filteredCars)
            {
                Console.WriteLine(car);
            }
            
        }

        private static List<Car> FilterTheCars(List<Car> allCars, string type)
        {
            if (type == "fragile")
            {
                return allCars.Where(x =>(x.CarCargo.Type == type && x.CarCargo.Weight < 1000)).ToList();
            }
            else if (type == "flamable")
            {
                return allCars.Where(x => (x.CarCargo.Type == type && x.CarEngine.Power > 250)).ToList();
            }
            else
            {
                return null;
            }
        }

        private static void AddCars(int numberOfCars, List<Car> allCars)
        {
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                int speed = int.Parse(carData[1]);
                int power = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];

                Car car = new Car(model, cargoWeight, cargoType, speed, power);

                allCars.Add(car);
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine CarEngine { get; set; }
        public Cargo CarCargo { get; set; }

        public Car(string model, int cargoWeight, string cargoType, int engineSpeed, int enginePower)
        {
            Model = model;
            CarEngine = new Engine(engineSpeed, enginePower);
            CarCargo = new Cargo(cargoWeight, cargoType);
        }

        public override string ToString()
        {
            return Model;
        }
    }

    class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }

    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }
}
