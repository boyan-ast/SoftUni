using System;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            foreach (string name in usernames)
            {

                if (name.Length >= 3 && name.Length <= 16)
                {
                    bool isValid = true;

                    for (int i = 0; i < name.Length; i++)
                    {
                        if (!char.IsLetterOrDigit(name[i]) && name[i] != '-' && name[i] != '_')
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine(name);
                    }
                }
                
            }
        }
    }
}
