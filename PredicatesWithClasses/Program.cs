using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicatesWithClasses
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public static bool Exists(Person person)
        {
            return person.Name.Equals(User.Input);
        }

        public static bool GetByAge(Person person)
        {
            var isNumber = Int32.TryParse(User.Input, out int age);

            if (isNumber)
                return person.Age.Equals(age);
            else
                return false;
        }
    }

    class User
    {
        public static string Input { get; set; }
    }

    class Program
    {
        static void Searcher(string input)
        {
            User.Input = input;

            Predicate<Person> predicateByName = new Predicate<Person>(Person.Exists);
            Predicate<Person> predicateByAge = new Predicate<Person>(Person.GetByAge);

            List<Person> people = new List<Person>()
            {
                new Person() {Name = "Ricardo", Age = 23},
                new Person() {Name = "Jair", Age = 24},
                new Person() {Name = "Orozco", Age = 25},
                new Person() {Name = "Alvarez", Age = 26}
            };

            if(people.Exists(predicateByName))
                Console.WriteLine("User Exists!");
            else
            {
                var result = people.FindAll(predicateByAge);

                if (result.Any())
                {
                    foreach (var item in result)
                        Console.WriteLine(item.Name);
                }

                else
                    Console.WriteLine("Names don't find");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Search: ");
            var input = Console.ReadLine();

            Searcher(input);
        }
    }
}
