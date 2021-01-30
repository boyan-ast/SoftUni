using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person { Name = "Pesho", Age = 20 };

            Person secondPerson = new Person();

            secondPerson.Name = "Goshkata";
            secondPerson.Age = 44;

            Console.WriteLine(firstPerson.Name + " " + firstPerson.Age);
            Console.WriteLine($"{secondPerson.Name} is {secondPerson.Age} years old.");
        }
    }
}
