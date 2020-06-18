using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> allSongs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] inputInfo = Console.ReadLine().Split("_");
                string type = inputInfo[0];
                string name = inputInfo[1];
                string time = inputInfo[2];

                Song song = new Song(type, name, time);
                allSongs.Add(song);
            }

            string typeToPrint = Console.ReadLine();

            if (typeToPrint == "all")
            {
                foreach (Song song in allSongs)
                {
                    Console.WriteLine(song);
                }
            }
            else
            {
                List<Song> filteredSongs = allSongs.Where(x => x.TypeList == typeToPrint).ToList();

                foreach (Song song in filteredSongs)
                {
                    Console.WriteLine(song);
                }
            }
        }

        class Song
        {
            private string typeList;
            private string name;
            private string time;

            public Song(string type, string name, string time)
            {
                this.typeList = type;
                this.name = name;
                this.time = time;
            }

            public string TypeList
            {
                get { return typeList; }
                set { this.typeList = value; }
            }

            public string Name
            {
                get { return name; }
                set { this.name = value; }
            }

            public string Time
            {
                get { return time; }
                set { this.time = value; }
            }

            public override string ToString()
            {
                return this.Name;
            }
        }
    }
}
