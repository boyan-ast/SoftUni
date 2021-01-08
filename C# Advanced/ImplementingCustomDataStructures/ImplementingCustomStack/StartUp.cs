using System;

namespace ImplementingCustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i * 10);
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine("-------------------");

            stack.ForEach(x => Console.WriteLine(x));
        }
    }
}
