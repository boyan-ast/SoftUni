using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;

            this.DefaultFuelConsumption = 1.25;
        }

        public double DefaultFuelConsumption { get; protected set; }
        public virtual double FuelConsumption => this.DefaultFuelConsumption;
        public double Fuel { get; private set; }
        public int HorsePower { get; private set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
