using System;

namespace _03.Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());

            Console.WriteLine(PersonalTitles(age, gender));
        }

        private static string PersonalTitles(double age, char gender)
        {
            string personalTitle = String.Empty;

            if (age >= 16)
            {
                if (gender == 'm')
                {
                    personalTitle = "Mr.";
                }
                else if (gender == 'f')
                {
                    personalTitle = "Ms.";
                }
            }
            else
            {
                if (gender == 'm')
                {
                    personalTitle = "Master";
                }
                else if (gender == 'f')
                {
                    personalTitle = "Miss";
                }
            }

            return personalTitle;
        }
    }
}
