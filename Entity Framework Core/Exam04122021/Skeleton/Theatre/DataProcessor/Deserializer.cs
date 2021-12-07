namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayXmlInputModel[]), new XmlRootAttribute("Plays"));

            TextReader reader = new StringReader(xmlString);

            var playsDto = xmlSerializer.Deserialize(reader) as PlayXmlInputModel[];

            foreach (var play in playsDto)
            {
                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDurationValid = TimeSpan
                    .TryParseExact(play.Duration, "c",
                        CultureInfo.InvariantCulture, out TimeSpan duration);

                if (!isDurationValid || duration.TotalHours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGenreValid = Enum.TryParse<Genre>(play.Genre, out Genre genre);

                if (!isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play validPlay = new Play
                {
                    Title = play.Title,
                    Duration = duration,
                    Rating = play.Rating,
                    Genre = genre,
                    Description = play.Description,
                    Screenwriter = play.Screenwriter
                };

                context.Plays.Add(validPlay);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported {validPlay.Title} with genre {validPlay.Genre} and a rating of {validPlay.Rating}!");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CastXmlInputModel[]), new XmlRootAttribute("Casts"));

            TextReader reader = new StringReader(xmlString);

            var castsDto = xmlSerializer.Deserialize(reader) as CastXmlInputModel[];

            foreach (var cast in castsDto)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast validCast = new Cast
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId
                };

                context.Casts.Add(validCast);
                context.SaveChanges();

                string actorRole = validCast.IsMainCharacter ? "main" : "lesser";

                sb.AppendLine($"Successfully imported actor {validCast.FullName} as a {actorRole} character!");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var theatresDto = JsonConvert.DeserializeObject<TheatreJsonInputModel[]>(jsonString);

            var playsIds = context.Plays.Select(p => p.Id).ToArray();

            foreach (var theatre in theatresDto)
            {
                if (!IsValid(theatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Ticket> validTickets = new List<Ticket>();

                foreach (var ticket in theatre.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //if (!playsIds.Contains(ticket.PlayId))
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}

                    validTickets.Add(new Ticket
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    });
                }

                Theatre validTheatre = new Theatre
                {
                    Name = theatre.Name,
                    NumberOfHalls = theatre.NumberOfHalls,
                    Director = theatre.Director,
                    Tickets = validTickets
                };

                context.Theatres.Add(validTheatre);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported theatre {validTheatre.Name} with #{validTheatre.Tickets.Count} tickets!");
            }

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
