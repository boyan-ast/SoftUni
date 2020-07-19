using System;
using System.Drawing;

namespace _03.ExamCategories
{
    class Program
    {
        static void Main(string[] args)
        {
            int complexity = int.Parse(Console.ReadLine());
            int confusion = int.Parse(Console.ReadLine());
            int pages = int.Parse(Console.ReadLine());

            string category = string.Empty;

            if (complexity >= 80 && confusion >= 80 && pages >= 8)
            {
                category = "Legacy";
            }
            else if (complexity >= 80 && confusion <= 10)
            {
                category = "Master";
            }
            else if (complexity <= 10)
            {
                category = "Elementary";
            }
            else if (complexity <= 30 && pages <= 1)
            {
                category = "Easy";
            }
            else if (confusion >= 50 && pages >= 2)
            {
                category = "Hard";
            }
            else
            {
                category = "Regular";
            }

            Console.WriteLine(category);
        }
    }
}
