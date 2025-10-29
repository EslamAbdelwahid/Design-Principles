using KissYagniTDV2.Common;
using KissYagniTDV2.Models;

namespace KissYagniTDV2.Service
{
    public class CashPaymentStrategy : IPaymentStrategy
    {
        public Receipt ProcessPayment(decimal amount)
        {
            amount -= amount * Constants.CashDiscount;
            return new Receipt
            {
                Id = new Random().Next(1, 1000),
                Amount = amount,
                Method = Constants.Cash
            };
        }
    }
}
