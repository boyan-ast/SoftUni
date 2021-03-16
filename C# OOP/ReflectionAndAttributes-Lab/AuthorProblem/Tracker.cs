using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker : ITracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            MethodInfo[] methodsInfo = type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance |
                BindingFlags.NonPublic | BindingFlags.Static);

            foreach (MethodInfo method in methodsInfo)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    Console.WriteLine($"{method.Name} is written by {method.GetCustomAttribute<AuthorAttribute>().Name}");
                }
            }
        }
    }
}
