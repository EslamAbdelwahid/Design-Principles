using System;

namespace SOLID.SRP.EX3.Before
{

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        // Business logic
        public void Register()
        {
            Console.WriteLine("User registered");
        }

        // Validation
        public bool ValidateEmail()
        {
            return Email.Contains("@");
        }

        // Persistence
        public void SaveToDatabase()
        {
            Console.WriteLine("Saving user to database...");
        }

        // Communication
        public void SendWelcomeEmail()
        {
            Console.WriteLine($"Sending welcome email to {Email}");
        }
    }

}
