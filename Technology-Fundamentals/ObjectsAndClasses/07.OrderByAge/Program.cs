using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<UserInfo> users = new List<UserInfo>();

            while (input != "End")
            {
                string[] personData = input.Split();
                string name = personData[0];
                string id = personData[1];
                int age = int.Parse(personData[2]);

                UserInfo user = new UserInfo(name, id, age);
                users.Add(user);

                input = Console.ReadLine();
            }

            foreach (UserInfo user in users.OrderBy(x => x.Age))
            {
                Console.WriteLine(user);
            }
        }
        class UserInfo
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }

            public UserInfo(string name, string id, int age)
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
