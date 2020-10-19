using System;
using System.Collections.Generic;
using System.Text;

namespace _02.EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gifts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = string.Empty;
            List<string> text = Console.ReadLine().Split();

            while ((command = Console.ReadLine()) != "No Money")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                ManageTheGifts(gifts, commandArgs);
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < gifts.Length; i++)
            {
                if (gifts[i] != "None")
                {
                    result.Append(gifts[i] + " ");
                }
            }

            result.ToString().Trim();

            Console.WriteLine(result);
        }

        private static void ManageTheGifts(string[] gifts, string[] commandArgs)
        {
            string command = commandArgs[0];

            if (command == "OutOfStock")
            {
                for (int i = 0; i < gifts.Length; i++)
                {
                    if (gifts[i] == commandArgs[1])
                    {
                        gifts[i] = "None";
                    }
                }
            }
            else if (command == "Required")
            {
                string gift = commandArgs[1];
                int index = int.Parse(commandArgs[2]);

                if (index >= 0 && index < gifts.Length)
                {
                    gifts[index] = gift;
                }
            }
            else if (command == "JustInCase")
            {
                gifts[gifts.Length - 1] = commandArgs[1];
            }
        }
    }
}
