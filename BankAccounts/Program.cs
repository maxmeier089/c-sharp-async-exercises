using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BankAccounts
{
    class Program
    {

        static BankAccount[] bankAccounts = new BankAccount[]
            {
                new BankAccount() { Balance = 0.0m },
                new BankAccount() { Balance = 0.0m },
                new BankAccount() { Balance = 0.0m },
                new BankAccount() { Balance = 0.0m },
                new BankAccount() { Balance = 0.0m }
            };


        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>()
            {
                new Thread(() => { MakeRandomTransfers(); }),
                new Thread(() => { MakeRandomTransfers(); }),
                new Thread(() => { MakeRandomTransfers(); }),
                new Thread(() => { MakeRandomTransfers(); }),
                new Thread(() => { MakeRandomTransfers(); })
            };

            threads.ForEach(t => t.Start());

            threads.ForEach(t => t.Join());

            Console.WriteLine("Sum: " + bankAccounts.Sum(account => account.Balance));

        }


        static void MakeRandomTransfers()
        {
            Random random = new Random();

            for (int n = 0; n < 1000; n++)
            {
                BankAccount a = bankAccounts[random.Next(bankAccounts.Count() - 1)];
                BankAccount b = bankAccounts[random.Next(bankAccounts.Count() - 1)];

                decimal amount = ((decimal)random.Next(10000)) / 100.0m;

                a.TransferTo(b, amount);
            }
        }

    }
}
