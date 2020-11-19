using System;
using System.Text;

namespace _05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();

            StringBuilder resultHtml = new StringBuilder();

            resultHtml.AppendLine("<h1>");
            resultHtml.AppendLine($"    {title}");
            resultHtml.AppendLine("</h1>");

            resultHtml.AppendLine("<article>");
            resultHtml.AppendLine($"    {content}");
            resultHtml.AppendLine("</article>");

            string comment = string.Empty;

            while ((comment = Console.ReadLine()) != "end of comments")
            {
                resultHtml.AppendLine("<div>");
                resultHtml.AppendLine($"    {comment}");
                resultHtml.AppendLine("</div>");
            }

            Console.WriteLine(resultHtml);
        }
    }
}
