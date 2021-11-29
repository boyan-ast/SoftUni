namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var genres = context.Genres
				.ToArray()
				.Where(g => genreNames.Contains(g.Name))
				.Select(g => new
				{
					Id = g.Id,
					Genre = g.Name,
					Games = g.Games
						.Where(x => x.Purchases.Any())
						.Select(x => new
						{
							Id = x.Id,
							Title = x.Name,
							Developer = x.Developer.Name,
							Tags = string.Join(", ", x.GameTags.Select(gt => gt.Tag.Name)),
							Players = x.Purchases.Count
						})						
						.OrderByDescending(ga => ga.Players)
						.ThenBy(ga => ga.Id)
						.ToArray(),
					TotalPlayers = g.Games.SelectMany(ga => ga.Purchases).Count()
				})
				.OrderByDescending(g => g.TotalPlayers)
				.ThenBy(g => g.Id)
				.ToArray();

			string jsonText = JsonConvert.SerializeObject(genres, Formatting.Indented);

			return jsonText;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			StringBuilder sb = new StringBuilder();

			var users = context.Users
				.ToArray()
				.Where(u => u.Cards.SelectMany(uc => uc.Purchases).Where(p => p.Type == Enum.Parse<PurchaseType>(storeType)).Any())
				.Select(u => new UserXmlOutputModel
				{
					Username = u.Username,
					Purchases = u.Cards
						.SelectMany(x => x.Purchases)
						.Where(p => p.Type == Enum.Parse<PurchaseType>(storeType))
						.OrderBy(p => p.Date)
						.Select(p => new UserPurchaseXmlOutputModel
						{
							Card = p.Card.Number,
							Cvc = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new GameXmlOutputModel
                            {
								Title = p.Game.Name,
								Genre = p.Game.Genre.Name,
								Price = p.Game.Price
                            }
						})
						.ToArray(),
					TotalSpent = u.Cards.SelectMany(uc => uc.Purchases
						.Where(p => p.Type == Enum.Parse<PurchaseType>(storeType))
						.Select(p => p.Game.Price)).Sum()
				})
				.OrderByDescending(u => u.TotalSpent)
				.ThenBy(u => u.Username)
				.ToArray();

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserXmlOutputModel[]), new XmlRootAttribute("Users"));

			TextWriter writer = new StringWriter();

			var ns = new XmlSerializerNamespaces();
			ns.Add("", "");

			xmlSerializer.Serialize(writer, users, ns);

			return writer.ToString();
		}
	}
}