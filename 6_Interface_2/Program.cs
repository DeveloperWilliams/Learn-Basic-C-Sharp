/* * Card Payment Application
 * This application simulates different payment methods with varying fees.
 * Each payment method implements the IPaymentMethod interface.
 * The program demonstrates polymorphism by allowing different payment methods to be used interchangeably.

 * Key Features:
 * - Supports multiple payment methods
 * - Each method has its own fee structure
 * - Easy to add new payment methods
 * - Demonstrates polymorphism with interface usage

    * To compile and run:
    * 1. Ensure .NET SDK is installed
    * 2. Navigate to project directory in terminal
    * 3. Execute: `dotnet run`

 */

using System;

namespace CardPaymentApp
{
    public interface IPaymentMethod
    {
        string MethodName { get; }
        decimal Balance { get; }
        void Pay(decimal amount);
        void Load(decimal amount);
        string GetPaymentInfo();
    }

    // 1. Credit Card (2% fee)
    public class CreditCard : IPaymentMethod
    {
        public string CardNumber { get; }
        public string CardHolder { get; }
        public string MethodName { get; }
        public decimal Balance { get; private set; }

        public CreditCard(string cardHolder, string cardNumber, string methodName, decimal balance)
        {
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            MethodName = methodName;
            Balance = balance;
        }

        public void Pay(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Payment must be greater than 0.");

            decimal total = amount * 1.02m; // 2% fee
            if (total > Balance)
                throw new ArgumentException("Insufficient funds.");

            Balance -= total;
        }

        public void Load(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Load amount must be positive.");
            Balance += amount;
        }

        public string GetPaymentInfo()
        {
            return $"[CreditCard] {CardHolder} - {CardNumber}, Balance: ${Balance:F2}";
        }
    }

    // 2. Mobile Money (1% fee)
    public class MobileMoney : IPaymentMethod
    {
        public string PhoneNumber { get; }
        public string MethodName { get; }
        public decimal Balance { get; private set; }

        public MobileMoney(string phoneNumber, string methodName, decimal balance)
        {
            PhoneNumber = phoneNumber;
            MethodName = methodName;
            Balance = balance;
        }

        public void Pay(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Payment must be positive.");

            decimal total = amount * 1.01m; // 1% fee
            if (total > Balance) throw new ArgumentException("Insufficient balance.");

            Balance -= total;
        }

        public void Load(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Load amount must be positive.");
            Balance += amount;
        }

        public string GetPaymentInfo()
        {
            return $"[MobileMoney] {PhoneNumber}, Balance: ${Balance:F2}";
        }
    }

    // 3. PayPal (no fee)
    public class PayPal : IPaymentMethod
    {
        public string Email { get; }
        public string MethodName { get; }
        public decimal Balance { get; private set; }

        public PayPal(string email, string methodName, decimal balance)
        {
            Email = email;
            MethodName = methodName;
            Balance = balance;
        }

        public void Pay(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Payment must be positive.");
            if (amount > Balance) throw new ArgumentException("Insufficient PayPal balance.");

            Balance -= amount;
        }

        public void Load(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Load must be positive.");
            Balance += amount;
        }

        public string GetPaymentInfo()
        {
            return $"[PayPal] {Email}, Balance: ${Balance:F2}";
        }
    }

    // 4. Bank Transfer (flat $5 fee)
    public class BankTransfer : IPaymentMethod
    {
        public string AccountNumber { get; }
        public string BankName { get; }
        public string MethodName { get; }
        public decimal Balance { get; private set; }

        public BankTransfer(string accountNumber, string bankName, string methodName, decimal balance)
        {
            AccountNumber = accountNumber;
            BankName = bankName;
            MethodName = methodName;
            Balance = balance;
        }

        public void Pay(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Payment must be positive.");

            decimal total = amount + 5m; // flat $5 fee
            if (total > Balance) throw new ArgumentException("Insufficient balance for bank transfer.");

            Balance -= total;
        }

        public void Load(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Load must be positive.");
            Balance += amount;
        }

        public string GetPaymentInfo()
        {
            return $"[BankTransfer] {BankName} - {AccountNumber}, Balance: ${Balance:F2}";
        }
    }

    // --- Program Runner ---
    public class Program
    {
        public static void Main(string[] args)
        {
            IPaymentMethod[] payments = new IPaymentMethod[]
            {
                new CreditCard("William Achuchi", "1234-5675-8901", "Visa", 500m),
                new MobileMoney("+254708966189", "M-Pesa", 300m),
                new PayPal("william@example.com", "PayPal", 1000m),
                new BankTransfer("0011223344", "Equity Bank", "BankTransfer", 2000m)
            };

            foreach (var method in payments)
            {
                Console.WriteLine($"--- Using {method.MethodName} ---");

                method.Load(200m);
                Console.WriteLine("Loaded $200");

                try
                {
                    method.Pay(100m);
                    Console.WriteLine("Payment of $100 succeeded");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Payment failed: {ex.Message}");
                }

                Console.WriteLine(method.GetPaymentInfo());
                Console.WriteLine();
            }
        }
    }
}
