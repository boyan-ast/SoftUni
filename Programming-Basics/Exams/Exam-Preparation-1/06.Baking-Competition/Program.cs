using System;
using System.Collections.Generic;

namespace _06.Baking_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCompetitiors = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> competitiors = new Dictionary<string, Dictionary<string, int>>();

            int numberOfCookies = 0;
            int numberOfCakes = 0;
            int numberOfWaffles = 0;

            for (int i = 0; i < numberOfCompetitiors; i++)
            {
                string competitiorName = Console.ReadLine();

                var bakeries = new Dictionary<string, int>() {["cookies"]=0,["cakes"]=0,["waffles"]=0 };
                competitiors[competitiorName] = bakeries;

                string input = null;

                while ((input = Console.ReadLine()) != "Stop baking!")
                {
                    string bakery = input;
                    int count = int.Parse(Console.ReadLine());
                    bakeries[bakery] += count;
                }

                numberOfCookies += competitiors[competitiorName]["cookies"];
                numberOfCakes += competitiors[competitiorName]["cakes"];
                numberOfWaffles += competitiors[competitiorName]["waffles"];

                Console.WriteLine($"{competitiorName} baked {competitiors[competitiorName]["cookies"]} cookies, {competitiors[competitiorName]["cakes"]} cakes and {competitiors[competitiorName]["waffles"]} waffles.");
            }

            double totalPrice = numberOfCakes * 7.8 + numberOfCookies * 1.5 + numberOfWaffles * 2.3;

            Console.WriteLine($"All bakery sold: {numberOfCookies + numberOfCakes+numberOfWaffles}");
            Console.WriteLine($"Total sum for charity: {totalPrice:f2} lv.");

        }
    }
}
