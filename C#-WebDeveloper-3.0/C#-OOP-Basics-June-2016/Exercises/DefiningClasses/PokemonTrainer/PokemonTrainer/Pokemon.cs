namespace PokemonTrainer
{
    public class Pokemon
    {
        public bool IsAlive => this.Health > 0;

        private string Name { get; set; }

        public Elements Element { get; private set; }

        private int Health { get; set; }

        public Pokemon(string name, Elements element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public void TakeDamage(int damage)
        {
            this.Health -= damage;
        }
    }
}
