namespace PokemonTrainer
{
    using System.Collections.Generic;
    using System.Linq;

    class Trainer
    {
        public string Name { get; set; }

        public int Badges { get; set; }

        public int PokemonCount => this.Pokemons.Count;

        private List<Pokemon> Pokemons { get; set; }

        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.Pokemons.Add(pokemon);
        }

        public void AddPokemon(string name, Elements element, int health)
        {
            this.Pokemons.Add(new Pokemon(name, element, health));
        }

        public void CheckPokemons(Elements element, int damage)
        {
            if (this.Pokemons.Any(p => p.Element.Equals(element)))
            {
                this.Badges += 1;
            }
            else
            {
                this.Pokemons.ForEach(p => p.TakeDamage(damage));
            }

            foreach (Pokemon pokemon in this.Pokemons.ToList())
            {
                if (!pokemon.IsAlive)
                {
                    this.Pokemons.Remove(pokemon);
                }
            }
        }
    }
}
