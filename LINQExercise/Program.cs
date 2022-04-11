using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExercise
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> Scores { get; set; }
    }

    class Filters
    {
        // Filter 1
        // Find the words in the collection that start with the letter 'L'
        static List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

        // Filter 2
        // Which of the following numbers are multiples of 4 or 6
        static List<int> mixedNumbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        // Filter 3
        // Output how many numbers are in this list
        static List<int> numbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        public static List<string> Filter1(char letter)
        {
            return fruits
                .Where(fruit => fruit.StartsWith(letter).Equals(true)).ToList();
        }

        public static List<int> Filter2()
        {
            return mixedNumbers
                .Where(number => (number % 4) == 0 || (number % 6) == 0).ToList();
        }

        public static int Filter3()
        {
            return numbers.Count;
        }

        internal class Customer
        {
            public string Name { get; internal set; }
            public double Balance { get; internal set; }
            public string Bank { get; internal set; }
        }

        public static List<Customer> customers = new List<Customer>() 
        {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

        // Filter 4
        // How many millionaries are in the list by bank

        // Filter 5
        // Clients with balance > 100,000 and order by their balance

        // Filter 6
        // Sum of money of each bank

        // Filter 7
        // Get client's name that his balance < 100,000 and the bank has only 3 characters

        /* Filter 4 Solution
         *  var millionaries = Filters.customers
                .GroupBy(client => client.Bank)
                .Select(bank => new
                {
                    Bank = bank.Key,
                    Millionaries = bank.Where(client => client.Balance > 1000000)
                }).ToList();
         */

        public static List<Customer> Filter5()
        {
            return customers
                .Where(client => client.Balance > 100000)
                .OrderBy(client => client.Balance).ToList();
        }

        /* Filter 6 Solution
         *  var banks = Filters.customers
                .GroupBy(client => client.Bank)
                 .Select(bank => new
                 {
                     Bank = bank.Key,
                     Total = bank.Sum(client => client.Balance)
                 }).ToList();
         */

        public static List<Tuple<string, double>> Filter6()
        {
            double total = 0;
            List<Tuple<string, double>> banksData = new List<Tuple<string, double>>();

            var banks = customers
                .GroupBy(clients => clients.Bank)
                .OrderBy(group => group.Key);

            foreach (var bank in banks)
            {
                foreach (var client in bank)
                    total += client.Balance;

                banksData.Add(Tuple.Create(bank.Key, total));
                total = 0;
            }

            return banksData;
        }

        public static List<string> Filter7()
        {
            return customers
                .Where(client => client.Balance < 100000 && client.Bank.Length == 3)
                .Select(client => $"{client.Name} - {client.Balance} - {client.Bank}").ToList();
        }

        // B.1 Find the string which starts and ends with a specific character : AM
        //Solution: 
        /*
         *  var b1 = Filters.cities
                .Where(city => city.StartsWith('A') && city.EndsWith('I'));
         */

        // B.2 Write a program in C# Sharp to display the list of items in the array according to the length
        // of the string then by name in ascending order.
        //Solution: 
        /*
         *  var b2 = Filters.cities
                .OrderBy(city => city.Length).ThenBy(city => city[0]);
         */

        // B.3 Write a program in C# Sharp to split a collection of strings into 3 random groups.
        //Solution: 
        /**/

        public static string[] cities =
            {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

        // C.1 Write a program in C# Sharp to display the number and frequency of number from given array.
        /* Solution
         * 
         *  var c1 = Filters.numbers2
                .GroupBy(number => number)
                .Select(group => new 
                { 
                    Number = group.Key,
                    Count = group.Count()
                });
         */

        // C.2 Write a program in C# Sharp to display a list of unrepeated numbers.
        /* Solution
         * 
         *  var c2 = Filters.numbers2
                .Distinct().ToList();
         */

        // C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.
        /* Solution
         * 
         *  var c3 = Filters.numbers2
                .GroupBy(number => number)
                .Select(group => new
                {
                    Number = group.Key,
                    Product = group.Key * group.Count(),
                    Count = group.Count()
                });
         */
        public static int[] numbers2 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

        public static List<Student> students = new List<Student>()
            {
                new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
                new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
                new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {FirstName="Terry", LastName="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
            };

        // D.1 Get the top student of the list making an average of their scores.
        /*Solution
         * 
         *  var d1 = Filters.students
                .OrderByDescending(s => s.Scores.Average()).FirstOrDefault();
         */

        // D.2 Get the student with the lowest average score.
        /*Solution
         * 
         *   var d2 = Filters.students
                .OrderByDescending(s => s.Scores.Average()).LastOrDefault();
         */

        // D.3 Get the last name of the student that has the ID 117
        /*Solution
         * 
         *  var d3 = Filters.students
                .Find(s => s.ID.Equals(117)).LastName;
         */

        // D.4 Get the first name of the students that have any score more than 90
        /*Solution
         * 
         *  var d4 = Filters.students
                .Where(s => s.Scores.Any(s => s > 90))
                .Select(s => $"{s.FirstName}").ToList();
         */
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
