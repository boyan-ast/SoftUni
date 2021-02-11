using System;
using System.Linq;

namespace _01.ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] items = commandArgs.Skip(1).ToArray();
            ListyIterator<string> list = new ListyIterator<string>(items);

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (command == "Print")
                {
                    try
                    {
                        list.Print();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Invalid Operation!");                        
                    }                    
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (command == "PrintAll")
                {
                    foreach (var item in list)
                    {
                        Console.Write(item + " ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
