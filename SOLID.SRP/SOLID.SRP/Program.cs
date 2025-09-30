using SOLID.SRP.After;
using System.Diagnostics.Metrics;

namespace SOLID.SRP.EX1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmailClient emailClient = new EmailClient();
            //TestWithoutSRP(); 
            TestWithSRP(emailClient);
            Console.ReadKey();
        }


        private static void TestWithoutSRP()
        {
            var account =
                new Before.Account("Reem", "reem@example.com", 10000m);
            account.MakeTransaction(500);
            account.MakeTransaction(-11000);
        }

        private static void TestWithSRP(IEmailClient emailClient)
        {
            var account =
                new After.Account("Reem", "reem@example.com", 10000m);

            var accountService = new After.AccountService(emailClient);
            accountService.Deposit(account, 500);
            accountService.WithDraw(account, 11000);
        }


    }
}
