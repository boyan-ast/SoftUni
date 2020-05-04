using System;
using System.Reflection;

namespace _11.Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int birthdays = int.Parse(Console.ReadLine());
            double targetMoney = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int money = 0;
            int toys = 0;

            for (int i = 1; i <= birthdays; i++)
            {
                if (i % 2 != 0)
                {
                    toys++;
                }
                else
                {
                    money += i * 5;
                    money--;
                }
            }

            money += toys * toyPrice;

            if (targetMoney <= money)
            {
                Console.WriteLine($"Yes! {(money - targetMoney):f2}");
            }
            else
            {
                Console.WriteLine($"No! {(targetMoney - money):f2}");
            }
        }
    }
}
