using System;
using System.Linq;

namespace CustomGenericStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniStack<int> myStack = new SoftUniStack<int>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command.StartsWith("Push"))
                {
                    int[] numbersToPush = command
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1).Select(int.Parse)
                        .ToArray();

                    for (int i = 0; i < numbersToPush.Length; i++)
                    {
                        myStack.Push(numbersToPush[i]);
                    }
                }
                else if (command == "Pop")
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("No elements");
                    }                    
                }
            }

            foreach (int element in myStack)
            {
                Console.WriteLine(element);
            }
            foreach (int element in myStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
