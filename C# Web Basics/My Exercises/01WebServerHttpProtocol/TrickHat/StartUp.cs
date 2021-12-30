using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TrickHat.Data;

namespace TrickHat
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            const string NewLine = "\r\n";
            //var dbContext = new TrickHatContext();
            //dbContext.Database.Migrate();

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[1000000];
                    int length = stream.Read(buffer, 0, buffer.Length);

                    string requestString = Encoding.UTF8.GetString(buffer, 0, length);

                    Console.WriteLine(requestString);

                    string html = $"<h2> Hello from TrickHat {DateTime.Now}<h2>";

                    string response = "HTTP/1.1 200 OK" + NewLine +
                        "Server: TrickHat 2021" + NewLine +
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        "Content-Length: " + html.Length + NewLine +
                        NewLine +
                        html +
                        NewLine;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);

                    Console.WriteLine(new string('*', 50));
                }
            }
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg/trainings/3164/csharp-web-basics-september-2020#lesson-18198";

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine, 
                response.Headers.Select(h => h.Key + ": " + h.Value.FirstOrDefault())));

            //string html = await httpClient.GetStringAsync(url);

            //Console.WriteLine(html);
        }
    }
}
