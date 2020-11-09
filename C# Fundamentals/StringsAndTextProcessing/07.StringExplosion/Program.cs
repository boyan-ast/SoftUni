using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            for (int index = 0; index < text.Length; index++)
            {
                result.Append(text[index]);

                if (text[index] == '>')
                {
                    index++;
                    int count = int.Parse(text[index].ToString());

                    while (count > 0)
                    {
                        index++;
                        count--;

                        if (index == text.Length)
                        {
                            break;
                        }

                        if (text[index] == '>')
                        {
                            result.Append(text[index]);
                            index++;

                            if (index == text.Length)
                            {
                                break;
                            }

                            count += int.Parse(text[index].ToString());
                        }
                    }

                    index--;
                }
            }

            Console.WriteLine(result);
        }
    }
}
