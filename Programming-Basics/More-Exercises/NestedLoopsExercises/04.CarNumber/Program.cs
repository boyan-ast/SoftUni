using System;

namespace _04.CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            for (int i = startNum; i <= endNum; i++)
            {
                for (int j = startNum; j <= endNum; j++)
                {
                    for (int k = startNum; k <= endNum; k++)
                    {
                        for (int l = startNum; l < i; l++)
                        {
                            bool firstCondition = (i % 2 == 0 && l % 2 != 0) || (i % 2 != 0 && l % 2 == 0);
                            bool secondCondition = (j + k) % 2 == 0;

                            if (firstCondition && secondCondition)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
