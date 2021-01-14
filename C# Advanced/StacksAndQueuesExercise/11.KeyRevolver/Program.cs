using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Queue<int> locks = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int intelligenceValue = int.Parse(Console.ReadLine());

            int barrelHolesLeft = gunBarrelSize;
            int shotBullets = 0;

            while (locks.Count > 0)
            {
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }

                int bulletSize = bullets.Pop();
                int lockSize = locks.Peek();

                shotBullets++;
                barrelHolesLeft--;

                if (bulletSize <= lockSize)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (barrelHolesLeft == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    barrelHolesLeft = gunBarrelSize;
                }
            }

            int bulletsCost = bulletPrice * shotBullets;
            int earnedMoney = intelligenceValue - bulletsCost;

            Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
        }
    }
}
