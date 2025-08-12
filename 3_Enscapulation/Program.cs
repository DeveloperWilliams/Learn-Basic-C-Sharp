/*
 * Banking Encapsulation Application
 * 
 * This program demonstrates encapsulation in C# by creating a BankAccount class
 * that manages the balance and enforces rules for deposits and withdrawals.
 * 
 * Key Features:
 * - Private field for balance
 * - Public property with validation
 * - Methods for deposit and withdrawal with error handling
 * 
 * The program creates a BankAccount object, performs transactions, and handles errors.
 * 
 * To compile and run:
 * 1. Ensure .NET SDK is installed
 * 2. Navigate to project directory in terminal
 * 3. Execute: `dotnet run`
 */
// Note: Uncomment the error test lines to see exception handling in action.

using System;

namespace BankingEncapsulation
{
    public class BankAccount
    {
        private decimal _balance;

        public decimal Balance
        {
            get { return _balance; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Balance cannot be negative");
                _balance = value;
            }
        }

        public BankAccount(decimal balance)
        {
            Balance = balance; // Triggers validation
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 49)
                throw new ArgumentException("Amount must be at least 50");

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 50)
                throw new ArgumentException("You can't withdraw less than 50 bob");

            if (amount > Balance)
                throw new ArgumentException("You can't withdraw more than your balance");

            Balance -= amount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount myAccount = new BankAccount(500);
            Console.WriteLine($"Initial balance: {myAccount.Balance}");

            // Deposit
            myAccount.Deposit(300);
            Console.WriteLine($"Balance after deposit: {myAccount.Balance}");

            // Withdraw
            myAccount.Withdraw(100);
            Console.WriteLine($"Balance after withdrawal: {myAccount.Balance}");

            // Test errors
            //myAccount.Deposit(10);
            // Console.WriteLine($"Balance after invalid deposit: {myAccount.Balance}");
            // myAccount.Withdraw(10);
            // Console.WriteLine($"Balance after invalid withdrawal: {myAccount.Balance}");
        }
    }
}
