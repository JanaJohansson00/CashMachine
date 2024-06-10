using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    // Ärver från Account och implementerar unika beteenden för insättning och uttag.
    public class SavingsAccount : Account
    {
        public override void Deposit(decimal amount)
        {
            Balance += amount;
            Notify();
        }

        public override void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Notify();
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
    }
}
