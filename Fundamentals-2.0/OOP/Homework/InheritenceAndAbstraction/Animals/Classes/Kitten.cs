using System;

namespace Animals.Classes
{
    class Kitten : Animal
    {
        public Kitten(string name, int age)
            : base(name, age, Gender.female)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Roar.");
        }
    }
}
