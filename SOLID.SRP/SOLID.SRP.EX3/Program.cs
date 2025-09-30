using SOLID.SRP.EX3.After;

namespace SOLID.SRP.EX3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create dependencies
            IUserValidator validator = new ValidateEmail();
            IUserRepo repo = new DbUserRepo();
            IEmailService emailService = new SmtpEmailService();

            // Create service with dependencies injected
            var registrationService = new UserRegistrationService(validator, repo, emailService);

            // Create a valid user
            var user1 = new User { Name = "Eslam", Email = "eslam@test.com" };
            registrationService.Register(user1);

            Console.WriteLine();

            // Create an invalid user (missing email)
            var user2 = new User { Name = "Ali", Email = "" };
            registrationService.Register(user2);

            Console.WriteLine();

            // Create an invalid user (bad email format)
            var user3 = new User { Name = "Sara", Email = "sara_at_test.com" };
            registrationService.Register(user3);
        }
    }
}
