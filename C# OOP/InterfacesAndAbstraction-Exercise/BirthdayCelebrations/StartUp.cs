using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> buyersByName = new Dictionary<string, IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] buyerInfo = Console.ReadLine().Split();

                string name = buyerInfo[0];
                int age = int.Parse(buyerInfo[1]);

                if (buyerInfo.Length == 4)
                {
                    string id = buyerInfo[2];
                    string birthdate = buyerInfo[3];

                    buyersByName.Add(name, new Citizen(name, age, id, birthdate));
                }
                else if (buyerInfo.Length == 3)
                {
                    string group = buyerInfo[2];

                    buyersByName.Add(name, new Rebel(name, age, group));
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (buyersByName.ContainsKey(input))
                {
                    buyersByName[input].BuyFood();
                }
            }

            int totalFood = buyersByName.Sum(x => x.Value.Food);
            Console.WriteLine(totalFood);
        }
    }
}
