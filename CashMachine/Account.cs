using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    // Abstrakt basklass, definerar de grundläggande egenskaperna och metoderna som konton ska ha.
    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);

        protected void Notify()
        {
            Console.WriteLine($"{this.GetType().Name} {AccountNumber} balance updated: {Balance}");
        }
    }
}
