namespace TightCoupling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var notificationService = new NotificationService(new EmailService(), new SMSService());
            notificationService.Notify();
        }
    }

    public class EmailService
    {
        public void Send()
        {
            Console.WriteLine("Email Sent..");
        }
    }
    public class SMSService
    {
        public void Send()
        {
            Console.WriteLine("SMS Sent...");
        }
    }
    public class NotificationService
    {
        public readonly EmailService _emailService;
        public readonly SMSService _smssService;

        public NotificationService(EmailService email, SMSService sMSService)
        {
            _emailService = email;
            _smssService = sMSService;
        }

        public void Notify()
        {
            _emailService.Send();
            _smssService.Send();
        }
    }
}
