namespace AnimalClinic
{
    using System;
    using System.Text;

    public static class AnimalClinic
    {
        private static int totalAnimalsCount = 0;

        private static int healedAnimalsCount = 0;

        private static int rehabilitatedAnimalsCount = 0;

        private static readonly StringBuilder HealedAnimals = new StringBuilder();

        private static readonly StringBuilder RehabilitatedAnimals = new StringBuilder();

        public static string HealAnimal(Animal animal)
        {
            HealedAnimals.AppendLine(animal.ToString());
            healedAnimalsCount++;
            return $"Patient {++totalAnimalsCount}: [{animal.Name} ({animal.Breed})] has been healed!";
        }

        public static string RehabilitateAnimal(Animal animal)
        {
            RehabilitatedAnimals.AppendLine(animal.ToString());
            rehabilitatedAnimalsCount++;
            return $"Patient {++totalAnimalsCount}: [{animal.Name} ({animal.Breed})] has been rehabilitated!";
        }

        public new static string ToString(string thirdParameter)
        {
            return String.Format(
                "Total healed animals: {1}{0}Total rehabilitated animals: {2}{0}{3}",
                Environment.NewLine,
                healedAnimalsCount,
                rehabilitatedAnimalsCount,
                thirdParameter == "heal" ? HealedAnimals.ToString() : RehabilitatedAnimals.ToString());
        }
    }
}