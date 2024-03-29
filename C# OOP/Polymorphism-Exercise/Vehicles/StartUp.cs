﻿using System;
using System.Collections.Generic;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Vehicle> vehiclesByType = new Dictionary<string, Vehicle>()
            {
                { nameof(Car), car },
                { nameof(Truck), truck },
                { nameof(Bus), bus }
            };

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                string action = command[0];
                string vehicleType = command[1];
                double amount = double.Parse(command[2]);

                if (action == "Drive")
                {
                    Console.WriteLine(vehiclesByType[vehicleType].Drive(amount));
                }
                else if (action == "Refuel")
                {
                    try
                    {
                        vehiclesByType[vehicleType].Refuel(amount);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == "DriveEmpty")
                {
                    Console.WriteLine(vehiclesByType[vehicleType].Drive(amount, true));
                }
            }

            foreach (var vehicle in vehiclesByType)
            {
                Console.WriteLine(vehicle.Value);
            }
        }
    }
}
