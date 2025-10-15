using System;

namespace SOLID.LSP.After
{
    class CheckingAccount : RegularAccount
    {
        public CheckingAccount(string name, decimal balance) 
            : base(name, balance)
        {
        }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Done Successfully, your Balance now is {Balance}");
        }

        public override void Withdraw(decimal amount)
        {
            if (amount > 1000)
            {
                Console.WriteLine("You cant withdram more than $1000");
                return;
            }
            Console.WriteLine("Amound is Withdrawed successfully.");
            Balance -= amount;
        }
    }
}
