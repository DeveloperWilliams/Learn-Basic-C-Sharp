/* * Banking Application
 * 
 * This program demonstrates the use of interfaces in C# by creating a BankAccount interface
 * and implementing it in a SavingsAccount class. The program allows deposits and withdrawals
 * while enforcing rules and fees.
 * 
 * Key Features:
 * - Interface for bank account operations
 * - Implementation in SavingsAccount class
 * - Deposit and withdrawal methods with validation
 * - Account information retrieval
 * 
 * To compile and run:
 * 1. Ensure .NET SDK is installed
 * 2. Navigate to project directory in terminal
 * 3. Execute: `dotnet run`
 */

using System;

namespace BankingApp
{
    public interface IBankAccount
    {
        decimal Balance { get; }   // read-only
        void Deposit(decimal amount);
        bool Withdraw(decimal amount);
        string GetAccountInfo();
    }

    public class SavingsAccount : IBankAccount
    {
        public string AccountNumber { get; }
        public string OwnerName { get; }
        public decimal Balance { get; private set; }

        public SavingsAccount(string ownerName, string accountNumber, decimal initialBalance)
        {
            OwnerName = ownerName;
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            decimal totalWithdrawal = amount * 1.01m; // 1% fee

            if (totalWithdrawal > Balance)
                return false; // insufficient funds

            Balance -= totalWithdrawal;
            return true;
        }

        public string GetAccountInfo()
        {
            return $"Savings Account {AccountNumber} - Owner: {OwnerName}, Balance: ${Balance:F2}";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            IBankAccount account = new SavingsAccount("William Achuchi", "Acc001", 1000m);

            account.Deposit(500m);
            Console.WriteLine("Deposited $500");

            bool success1 = account.Withdraw(2000m);
            Console.WriteLine($"Withdrawal of $2000 {(success1 ? "succeeded" : "failed")}");

            bool success2 = account.Withdraw(200m);
            Console.WriteLine($"Withdrawal of $200 {(success2 ? "succeeded" : "failed")}");

            Console.WriteLine(account.GetAccountInfo());
        }
    }
}
