using System;

namespace _02.MuOnline
{
    class Program
    {
        static int health = 100;
        static int bitcoins = 0;
        static int count = 0;

        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            foreach (string room in rooms)
            {
                string[] commandArgs = room.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];
                int value = int.Parse(commandArgs[1]);

                EnterTheRoom(command, value, rooms);
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }

        private static void EnterTheRoom(string command, int value, string[] rooms)
        {
            count++;

            if (command == "potion")
            {
                health += value;

                if (health > 100)
                {
                    value = 100 - (health - value);
                    health = 100;
                }

                Console.WriteLine($"You healed for {value} hp.");
                Console.WriteLine($"Current health: {health} hp.");
            }
            else if (command == "chest")
            {
                bitcoins += value;
                Console.WriteLine($"You found {value} bitcoins.");
            }
            else
            {
                health -= value;

                if (health <= 0)
                {
                    Console.WriteLine($"You died! Killed by {command}.");
                    Console.WriteLine($"Best room: {count}");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"You slayed {command}.");
                }
            }
        }
    }
}
