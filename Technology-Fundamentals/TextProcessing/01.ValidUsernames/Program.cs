using System;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in usernames)
            {
                bool isValid = true;

                if (name.Length < 3 || name.Length > 16)
                {
                    isValid = false;
                    continue;
                }

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
