namespace PrintPeople
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = parameters[0];
                var age = int.Parse(parameters[1]);
                var occupation = parameters[2];

                people.Add(new Person(name, age, occupation));
            }

            var output = people.ToArray();
            Array.Sort(output);

            foreach (var person in output)
            {
                Console.WriteLine(person);
            }
        }
    }
}
