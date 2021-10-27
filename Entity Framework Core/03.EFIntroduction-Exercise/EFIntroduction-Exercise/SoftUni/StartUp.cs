using SoftUni.Data;
using System;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Services.RemoveTown(new SoftUniContext()));
        }
        
    }
}
