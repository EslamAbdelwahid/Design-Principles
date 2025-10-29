using KissYagniTDV2.Common;
using KissYagniTDV2.Models;

namespace KissYagniTDV2.Service
{
    public class DebitPaymentStrategy : IPaymentStrategy
    {
        public Receipt ProcessPayment(decimal amount)
        {
            amount += amount * Constants.DebitFees;
            return new Receipt
            {
                Id = new Random().Next(1, 1000),
                Amount = amount,
                Method = Constants.Debit
            };
        }
    }
}
