using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelismChallenge
{
    class Program
    {
        public static async Task<Tuple<double, int>> Test(int limitTime)
        {
            var stopWatch = new Stopwatch();
            int score = 0, counter = 0;

            stopWatch.Start();

            while (stopWatch.Elapsed.TotalSeconds < limitTime && counter < 5)
            {
                score += await QuestionSolver(await NumbersGenerator());
                counter += 1; 
            }

            stopWatch.Stop();
            return Tuple.Create(stopWatch.Elapsed.TotalSeconds, score);
        }

        public static async Task<Tuple<int, int>> NumbersGenerator()
        {
            var numbers = Tuple.Create(0, 0);

            await Task.Run(() => {
                Random random = new Random();
                numbers = Tuple.Create(random.Next(0, 10), random.Next(0, 10));
            });

            return numbers;
        }

        public static async Task<int> QuestionSolver(Tuple<int, int> numbers)
        {
            int score = 0;

            await Task.Run(() => {
                Random random = new Random();

                if (random.Next(1, 4) == 1)
                {
                    Console.WriteLine(numbers.Item1 + " + " + numbers.Item2 + '?');
                    try
                    {
                        if (Convert.ToInt32(Console.ReadLine()) == (numbers.Item1 + numbers.Item2))
                            score += 1;
                        Console.WriteLine();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                else if (random.Next(1, 4) == 2)
                {
                    Console.WriteLine(numbers.Item1 + " - " + numbers.Item2 + '?');
                    try
                    {
                        if (Convert.ToInt32(Console.ReadLine()) == (numbers.Item1 - numbers.Item2))
                            score += 1;
                        Console.WriteLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                else
                {
                    Console.WriteLine(numbers.Item1 + " * " + numbers.Item2 + '?');
                    try
                    {
                        if (Convert.ToInt32(Console.ReadLine()) == (numbers.Item1 * numbers.Item2))
                            score += 1;
                        Console.WriteLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            });

            return score;
        }

        static async Task Main(string[] args)
        {
            int limitTime = 15;
            var results = await Test(limitTime);

            if (results.Item1 < limitTime)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Time: " + results.Item1);
                Console.WriteLine("Score: " + results.Item2);
            }

            else
            {
                Console.WriteLine("Time out...");
                Console.WriteLine("Score: " + Math.Abs(results.Item2 - 1));
            }
        }
    }
}
