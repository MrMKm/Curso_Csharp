using System;
using System.Collections.Generic;

namespace Predicates
{
    class Program
    {
        static void Predicates()
        {
            Predicate<int> predicate = new Predicate<int>(GetPrimos);

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> result = numbers.FindAll(predicate);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            static bool GetPairs(int num)
            {
                return num % 2 == 0 ? true : false;
            }

            static bool GetPrimos(int num)
            {
                if (num == 0 || num == 1)
                    return false;

                for (int i = num; i > num / 2; i++)
                    return num % i == 0 ? false : true;

                return true;
            }
        }

        static void Main(string[] args)
        {
            Predicates();
        }
    }
}
