using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class Asynchronous
    {
        public static async Task WaitForIt()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("2 seconds completed");
        }

        public static async Task WaitForIt2()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("5 seconds completed");
        }
    }

    class Parallelism
    {
        public static async Task<long> Test()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var task1 = Process();
            var task2 = Process2();

            await Task.WhenAll(task1, task2);

            //await Process(); 
            //await Process2();

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        public static async Task Process()
        {
            await Task.Run(() => {
                Thread.Sleep(3000);
            });
        }

        public static async Task Process2()
        {
            await Task.Run(() => {
                Thread.Sleep(1000);
            });
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            //Asynchronous.WaitForIt();
            //await Asynchronous.WaitForIt2();

            var timeElapsed = await Parallelism.Test();
            Console.WriteLine(timeElapsed / 1000m);
        }
    }
}
