using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private ICollection<Character> party;
		private ICollection<Item> itemPool;

		public WarController()
		{
			this.party = new List<Character>();
			this.itemPool = new List<Item>();
		}

		//public IReadOnlyCollection<Character> Party => this.party.ToList().AsReadOnly();
		//public IReadOnlyCollection<Item> ItemPool => this.itemPool.ToList().AsReadOnly();

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			//Type[] types = Assembly
			//	.GetCallingAssembly()
			//	.GetTypes()
			//	.Where(t => t.IsSubclassOf(typeof(Character)))
			//	.ToArray();

			//Type charType = characterType.GetType();

			if (characterType != "Warrior" && characterType != "Priest")
            {
				throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

			Character character = null;

            if (characterType == "Priest")
            {
				character = new Priest(name);
            }
            else if (characterType == "Warrior")
            {
				character = new Warrior(name);
            }

			this.party.Add(character);

			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			//Type[] types = Assembly
			//	.GetCallingAssembly()
			//	.GetTypes()
			//	.Where(t => t.IsSubclassOf(typeof(Item)))
			//	.ToArray();

			if (itemName != nameof(FirePotion) && itemName != nameof(HealthPotion))
			{
				throw new ArgumentException($"Invalid item \"{itemName}\"!");
			}

			Item item = null;

            if (itemName == nameof(FirePotion))
            {
				item = new FirePotion();
            }
            else if (itemName == nameof(HealthPotion))
            {
				item = new HealthPotion();
            }

			this.itemPool.Add(item);

			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			Character selectedCharacter = this.party.FirstOrDefault(c => c.Name == characterName);

            if (selectedCharacter == null)
            {
				throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.itemPool.Count == 0)
            {
				throw new InvalidOperationException("No items left in pool!");
            }

			Item selectedItem = this.itemPool.ToArray()[this.itemPool.Count - 1];

			this.itemPool.Remove(selectedItem);

			selectedCharacter.Bag.AddItem(selectedItem);

			return $"{characterName} picked up {selectedItem.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character selectedCharacter = this.party.FirstOrDefault(c => c.Name == characterName);

			if (selectedCharacter == null)
			{
				throw new ArgumentException($"Character {characterName} not found!");
			}

			Item selectedItem = selectedCharacter.Bag.GetItem(itemName);

			selectedCharacter.UseItem(selectedItem);

			return $"{selectedCharacter.Name} used {itemName}.";
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
				string status = null;

                if (character.IsAlive)
                {
					status = "Alive";
				}
				else
                {
					status = "Dead";
                }

				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, " +
					$"AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character selectedAttacker = this.party.FirstOrDefault(c => c.Name == attackerName);

			if (selectedAttacker == null)
			{
				throw new ArgumentException($"Character {attackerName} not found!");
			}

			Character selectedReceiver = this.party.FirstOrDefault(c => c.Name == receiverName);

			if (selectedReceiver == null)
			{
				throw new ArgumentException($"Character {receiverName} not found!");
			}

            if (selectedAttacker.GetType().Name != nameof(Warrior))
            {
				throw new ArgumentException($"{selectedAttacker.Name} cannot attack!");
            }

			IAttacker attacker = (Warrior)selectedAttacker;

			attacker.Attack(selectedReceiver);

			string result = $"{attackerName} attacks {receiverName} for {selectedAttacker.AbilityPoints} hit points! {receiverName} has " +
				$"{selectedReceiver.Health}/{selectedReceiver.BaseHealth} HP and {selectedReceiver.Armor}/{selectedReceiver.BaseArmor} AP left!";

            if (!selectedReceiver.IsAlive)
            {
				result += Environment.NewLine + $"{selectedReceiver.Name} is dead!";
            }

			return result;
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Character healer = this.party.FirstOrDefault(c => c.Name == healerName);

			if (healer == null)
			{
				throw new ArgumentException($"Character {healerName} not found!");
			}

			Character selectedReceiver = this.party.FirstOrDefault(c => c.Name == healingReceiverName);

			if (selectedReceiver == null)
			{
				throw new ArgumentException($"Character {healingReceiverName} not found!");
			}

			if (healer.GetType().Name != nameof(Priest))
			{
				throw new ArgumentException($"{healer.Name} cannot heal!");
			}

			IHealer priest = (Priest)healer;

			priest.Heal(selectedReceiver);

			string result = $"{healer.Name} heals {selectedReceiver.Name} for " +
				$"{healer.AbilityPoints}! {selectedReceiver.Name} has {selectedReceiver.Health} health now!";

			return result;
		}
	}
}
