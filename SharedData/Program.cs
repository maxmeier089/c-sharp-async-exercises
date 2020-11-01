using System;
using System.Threading;

namespace SharedData
{
    class Program
    {
        static void Main(string[] args)
        {
            int data = 0;

            new Thread(() =>
            {
                while (data < 100)
                {
                    Console.WriteLine(data);
                    data++;
                }
            }).Start();

            new Thread(() =>
            {
                while (data < 100)
                {
                    Console.WriteLine(data);
                    data++;
                }
            }).Start();
        }
    }
}
