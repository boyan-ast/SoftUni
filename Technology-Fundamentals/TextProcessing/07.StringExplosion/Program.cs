using System;
using System.Dynamic;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int power = 0;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (power > 0 && text[i] != '>')
                {
                    result.Append('_');
                    power--;
                }
                else
                {
                    result.Append(text[i]);
                }

                if (text[i] == '>')
                {
                    power += int.Parse(text[i + 1].ToString());
                }
            }

            string resultToString = result.ToString().Replace("_", "");

            Console.WriteLine(resultToString);
         }
    }
}
