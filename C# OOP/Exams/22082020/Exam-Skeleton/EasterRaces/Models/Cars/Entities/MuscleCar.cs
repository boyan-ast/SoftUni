using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double muscleCarCubicCentimeters = 5000;
        private const int muscleMinHorsePower = 400;
        private const int muscleMaxHorsePower = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, muscleCarCubicCentimeters, muscleMinHorsePower, muscleMaxHorsePower)
        {

        }
    }
}
