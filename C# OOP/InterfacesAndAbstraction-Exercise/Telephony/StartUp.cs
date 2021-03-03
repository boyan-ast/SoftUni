using System;
using System.Collections.Generic;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ");
            string[] sites = Console.ReadLine().Split(" ");

            foreach (string number in numbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        ICallable callable = new Smartphone();
                        callable.Number = number;
                        Console.WriteLine(callable.Call()); 
                    }
                    else if (number.Length == 7)
                    {
                        ICallable callable = new StationaryPhone();
                        callable.Number = number;
                        Console.WriteLine(callable.Call());
                    }
                    else
                    {
                        Console.WriteLine("Invalid number!");
                    }    
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (string site in sites)
            {
                try
                {
                    IBrowsable smartphone = new Smartphone();
                    smartphone.URL = site;
                    Console.WriteLine(smartphone.Browse());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
