using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrickHat.Data;
using TrickHat.Data.Models;

namespace TrickHat
{
    public class StartUp
    {
        const string NewLine = "\r\n";
        static TrickHatContext dbContext = null;

        static async Task Main(string[] args)
        {
            dbContext = new TrickHatContext();
            dbContext.Database.Migrate();

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                ProcessClientAsync(client);
            }
        }

        public static async Task ProcessClientAsync(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[1000000];
                int length = await stream.ReadAsync(buffer, 0, buffer.Length);

                string requestString = Encoding.UTF8.GetString(buffer, 0, length);

                Console.WriteLine(requestString);

                string cmdPattern = @"(?<=POST \/)([a-z]{2,})(?= HTTP\/1.1)";
                bool hasCommand = Regex.IsMatch(requestString, cmdPattern);

                if (hasCommand)
                {
                    string command = Regex.Match(requestString, cmdPattern).Value;
                    ProcessCommand(command, requestString);
                }

                string html = @$"
                <form action=""/add"" method=""post"">
                <label for=""pname"">Player Name:</label><br>
                <input type=""text"" id=""pname"" name =""pname""><br>
                <label for=""tname"">Team:</label><br>
                <input type=""text"" id=""tname"" name=""tname"">
                <input type=""submit"">
                </form>";

                string response = "HTTP/1.1 200 OK" + NewLine +
                    "Server: TrickHat 2021" + NewLine +
                    "Content-Type: text/html; charset=utf-8" + NewLine +
                    "Content-Length: " + html.Length + NewLine +
                    NewLine +
                    html +
                    NewLine;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                await stream.WriteAsync(responseBytes);

                Console.WriteLine(new string('*', 50));
            }
        }

        private static void ProcessCommand(string command, string requestString)
        {
            switch (command)
            {
                case "add":
                    string playerTeamPattern = @"pname=(?<player>[A-Z][a-z]+)&tname=(?<team>[A-Za-z 0-9]+)";
                    string player = Regex.Match(requestString, playerTeamPattern).Groups["player"].Value;
                    string team = Regex.Match(requestString, playerTeamPattern).Groups["team"].Value;
                    AddPlayerAsync(dbContext, player, team);
                    break;
                default:
                    break;
            }
        }

        private static async Task AddPlayerAsync(TrickHatContext db, string playerName, string teamName)
        {
            Team[] allTeams = await db.Teams.ToArrayAsync();

            Team team = null;

            if (!allTeams.Select(t => t.Name).Contains(teamName))
            {
                team = new Team
                {
                    Name = teamName
                };
            }
            else
            {
                team = allTeams.First(t => t.Name == teamName);
            }

            await db.Players.AddAsync(new Player
            {
                Name = playerName,
                Team = team
            });

            await db.SaveChangesAsync();
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
