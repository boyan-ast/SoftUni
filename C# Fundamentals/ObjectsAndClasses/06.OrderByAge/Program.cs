using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> allUsers = new List<User>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] userInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                allUsers.Add(new User(userInfo[0], userInfo[1], int.Parse(userInfo[2])));
            }

            foreach (User user in allUsers.OrderBy(x => x.Age))
            {
                Console.WriteLine(user);
            }
        }

        class User
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }

            public User(string name, string id, int age)
            {
                Name = name;
                ID = id;
                Age = age;
            }

            public override string ToString()
            {
                return $"{Name} with ID: {ID} is {Age} years old.";
            }
        }
    }
}
