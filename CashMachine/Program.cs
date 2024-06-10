namespace CashMachine
{
    internal class Program
    {

        // Denna applikation implementerar följande designmönster:
        // 1. Singleton: Används i ATMSystem klassen för att säkerställa att endast en instans av systemet finns.
        // 2. Factory Method: Används i AccountFactory klassen för att skapa olika typer av konton.
        // 3. Adapter: Används i ExternalBankAPIAdapter klassen för att anpassa en extern bank API till Account gränssnittet.

        static void Main(string[] args)
        {
            ATMSystem atmSystem = ATMSystem.Instance;

            // Skapa konton med Factory Method
            Account savings = AccountFactory.CreateAccount("savings", "S123");
            Account checking = AccountFactory.CreateAccount("checking", "C123");
            Account external = AccountFactory.CreateAccount("external", "EXT123");

            atmSystem.AddAccount(savings);
            atmSystem.AddAccount(checking);
            atmSystem.AddAccount(external);

            while (true)
            {
                Console.WriteLine("Welcome to the ATM System");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Please choose an option: ");
                var choice = Console.ReadLine();

                if (choice == "4") break;

                Console.Write("Enter account number: ");
                var accountNumber = Console.ReadLine();
                var account = atmSystem.GetAccount(accountNumber);

                if (account == null)
                {
                    Console.WriteLine("Invalid account number.");
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter amount to deposit: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            account.Deposit(depositAmount);
                            Console.WriteLine($"Deposited {depositAmount} to account {accountNumber}. New balance: {account.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter amount to withdraw: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        {
                            account.Withdraw(withdrawAmount);
                            Console.WriteLine($"Withdrew {withdrawAmount} from account {accountNumber}. New balance: {account.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case "3":
                        Console.WriteLine($"Current balance: {account.Balance}");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.WriteLine();
            }
        }
    }
}
