using System;
using System.Threading;

namespace SharedDataFixed
{
    class Program
    {
        static void Main(string[] args)
        {
            CountTo100 counter = new CountTo100();

            Thread t1 = new Thread(() =>
            {
                for (int n = 0; n < 100; n++)
                {
                    counter.NextNumber();
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int n = 0; n < 100; n++)
                {
                    counter.NextNumber();
                }
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(counter.Number);
        }
    }
}
