using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> allCars = new List<Car>(numberOfCars);

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double consumptionPerKm = double.Parse(carData[2]);

                Car currentCar = new Car(model, fuelAmount, consumptionPerKm);
                allCars.Add(currentCar);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] drivingData = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = drivingData[1];
                int distance = int.Parse(drivingData[2]);

                Car selectedCar = allCars.First(c => c.Model == model);

                if (!selectedCar.CanTravelDistance(distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                else
                {
                    selectedCar.Drive(distance);
                }
            }

            foreach (Car car in allCars)
            {
                Console.WriteLine(car);
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public int TraveledDistance { get; set; }

        public Car(string model, double fuelAmount, double consumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = consumption;
            TraveledDistance = 0;
        }

        public bool CanTravelDistance(int distance)
        {
            double usedFuel = distance * FuelConsumptionPerKm;

            if (usedFuel <= FuelAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Drive(int distance)
        {
            double usedFuel = distance * FuelConsumptionPerKm;
            FuelAmount -= usedFuel;
            TraveledDistance += distance;
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TraveledDistance}";
        }
    }
}

