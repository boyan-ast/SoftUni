using System;

namespace AuthorProblem
{
    [Author("Bobby")]
    public class StartUp
    {
        [Author("Robertha")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}
