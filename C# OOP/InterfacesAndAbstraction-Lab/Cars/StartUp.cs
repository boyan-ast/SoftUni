using System;
using System.Collections.Generic;

namespace Cars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICar seat = new Seat("Ibiza", "Red");
            ICar tesla = new Tesla("Model 7", "White", 2);

            List<ICar> cars = new List<ICar>() { seat, tesla };

            foreach (ICar car in cars)
            {
                Console.WriteLine(car.ToString());
                Console.WriteLine(car.Start());
                Console.WriteLine(car.Stop()); 
            }
        }
    }
}
