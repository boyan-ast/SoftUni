using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            Dictionary<string, int> examSubmissions = new Dictionary<string, int>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] userInfo = command.Split("-");
                string username = userInfo[0];
                int points = 0;

                if (userInfo.Length == 3)
                {
                    string language = userInfo[1];
                    points = int.Parse(userInfo[2]);

                    if (!examSubmissions.ContainsKey(language))
                    {
                        examSubmissions[language] = 0;
                    }
                    examSubmissions[language]++;
                }
                else if (userInfo.Length == 2 && users.Select(x => x.Name).Contains(username))
                {
                    User existingUser = users.First(x => x.Name == username);
                    users.Remove(existingUser);
                    continue;
                }

                User user = new User();
                user.Name = username;

                if (!users.Select(x => x.Name).Contains(username))
                {
                    user.Points = points;
                    users.Add(user);
                }
                else
                {
                    User existingUser = users.First(x => x.Name == username);

                    if (existingUser.Points < points)
                    {
                        existingUser.Points = points;
                    }
                }
            }

            Console.WriteLine("Results:");
            foreach (User username in users.OrderByDescending(x => x.Points).ThenBy(y => y.Name))
            {
                Console.WriteLine(username);
            }
            Console.WriteLine("Submissions:");
            foreach (var kvp in examSubmissions.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
        class User
        {
            public string Name { get; set; }
            public int Points { get; set; }

            public override string ToString()
            {
                return $"{Name} | {Points}";
            }
        }
    }
}
