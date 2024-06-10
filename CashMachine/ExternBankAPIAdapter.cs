using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    // Adapter mönster som anpassar klassen till Account gränssnittet.
    public class ExternalBankAPIAdapter : Account
    {
        private ExternalBankAPI _externalBankAPI = new ExternalBankAPI();

        public ExternalBankAPIAdapter(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = _externalBankAPI.GetBalance(accountNumber);
        }

        public override void Deposit(decimal amount)
        {
            _externalBankAPI.MakeDeposit(AccountNumber, amount);
            Balance += amount;
            Notify();
        }

        public override void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                _externalBankAPI.MakeWithdrawal(AccountNumber, amount);
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
