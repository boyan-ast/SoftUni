using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings myStack = new StackOfStrings();

            myStack.Push("LP");
            myStack.Push("LB");

            myStack.AddRange(new List<string> { "REM", "RHCP" });

            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }
        }
    }
}
