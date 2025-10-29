using KissYagniTDV2.Models;

namespace KissYagniTDV2.Service
{
    public interface IPaymentStrategy
    {
        Receipt ProcessPayment(decimal amount);
    }
}
