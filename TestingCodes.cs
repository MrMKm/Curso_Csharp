using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject_1
{
    public class Student
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Student(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }

    class TestingCodes
    {
        static Student GetByName(string name, List<Student> students)
        {
            Student student = students.Find(x => x.Name.Equals(name));
            return student;
        }

        static Student GetByID(int id, List<Student> students)
        {
            Student student = students.Find(x => x.ID.Equals(id));
            return student;
        }

        static List<Student> DeleteByName(string name, List<Student> students)
        {
            students.RemoveAll(x => x.Name.Equals(name));
            return students;
        }

        static List<Student> DeleteByID(int ID, List<Student> students)
        {
            students.RemoveAll(x => x.ID.Equals(ID));
            return students;
        }

        static List<Student> ClearList(List<Student> students)
        {
            students.Clear();
            return students;
        }

        static List<Student> ReverseList(List<Student> students)
        {
            students.Reverse();
            return students;
        }

        static List<Student> InsertInMiddle(Student student, List<Student> students)
        {
            students.Insert((students.Count - 1) / 2, student);
            return students;
        }

        static int[] rotLeft(int rotations, int[] numbers)
        {
            int elements = numbers.Length;
            int[] newArray = new int[elements];

            for (int i = 0; i < elements; i++)
            {
                int newIndex = (i + elements - rotations) % elements;
                newArray[newIndex] = numbers[i];
            }

            return newArray;
        }

        static int countingValleys(string steps)
        {
            int seaLevel = 0;
            int valleys = 0;

            foreach (char step in steps)
            {
                if (step == 'U')
                    seaLevel += 1;

                else if(step == 'D')
                    seaLevel -= 1;

                if (step == 'D' && seaLevel == 0)
                    valleys += 1;
            }

            return valleys;
        }

        static void minimunBribes(int[] numbers)
        {
            int bribes = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != (i + 1))
                {
                    if(numbers[i] - (i + 1) > 2)
                    {
                        Console.WriteLine("Too chaotic");
                        return;
                    }

                    bribes += (numbers[i] - (i + 1)) > 0 ? (numbers[i] - (i + 1)) : 0;
                }
            }

            Console.WriteLine(bribes);
        }

        static void Main(string[] args)
        {

        }
    }
}
