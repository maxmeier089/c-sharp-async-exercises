using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GuessMyLuckyNumber
{
    class Program
    {

        static readonly int MAX_NUMBER = 10000000;
        static readonly int NUMBER_OF_TASKS = 10;

        static void Main(string[] args)
        {
            Random random = new Random();

            while (true)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                int luckyNumber = random.Next(MAX_NUMBER);

                Console.WriteLine("Lucky number generated!");

                bool stillGuessing = true;

                List<Task> tasks = new List<Task>();

                for (int t = 0; t < NUMBER_OF_TASKS; t++)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        Random random = new Random();

                        while (stillGuessing)
                        {
                            int guess = random.Next(MAX_NUMBER);

                            if (guess == luckyNumber)
                            {
                                stillGuessing = false;
                                Console.WriteLine("Found! " + guess);
                            }
                        }

                    }));
                };

                tasks.ForEach(t => t.Wait());

                stopwatch.Stop();

                Console.WriteLine("Guessed in " + stopwatch.ElapsedMilliseconds + " ms\n");

                Console.ReadLine();

            }
        }
    }
}
