using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += 1.6;
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += 0.95 * liters;
        }
    }
}
