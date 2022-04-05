using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicatesWithClasses
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthdate { get; set; }

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

        public static bool GetByBirthdate(Person person)
        {
            var startRange = User.startDate.Split('/').ToList();
            DateTime startDate = new DateTime(Int32.Parse(startRange[0]), Int32.Parse(startRange[1]), 1);

            var endRange = User.endDate.Split('/').ToList();
            DateTime endDate = new DateTime(Int32.Parse(endRange[0]), Int32.Parse(endRange[1]), 1);

            return person.Birthdate.Date >= startDate && person.Birthdate.Date <= endDate;
        }
    }

    class User
    {
        public static string Input { get; set; }
        public static string startDate { get; set; }
        public static string endDate { get; set; }
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
                new Person() {Name = "Ricardo", Age = 23, Birthdate = new DateTime(1998, 12, 17)},
                new Person() {Name = "Jair", Age = 24, Birthdate = new DateTime(1997, 12, 17)},
                new Person() {Name = "Orozco", Age = 25, Birthdate = new DateTime(1996, 12, 17)},
                new Person() {Name = "Alvarez", Age = 26, Birthdate = new DateTime(1995, 12, 17)}
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

        static void DateSearcher(string startDate, string endDate)
        {
            User.startDate = startDate;
            User.endDate = endDate;

            Predicate<Person> predicateByDate = new Predicate<Person>(Person.GetByBirthdate);

            List<Person> people = new List<Person>()
            {
                new Person() {Name = "Ricardo", Age = 23, Birthdate = new DateTime(1998, 12, 17)},
                new Person() {Name = "Jair", Age = 24, Birthdate = new DateTime(1997, 12, 17)},
                new Person() {Name = "Orozco", Age = 25, Birthdate = new DateTime(1996, 12, 17)},
                new Person() {Name = "Alvarez", Age = 26, Birthdate = new DateTime(1995, 12, 17)}
            };

            var result = people.FindAll(predicateByDate);

            if (result.Any())
            {
                foreach (var item in result)
                    Console.WriteLine(item.Name);
            }

            else
                Console.WriteLine("Names don't find");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Start Date (Format: yyyy/mm): ");
            string startDate = Console.ReadLine();

            Console.WriteLine("End Date (Format: yyyy/mm): ");
            string endDate = Console.ReadLine();

            DateSearcher(startDate, endDate);
        }
    }
}
