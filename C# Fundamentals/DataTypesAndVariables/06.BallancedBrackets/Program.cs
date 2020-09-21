using System;

namespace _06.BallancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            bool openBrackets = false;
            bool ballanced = true;
            bool noBracketsAtAll = true;

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    noBracketsAtAll = false;

                    if (openBrackets)
                    {
                        ballanced = false;
                    }
                    else
                    {
                        openBrackets = true;
                    }
                }
                else if (input == ")")
                {
                    noBracketsAtAll = false;

                    if (openBrackets)
                    {
                        openBrackets = false;
                    }
                    else
                    {
                        ballanced = false;
                    }
                }
            }

            if (ballanced && !noBracketsAtAll && openBrackets == false)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
