using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.EX2.After
{
    public interface INotificationService
    {
        void Send(string recipient);
    }

    public class EmailClient : INotificationService
    {
        public void Send(string recipient)
        {
            Console.WriteLine("Sending email to " + recipient);
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }
    public class TransactionLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
    public interface IDiscount
    {
        double Apply(double amount);
    }
    public class BulkDiscount : IDiscount
    {
        public double Apply(double amount)
        {
            if (amount > 1000)
            {
                amount *= 0.9;
                Console.WriteLine("Applied 10% discount, new amount: " + amount);
            }
            return amount;
        }
    }
    public interface IPaymentMethod
    {
        void Pay(double amount);
    }
    public class CreditCardPayment : IPaymentMethod
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Processing credit card payment of " + amount);
        }
    }
    public class PayPalPayment : IPaymentMethod
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Processing PayPal payment of " + amount);
        }
    }
    public class CryptoPayment : IPaymentMethod
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Processing crypto payment of " + amount);
        }
    }

    // if you want to extend now: 
    public class SmsNotifier : INotificationService
    {
        public void Send(string recipient)
        {
            Console.WriteLine("Sending SMS to " + recipient);
        }
    }

    public class SeasonalDiscount : IDiscount
    {
        public double Apply(double amount)
        {
            Console.WriteLine("Applied 5% seasonal discount");
            return amount * 0.95;
        }
    }

    public class PaymentProcessor
    {
        private readonly IPaymentMethod paymentMethod;
        private readonly INotificationService notificationService;
        private readonly ILogger logger;
        private readonly IDiscount discount;

        public PaymentProcessor(IPaymentMethod paymentMethod,INotificationService notificationService, ILogger logger, IDiscount discount)
        {
            this.paymentMethod = paymentMethod;
            this.notificationService = notificationService;
            this.logger = logger;
            this.discount = discount;
        }
        public void ProcessPayment(double amount, string email)
        {

            amount = discount.Apply(amount);

            paymentMethod.Pay(amount);

            // Send email
            notificationService.Send(email);

            // Logging
            logger.Log("Transaction logged.");
        }

    }
}
