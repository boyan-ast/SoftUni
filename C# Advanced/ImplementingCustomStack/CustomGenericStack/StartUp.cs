using System;

namespace CustomGenericStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniStack<string> myStack = new SoftUniStack<string>();
            myStack.Push("Ivan Vachev");
            myStack.Push("Vanio Ivanov");
            myStack.Push("Iliya Munin");
            myStack.Push("Tsar Ivan");
            myStack.Push("Misyak");
            myStack.Push("Patrick-Gabriel Galchev");

            //while (myStack.Count >= 2)
            //{
            //    Console.WriteLine(myStack.Pop());
            //}

            //Console.WriteLine(myStack.Peek());

            myStack.ForEach(e => Console.WriteLine("The name is " + e));
        }
    }
}
