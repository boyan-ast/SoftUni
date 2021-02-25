using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            if (age <= 0)
            {
                throw new Exception("Invalid input!");
            }
            if (gender != "Male" && gender != "Female")
            {
                throw new Exception("Invalid input!");
            }

            Name = name;
            Age = age;
            Gender = gender;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public virtual string ProduceSound()
        {
            return default;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{GetType().Name}");
            result.AppendLine($"{Name} {Age} {Gender}");
            result.Append($"{ProduceSound()}");

            return result.ToString();
        }
    }
}
