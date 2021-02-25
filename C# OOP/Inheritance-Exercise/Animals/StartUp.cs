using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string animalType = string.Empty;
            List<Animal> animals = new List<Animal>();

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = string.Empty;
                int age = 0;
                string gender = string.Empty;

                try
                {
                    name = animalInfo[0];
                    age = int.Parse(animalInfo[1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (animalInfo.Length > 2)
                {
                    gender = animalInfo[2];
                }

                switch (animalType)
                {
                    case "Cat":
                        try
                        {
                            Cat cat = new Cat(name, age, gender);
                            animals.Add(cat);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "Dog":
                        try
                        {
                            Dog dog = new Dog(name, age, gender);
                            animals.Add(dog);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "Frog":
                        try
                        {
                            Frog frog = new Frog(name, age, gender);
                            animals.Add(frog);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "Kitten":
                        try
                        {
                            Kitten kitten = new Kitten(name, age);
                            animals.Add(kitten);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "Tomcat":
                        try
                        {
                            Tomcat tomcat = new Tomcat(name, age);
                            animals.Add(tomcat);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
