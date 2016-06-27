namespace AnimalClinic
{
    using System;

    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var animalName = parameters[0];
                var animalBreed = parameters[1];
                var clinicAction = parameters[2];

                var currentAnimal = new Animal(animalName, animalBreed);

                switch (clinicAction)
                {
                    case "heal":
                        Console.WriteLine(AnimalClinic.HealAnimal(currentAnimal));
                        break;
                    case "rehabilitate":
                        Console.WriteLine(AnimalClinic.RehabilitateAnimal(currentAnimal));
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            Console.Write(AnimalClinic.ToString(Console.ReadLine()));
        }
    }
}