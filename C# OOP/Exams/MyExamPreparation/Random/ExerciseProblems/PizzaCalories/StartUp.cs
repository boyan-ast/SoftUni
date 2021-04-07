using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split(" ")[1];

            string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Pizza pizza = null;

            try
            {
                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
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

            Console.WriteLine(pizza);

        }
    }
}
