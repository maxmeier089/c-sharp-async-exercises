using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccounts
{
    public  class BankAccount
    {

        public decimal Balance { get; set; }


        private static object LockObject = new object();

        private bool TransferTakesPlace = false;


        public void TransferTo(BankAccount otherAccount, decimal amount)
        {
            while (true)
            {
                lock (LockObject)
                {
                    if (!(TransferTakesPlace || otherAccount.TransferTakesPlace))
                    {
                        TransferTakesPlace = true;
                        otherAccount.TransferTakesPlace = true;
                        break;
                    }
                }
            }

            Balance -= amount;
            otherAccount.Balance += amount;

            TransferTakesPlace = false;
            otherAccount.TransferTakesPlace = false;
        }

        public BankAccount()
        {
            Balance = 0m;
        }

    }
}
