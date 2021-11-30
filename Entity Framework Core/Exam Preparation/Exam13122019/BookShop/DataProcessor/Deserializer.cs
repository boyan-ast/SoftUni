namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookXmlInputModel[]), new XmlRootAttribute("Books"));

            TextReader reader = new StringReader(xmlString);

            var booksDto = xmlSerializer.Deserialize(reader) as BookXmlInputModel[];

            foreach (var bookDto in booksDto)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isPublishedOnDateValid = DateTime
                    .TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedOn);

                if (!isPublishedOnDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Book book = new Book
                {
                    Name = bookDto.Name,
                    Genre = (Genre)bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = publishedOn
                };

                context.Books.Add(book);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported book {book.Name} for {book.Price:f2}.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var authorsDto = JsonConvert.DeserializeObject<AuthorJsonInputModel[]>(jsonString);

            foreach (var authorDto in authorsDto)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string[] allEmails = context.Authors.Select(a => a.Email).ToArray();

                if (allEmails.Contains(authorDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Book> authorsBooks = new List<Book>();

                foreach (var bookDto in authorDto.Books)
                {
                    if (bookDto.Id.HasValue)
                    {
                        Book book = context.Books.FirstOrDefault(b => b.Id == bookDto.Id.Value);

                        if (book == null)
                        {
                            continue;
                        }

                        authorsBooks.Add(book);
                    }
                }

                if (!authorsBooks.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                    Email = authorDto.Email,
                    AuthorsBooks = authorsBooks.Select(b => new AuthorBook { Book = b }).ToArray()
                };

                context.Authors.Add(author);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported author - {author.FirstName} {author.LastName} with {author.AuthorsBooks.Count} books.");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}