using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> Scores { get; set; }
    }

    class ExtraExamples
    {
        Action line = () => Console.WriteLine("Hello");

        Func<int, int, string> IsTooLong = (x, y) => x > y ? "Higher" : "Lower";

        Func<int, int, (bool IsCorrect, string Message)> TupleFunc = (x, y) => (x > y, "My message");

        static (bool IsCorrect, string Message) MyTuple()
        {
            return (true, "My Message");
        }

        static string IsTooLong2(int x, int y) => x > y ? "Higher" : "Lower";

        static void LINQExamples()
        {
            List<Student> students = new List<Student>() 
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

            var studentQuery = 
                from student in students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Scores[0]
                select student;

            var studentQueryLambda = students
                .Where(student => student.Scores[0] > 90 && student.Scores[3] < 80)
                .OrderBy(student => student.Scores[0]);

            var studentQuery2 =
                from student in students
                group student by student.LastName[0]
                into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            var studentQueryLambda2 = students
                .GroupBy(student => student.LastName[0])
                .OrderBy(group => group.Key);

            var studentQuery3 =
                from student in students
                let totalScore = student.Scores.Sum()
                where student.Scores.Average() < student.Scores[0]
                select student;

            var studentQuery3Lambda = students
                .Where(student => student.Scores.Sum() / students.Count < student.Scores[0]);

            var lastName = "Garcia";
            var studentQuery4 =
                from student in students
                where student.LastName.Equals(lastName)
                select student;

            var studentQuery4Lambda = students
                .Where(student => student.LastName.Equals(lastName));

            var studentQuery5 =
                from student in students
                let totalScore = student.Scores.Sum()
                where totalScore > 90
                select new { ID = student.ID, Score = totalScore };

            var studentQuery5Lambda = students
                .Where(student => student.Scores.Sum() > 90)
                .Select(student => new
                {
                    ID = student.ID,
                    Score = student.Scores.Sum()
                });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
