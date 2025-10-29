using KissYagniTDV2.Common;
using KissYagniTDV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KissYagniTDV2.Service
{

    public class PaymentService
    {
        private readonly Dictionary<string, IPaymentStrategy> _paymentStrategies;
        public PaymentService()
        {
            
            _paymentStrategies = new Dictionary<string, IPaymentStrategy>(StringComparer.OrdinalIgnoreCase)
            {
                { Constants.Cash, new CashPaymentStrategy() },
                { Constants.Debit, new DebitPaymentStrategy() }
            };
        }
        public Receipt ProcessPayment(decimal amount, string method)
        {
            if(_paymentStrategies.ContainsKey(method))
            {
                return _paymentStrategies[method].ProcessPayment(amount);
            }
            else {  throw new NotSupportedException($"Payment method {method} is not supported."); } 

        }
    }
}
