using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] pokemonInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = pokemonInfo[0];
                string pokemonName = pokemonInfo[1];
                string pokemonElement = pokemonInfo[2];
                int pokemonHealth = int.Parse(pokemonInfo[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = trainers.FirstOrDefault(t => t.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                trainer.Pokemons.Add(pokemon);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                PlayPokemons(command, trainers);
            }

            foreach (Trainer trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine(trainer);
            }
        }

        private static void PlayPokemons(string element, List<Trainer> trainers)
        {
            Func<Trainer, bool> predicate = t => t.Pokemons.Select(p => p.Element).Contains(element);

            foreach (Trainer trainer in trainers)
            {
                if (predicate(trainer))
                {
                    trainer.Badges++;
                }
                else
                {
                    trainer.Pokemons.ForEach(p => p.Health -= 10);
                    trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                }
            }
        }
    }
}
