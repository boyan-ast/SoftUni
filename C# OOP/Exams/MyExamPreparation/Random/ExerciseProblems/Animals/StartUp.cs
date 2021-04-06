using System;
using System.Linq;
using System.Reflection;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string typeString = string.Empty;

            while ((typeString = Console.ReadLine()) != "Beast!")
            {
                Type type = Assembly
                    .GetCallingAssembly()
                    .GetTypes()                    
                    .FirstOrDefault(t => t.Name == typeString);

                if (type == null)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string[] animalInfo = Console.ReadLine().Split();

                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo.Length == 3 ? animalInfo[2] : string.Empty;

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (animalInfo.Length == 3 && gender != "Male" && gender != "Female")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                Animal animal = null;

                if (typeString == nameof(Kitten))
                {
                    animal = new Kitten(name, age);
                }
                else if (typeString == nameof(Tomcat))
                {
                    animal = new Tomcat(name, age);
                }
                else if (typeString == nameof(Cat))
                {
                    animal = new Cat(name, age, gender);
                }
                else if (typeString == nameof(Frog))
                {
                    animal = new Frog(name, age, gender);
                }
                else if (typeString == nameof(Dog))
                {
                    animal = new Dog(name, age, gender);
                }

                Console.WriteLine(animal);
            }
        }
    }
}
