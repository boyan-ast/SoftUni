using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, Engine engine, int weight = -1, string color = null)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{Model}:");
            result.AppendLine($"  {Engine.Model}:");
            result.AppendLine($"    Power: {Engine.Power}");

            if (Engine.Displacement != -1)
            {
                result.AppendLine($"    Displacement: {Engine.Displacement}");
            }
            else
            {
                result.AppendLine($"    Displacement: n/a");
            }

            if (Engine.Efficiency != null)
            {
                result.AppendLine($"    Efficiency: {Engine.Efficiency}");
            }
            else
            {
                result.AppendLine($"    Efficiency: n/a");
            }

            if (Weight != -1)
            {
                result.AppendLine($"  Weight: {Weight}");
            }
            else
            {
                result.AppendLine($"  Weight: n/a");
            }

            if (Color != null)
            {
                result.Append($"  Color: {Color}");
            }
            else
            {
                result.Append($"  Color: n/a");
            }

            return result.ToString();
        }
    }
}
