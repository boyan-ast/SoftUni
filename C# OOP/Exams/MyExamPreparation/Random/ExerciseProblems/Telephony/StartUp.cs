using System;
using System.Collections.Generic;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string number in phoneNumbers)
            {
                if (number.Length == 10)
                {
                    try
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (number.Length == 7)
                {
                    try
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (string site in sites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(site));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
