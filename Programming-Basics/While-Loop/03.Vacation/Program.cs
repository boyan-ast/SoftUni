using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());

            int days = 0; ;
            int spendCount = 0; ;

            while (currentMoney < tripPrice)
            {
                days++;
                string action = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());


                if (action == "spend")
                {
                    spendCount++;

                    if (spendCount == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(days);
                        return;
                    }

                    currentMoney -= money;

                    if (currentMoney < 0)
                    {
                        currentMoney = 0;
                    }
                }
                else if (action == "save")
                {
                    spendCount = 0;
                    currentMoney += money;
                }
            }

            Console.WriteLine($"You saved the money for {days} days.");
        }
    }
}
