using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelConsumption = fuelConsumption;

            this.TankCapacity = tankCapacity;

            if (fuelQuantity <= this.TankCapacity)
            {
                this.FuelQuantity = fuelQuantity;
            }
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        public string Drive(double distance, bool isEmpty = false)
        {
            double fuelConsumption = this.FuelConsumption;

            if (this.GetType().Name == nameof(Bus) && isEmpty)
            {
                fuelConsumption -= 1.4;
            }

            if (CanDrive(distance, fuelConsumption))
            {
                this.FuelQuantity -= fuelConsumption * distance;

                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }           
        }

        public void Refuel(double liters)
        {
            double amount = liters;

            if (this.GetType().Name == nameof(Truck))
            {
                amount *= 0.95;
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (CanPutFuel(amount))
            {
                this.FuelQuantity += amount;
            }
            else
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

        private bool CanPutFuel(double amount)
        {
            return (amount + this.FuelQuantity) <= this.TankCapacity;
        }

        private bool CanDrive(double distance, double fuelConsumption)
        {
            return this.FuelQuantity > fuelConsumption * distance;
        }
    }
}
