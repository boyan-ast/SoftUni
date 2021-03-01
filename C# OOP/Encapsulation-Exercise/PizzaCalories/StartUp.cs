using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughtInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dough dough;
            Pizza pizza;

            try
            {
                dough = new Dough(doughtInfo[1], doughtInfo[2], double.Parse(doughtInfo[3]));
                pizza = new Pizza(pizzaName, dough);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] toppingInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Topping topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));
                    pizza.AddTopping(topping);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            if (pizza.ToppingsCount > 10)
            {
                Console.WriteLine("Number of toppings should be in range [0..10].");
            }
            else
            {
                Console.WriteLine(pizza);
            }

        }
    }
}
