namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			var gamesDto = JsonConvert.DeserializeObject<GameJsonInputModel[]>(jsonString);

            foreach (var gameModel in gamesDto)
            {
                if (!IsValid(gameModel))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				bool isReleaseDateValid = DateTime
					.TryParseExact(gameModel.ReleaseDate, "yyyy-MM-dd",
									CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                if (!isReleaseDateValid)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				Developer developer = context.Developers.FirstOrDefault(d => d.Name == gameModel.Developer) ??
					new Developer { Name = gameModel.Developer };

				Genre genre = context.Genres.FirstOrDefault(g => g.Name == gameModel.Genre) ??
					new Genre { Name = gameModel.Genre };

				HashSet<Tag> tags = new HashSet<Tag>();

                foreach (var tagModelName in gameModel.Tags)
                {
					Tag tag = context.Tags.FirstOrDefault(t => t.Name == tagModelName)
						?? new Tag { Name = tagModelName };

					tags.Add(tag);
                }

				Game game = new Game
				{
					Name = gameModel.Name,
					Price = gameModel.Price,
					ReleaseDate = releaseDate,
					Developer = developer,
					Genre = genre,
					GameTags = tags
						.Select(t => new GameTag
						{
							Tag = t
						})
						.ToArray()
				};

				context.Games.Add(game);
				context.SaveChanges();

				sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			var usersDto = JsonConvert.DeserializeObject<UserJsonInputModel[]>(jsonString);

			List<User> users = new List<User>();

            foreach (var userModel in usersDto)
            {
				bool isValidUser = true;

                if (!IsValid(userModel))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				List<Card> cards = new List<Card>();

                foreach (var cardModel in userModel.Cards)
                {
                    if (!IsValid(cardModel))
                    {
						isValidUser = false;

						sb.AppendLine("Invalid Data");
						continue;
					}

					cards.Add(new Card
					{
						Number = cardModel.Number,
						Cvc = cardModel.CVC,
						Type = (CardType)cardModel.Type
					});
                }

                if (!isValidUser)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				User user = new User
				{
					FullName = userModel.FullName,
					Username = userModel.Username,
					Email = userModel.Email,
					Age = userModel.Age,
					Cards = cards
				};

				users.Add(user);
				sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseXmlInputModel[]), new XmlRootAttribute("Purchases"));

			TextReader reader = new StringReader(xmlString);

			var purchasesDto = xmlSerializer.Deserialize(reader) as PurchaseXmlInputModel[];

            foreach (var purchaseModel in purchasesDto)
            {
                if (!IsValid(purchaseModel))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				bool isTypeValid = Enum.TryParse<PurchaseType>(purchaseModel.Type, out PurchaseType type);
				bool isDateValid = DateTime.TryParseExact(purchaseModel.Date, "dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isTypeValid || !isDateValid)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				Purchase purchase = new Purchase
				{
					Type = type,
					ProductKey = purchaseModel.Key,
					Date = date,
					Card = context.Cards.First(c => c.Number == purchaseModel.Card),
					Game = context.Games.First(g => g.Name == purchaseModel.Title)
				};

				context.Purchases.Add(purchase);
				context.SaveChanges();

				sb.AppendLine($"Imported {purchaseModel.Title} for {purchase.Card.User.Username}");
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