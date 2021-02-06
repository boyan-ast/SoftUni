using System;

namespace BoxOfT
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<int> boxInt = new Box<int>();
            Box<string> boxString = new Box<string>();

            boxInt.Add(1);
            boxInt.Add(2);
            boxInt.Add(3);

            Console.WriteLine(boxInt.Remove());

            boxString.Add("Levski");
            boxString.Add("Yantra");

            Console.WriteLine(boxString.Remove());
        }
    }
}
