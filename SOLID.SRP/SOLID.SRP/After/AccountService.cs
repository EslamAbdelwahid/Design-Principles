using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SRP.After
{
    public class AccountService
    {
        public readonly IEmailClient _emailClient;
        public AccountService(IEmailClient emailClient)
        {

            _emailClient = emailClient;

        }
        public void WithDraw(Account account, decimal amount)
        {
            var transactionMessage = "";
            if (account.Balance < Math.Abs(amount))
            {
                transactionMessage =
                $"OVERDRAFT when trying to withdraw " +
                $"{Math.Abs(amount).ToString("C2")}," +
                $" current balance {account.Balance.ToString("C2")}";
            }
            else
            {
                account.Balance += amount;
                transactionMessage =
                   $"OK Withdraw {Math.Abs(amount).ToString("C2")}" +
                   $", current balance {account.Balance.ToString("C2")}";
            }
            _emailClient.Send(account, transactionMessage);
        }
        public void Deposit(Account account, decimal amount) // amount +/-
        {
            var transactionMessage = "";
            if (amount > 0)
            {
                account.Balance += amount;

                transactionMessage =
                    $"OK Deposit {amount.ToString("C2")}" +
                    $", current balance {account.Balance.ToString("C2")}";
            }
            _emailClient.Send(account, transactionMessage);
        }
    }
}
