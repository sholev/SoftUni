using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InheritenceAndAbstraction.Classes;

namespace InheritenceAndAbstraction
{
    class HumanStudentWorker
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            var workers = new List<Worker>();

            // fill the lists
            Random RNG = new Random();
            List<String> names = File.ReadAllLines(@"..\..\names.txt").ToList();
            for (int i = 0; i < 20; i++)
            {
                // get random name and remove it from the list
                string randomName = names[RNG.Next(0, names.Count)];
                string[] lineContent = randomName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                names.Remove(randomName);

                string name = lineContent[0];
                string surname = lineContent[1];

                // alternate between students and workers
                if (i % 2 == 0)
                    // http://stackoverflow.com/a/1344295
                    students.Add(new Student(name, surname, Path.GetRandomFileName().Replace(".", "").Substring(0, 10).ToUpper()));
                else
                    workers.Add(new Worker(name, surname, (decimal)(RNG.Next(1000, 5000) + RNG.NextDouble()), RNG.Next(1, 13)));
            }

            // sort lists and print
            Console.WriteLine("Students:");
            students.OrderBy(s => s.FaculltyNumber).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine("Workers:");
            workers.OrderBy(w => w.PaymentPerHours).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            // merge lists, sort and print
            var merged = new List<Human>();
            merged.AddRange(students);
            merged.AddRange(workers);

            Console.WriteLine("Merged:");
            merged.OrderBy(person => person.Name+person.Surname).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
        }
    }
}
