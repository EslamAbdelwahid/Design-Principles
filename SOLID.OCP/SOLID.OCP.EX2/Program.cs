using System;

namespace SOLID.OCP.EX2.After
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Test 1: Credit Card + Email + Bulk Discount ===");
            var payment1 = new PaymentProcessor(
                new CreditCardPayment(),
                new EmailClient(),
                new TransactionLogger(),
                new BulkDiscount()
            );
            payment1.ProcessPayment(1500, "user1@example.com");

            Console.WriteLine("\n=== Test 2: PayPal + SMS + Seasonal Discount ===");
            var payment2 = new PaymentProcessor(
                new PayPalPayment(),
                new SmsNotifier(),
                new TransactionLogger(),
                new SeasonalDiscount()
            );
            payment2.ProcessPayment(800, "+201001234567");

            Console.WriteLine("\n=== Test 3: Crypto + Email + No Discount ===");
            var payment3 = new PaymentProcessor(
                new CryptoPayment(),
                new EmailClient(),
                new TransactionLogger(),
                new NoDiscount()
            );
            payment3.ProcessPayment(500, "crypto_user@example.com");

            Console.WriteLine("\n=== Test 4: Add New Type Without Changing Code ===");
            var payment4 = new PaymentProcessor(
                new BankTransferPayment(),
                new SmsNotifier(),
                new TransactionLogger(),
                new BulkDiscount()
            );
            payment4.ProcessPayment(2500, "+201009876543");

            Console.WriteLine("\nAll tests completed successfully.");
        }
    }

    // New type: no need to modify PaymentProcessor
    public class BankTransferPayment : IPaymentMethod
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Processing bank transfer of " + amount);
        }
    }

    // New type: a no-discount strategy
    public class NoDiscount : IDiscount
    {
        public double Apply(double amount)
        {
            Console.WriteLine("No discount applied.");
            return amount;
        }
    }
}
