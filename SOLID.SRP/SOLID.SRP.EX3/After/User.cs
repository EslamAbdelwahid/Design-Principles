using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SOLID.SRP.EX3.After
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }


    }
    public interface IUserValidator
    {
        bool Validate(User user);
    }
    public class ValidateEmail : IUserValidator
    {

        public bool Validate(User user)
        {
            return !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@");
        }
    }

    public interface IUserRepo
    {
        void Save(User user);
    }

    public class DbUserRepo : IUserRepo
    {
        public void Save(User user)
        {
            Console.WriteLine($"Saving user {user.Name} to Database...!");
        }
    }
    // Imagine if you didn't use this Interface you will got these problems
      // 1. If you want to use SendGrid instead of SMTP → you must edit UserRegistrationService.
      // 2. If you want to unit test → you’ll actually send real emails (or fail).
    public interface IEmailService
    {
        public void SendWelcomeEmail(string email);
    }
    public class SmtpEmailService : IEmailService
    {
        public void SendWelcomeEmail(string email)
        {
            Console.WriteLine($"Sending welcome email to {email}");

        }
    }

    public class UserRegistrationService
    {
        private readonly IUserValidator _userValidator;
        private readonly IUserRepo _userRepo;
        private readonly IEmailService _emailService;
        public UserRegistrationService(IUserValidator userValidator, IUserRepo userRepo, IEmailService emailService)
        {
            _userValidator = userValidator;
            _userRepo = userRepo;
            _emailService = emailService;
        }

        public void Register(User user)
        {
            if(_userValidator.Validate(user) == false)
            {
                Console.WriteLine("Invalid user data. Registration failed.");
                return;
            }
            _userRepo.Save(user);
            _emailService.SendWelcomeEmail(user.Email);
            Console.WriteLine("User registration successful.");
        }

    }
}
