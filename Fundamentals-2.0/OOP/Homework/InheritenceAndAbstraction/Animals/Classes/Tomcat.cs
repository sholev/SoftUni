using System;

namespace Animals.Classes
{
    class Tomcat : Animal
    {
        public Tomcat(string name, int age)
            : base(name, age, Gender.male)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hiss.");
        }
    }
}
