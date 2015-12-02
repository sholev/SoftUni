using Animals.Interfaces;

namespace Animals.Classes
{
    enum Gender
    {
        male,
        female
    }

    abstract class Animal : ISoundProducible
    {   
        // TODO: Add validation checks.
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public abstract void ProduceSound();
    }
}
