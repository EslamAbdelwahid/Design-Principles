using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.EX2.Before
{
    public class PaymentProcessor
    {
        public void ProcessPayment(string paymentType, double amount, string email)
        {
            if (paymentType == "CreditCard")
            {
                Console.WriteLine("Processing credit card payment of " + amount);
                // Credit card processing logic
            }
            else if (paymentType == "PayPal")
            {
                Console.WriteLine("Processing PayPal payment of " + amount);
                // PayPal processing logic
            }
            else if (paymentType == "Crypto")
            {
                Console.WriteLine("Processing crypto payment of " + amount);
                // Crypto processing logic
            }

            // Discount logic
            if (amount > 1000)
            {
                amount *= 0.9;
                Console.WriteLine("Applied 10% discount, new amount: " + amount);
            }

            // Send email
            Console.WriteLine("Sending email to " + email);

            // Logging
            Console.WriteLine("Transaction logged.");
        }
    }

}
