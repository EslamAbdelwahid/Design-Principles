using KissYagniTDV1.Common;
using KissYagniTDV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KissYagniTDV1.Service
{
    public class PaymentService
    {
        public Receipt ProcessPayment(decimal amount, string method)
        {
            if(string.Equals(method, Constants.Cash, StringComparison.OrdinalIgnoreCase))
            {
                amount -= amount * Constants.CashDiscount;
            }
            else if(string.Equals(method, Constants.Debit, StringComparison.OrdinalIgnoreCase))
            {
                amount += amount * Constants.DebitFees;
            }
            else
            {
                throw new ArgumentException("Invalid payment method");
            }

                return new Receipt
                {
                    Id = new Random().Next(1, 1000),
                    Amount = amount,
                    Method = method
                };
        }
    }
}
