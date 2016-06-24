namespace Person
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    class Startup
    {
        static void Main(string[] args)
        {
            ThirdProblemTest();
        }

        private static void ThirdProblemTest()
        {
            var count = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = parameters[0];
                var age = int.Parse(parameters[1]);

                persons.Add(new Person(name, age));
            }

            persons.Where(p => p.age > 30)
                .OrderBy(p => p.name)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private static void SecondProblemTest()
        {
            Type personType = typeof(Person);
            ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
            ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
            ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });
            bool swapped = false;
            if (nameAgeCtor == null)
            {
                nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });
                swapped = true;
            }

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
            Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });
            Person personWithAgeAndName = swapped
                                              ? (Person)nameAgeCtor.Invoke(new object[] { age, name })
                                              : (Person)nameAgeCtor.Invoke(new object[] { name, age });

            Console.WriteLine($"{basePerson.name} {basePerson.age}");
            Console.WriteLine($"{personWithAge.name} {personWithAge.age}");
            Console.WriteLine($"{personWithAgeAndName.name} {personWithAgeAndName.age}");
        }

        private static void FirstProblemTest()
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);
        }
    }
}