using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> items;

		public WarController()
		{
			this.party = new List<Character>();
			this.items = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			Character character = null;

			if (characterType == nameof(Warrior))
            {
				character = new Warrior(name);
            }
            else if (characterType == nameof(Priest))
            {
				character = new Priest(name);
            }
			else
            {
				throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

			this.party.Add(character);

			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = null;

            if (itemName == nameof(FirePotion))
            {
				item = new FirePotion();
            }
            else if (itemName == nameof(HealthPotion))
            {
				item = new HealthPotion();
            }
			else
            {
				throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

			this.items.Add(item);

			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			Character character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.items.Count == 0)
            {
				throw new InvalidOperationException("No items left in pool!");
            }

			Item item = this.items[this.items.Count - 1];
			this.items.Remove(item);

			character.Bag.AddItem(item);

			return $"{characterName} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = this.party.FirstOrDefault(c => c.Name == characterName);
			Item item = character.Bag.GetItem(itemName);

            if (character == null)
            {
				throw new ArgumentException($"Character {characterName} not found!");
            }

			character.UseItem(item);

			return $"{character.Name} used {item.GetType().Name}.";
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

			List<Character> sorted = this.party
				.OrderByDescending(c => c.IsAlive)
				.ThenByDescending(c => c.Health)
				.ToList();

            foreach (Character character in sorted)
            {
				string last = character.IsAlive ? "Alive" : "Dead";

				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, " +
					$"Status: {last}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = this.party.FirstOrDefault(x => x.Name == attackerName);
			Character receiver = this.party.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
				throw new ArgumentException($"Character {attackerName} not found!");
            }

            if (receiver == null)
            {
				throw new ArgumentException($"Character {receiverName} not found!");
			}

            if (attacker.GetType().Name == nameof(Priest))
            {
				throw new ArgumentException($"{attackerName} cannot attack!");
            }

			Warrior attackerWarrior = (Warrior)attacker;

			attackerWarrior.Attack(receiver);

			string result = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} " +
				$"has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
				result += Environment.NewLine + $"{receiver.Name} is dead!";
            }

			return result;
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Character healer = this.party.FirstOrDefault(x => x.Name == healerName);
			Character receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

			if (healer == null)
			{
				throw new ArgumentException($"Character {healerName} not found!");
			}

			if (receiver == null)
			{
				throw new ArgumentException($"Character {healingReceiverName} not found!");
			}

			if (healer.GetType().Name == nameof(Warrior))
			{
				throw new ArgumentException($"{healerName} cannot heal!");
			}

			Priest healerPriest = (Priest)healer;

			healerPriest.Heal(receiver);

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
