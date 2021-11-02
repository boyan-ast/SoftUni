namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            Console.WriteLine(ExportSongsAboveDuration(context, 4));

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var filteredAlbums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Include(x => x.Songs)
            .Select(a => new
            {
                AlbumName = a.Name,
                ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                ProducerName = a.Producer.Name,
                Songs = a.Songs
                    .Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        SongWriter = s.Writer.Name
                    })
                    .ToList(),
                TotalAlbumPrice = a.Price
            })
            .ToList()
            .OrderByDescending(a => a.TotalAlbumPrice);

            foreach (var a in filteredAlbums)
            {
                sb.AppendLine($"-AlbumName: {a.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine($"-Songs:");

                int num = 0;

                var orderedSongs = a.Songs.OrderByDescending(s => s.SongName).ThenBy(s => s.SongWriter);

                foreach (var s in orderedSongs)
                {
                    sb.AppendLine($"---#{++num}");
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {s.SongWriter}");
                }

                sb.AppendLine($"-AlbumPrice: {a.TotalAlbumPrice:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder result = new StringBuilder();

            var filteredSongs = context.Songs
                .Select(s => new
                {
                    s.Name,
                    Performer = s.SongPerformers.Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName).FirstOrDefault(),
                    Writer = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    s.Duration
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration);

            int num = 0;

            foreach (var s in filteredSongs)
            {
                result.Append($"-Song #{++num}\r\n");
                result.Append($"---SongName: {s.Name}\r\n");
                result.Append($"---Writer: {s.Writer}\r\n");
                result.Append($"---Performer: {s.Performer}\r\n");
                result.Append($"---AlbumProducer: {s.AlbumProducer}\r\n");
                result.Append($"---Duration: {s.Duration:c}\r\n");
            }

            return result.ToString().Trim();
        }
    }
}
