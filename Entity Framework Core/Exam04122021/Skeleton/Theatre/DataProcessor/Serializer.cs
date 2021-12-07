namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToArray()
                .Where(t => (t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20))
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Sum(ti => ti.Price),
                    Tickets = t.Tickets
                        .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Select(ti => new
                        {
                            Price = ti.Price,
                            RowNumber = ti.RowNumber
                        })
                        .OrderByDescending(ti => ti.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            string jsonText = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return jsonText;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayXmlOutputModel[]), new XmlRootAttribute("Plays"));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var plays = context.Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new PlayXmlOutputModel
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .Select(c => new ActorXmlOutputModel
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{c.Play.Title}'."
                        })
                        .OrderByDescending(c => c.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            xmlSerializer.Serialize(writer, plays, ns);

            return writer.ToString();
        }
    }
}
