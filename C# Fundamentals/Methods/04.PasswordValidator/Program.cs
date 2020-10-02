using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isLongEnough = LengthValidator(password);

            if (!isLongEnough)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            bool isLettersAndDigits = LettersAndDigitsValidator(password);

            if (!isLettersAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            bool hasTwoDigits = DigitsNumberValidator(password);

            if (!hasTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isLongEnough && isLettersAndDigits && hasTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool LengthValidator(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }

            return false;
        }

        static bool LettersAndDigitsValidator(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool DigitsNumberValidator(string password)
        {
            int counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    counter++;

                    if (counter == 2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
