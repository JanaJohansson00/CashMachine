using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    // Factory Method mönster för att skapa olika typer av konton.
    // Detta gör att man kan skapa konton utan att veta en specifik klass som instansieras.
        public static class AccountFactory
        {
            public static Account CreateAccount(string type, string accountNumber)
            {
                switch (type.ToLower())
                {
                    case "savings":
                        return new SavingsAccount { AccountNumber = accountNumber };
                    case "checking":
                        return new CheckingAccount { AccountNumber = accountNumber };
                case "external":
                    return new ExternalBankAPIAdapter(accountNumber);
                default:
                        throw new ArgumentException("Invalid account type");
                }
            }
        }
}
