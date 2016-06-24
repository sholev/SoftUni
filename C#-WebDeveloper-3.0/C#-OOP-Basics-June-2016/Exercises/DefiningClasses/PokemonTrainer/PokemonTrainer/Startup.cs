namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();

            string trainerInput;
            while ((trainerInput = Console.ReadLine()) != "Tournament")
            {
                var parameters = trainerInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var trainerName = parameters[0];
                var pokemonName = parameters[1];
                var pokemonElement = (Elements)Enum.Parse(typeof(Elements), parameters[2]);
                var pokemonHealth = int.Parse(parameters[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                trainers[trainerName].AddPokemon(pokemonName, pokemonElement, pokemonHealth);
            }

            string tournamentInput;
            while ((tournamentInput = Console.ReadLine()) != "End")
            {
                var element = (Elements)Enum.Parse(typeof(Elements), tournamentInput);

                foreach (Trainer trainer in trainers.Values)
                {
                    trainer.CheckPokemons(element, 10);
                }
            }

            foreach (var trainer in trainers.Values.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.PokemonCount}");
            }
        }
    }
}