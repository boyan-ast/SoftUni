using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> allSongs = new List<Song>(n);

            for (int i = 0; i < n; i++)
            {
                string[] songInfo = Console.ReadLine().Split("_");

                string songType = songInfo[0];
                string songName = songInfo[1];
                string songTime = songInfo[2];

                Song song = new Song(songType, songName, songTime);

                allSongs.Add(song);
            }

            string typeToFilter = Console.ReadLine();

            Song.Filter(allSongs, typeToFilter);
        }
    }

    class Song
    {
        private string typeList;
        private string name;
        private string time;

        public Song(string type, string name, string time)
        {
            TypeList = type;
            Name = name;
            Time = time;
        }

        public static void Filter(List<Song> songs, string type)
        {
            List<Song> result = new List<Song>();

            if (type != "all")
            {
                result = songs.Where(x => x.TypeList == type).ToList();
            }
            else
            {
                result = songs;
            }

            foreach (Song song in result)
            {
                Console.WriteLine(song.Name);
            }
        }

        public string TypeList
        {
            get
            {
                return this.typeList;
            }
            set
            {
                this.typeList = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

    }

}
