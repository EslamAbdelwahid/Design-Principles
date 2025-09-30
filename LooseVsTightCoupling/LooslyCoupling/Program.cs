namespace LooslyCoupling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new List<INotificationService> 
            { NotificationServiceFactory.Create(NotificationType.EMAIL),
              NotificationServiceFactory.Create(NotificationType.SMS)};

            var notificationService = new NotificationService(services);
            notificationService.Notify();
        }
    }

    public class NotificationServiceFactory
    {
        public static INotificationService Create(NotificationType _type)
        {
            switch (_type)
            {
                case NotificationType.EMAIL:
                    return new EmailService();
                case NotificationType.SMS:
                    return new SMSService();
                default:
                    return new EmailService();
            }
        }
    }
    public enum NotificationType
    {
        EMAIL, 
        SMS,
    }
    public interface INotificationService
    {
        void Send();
    }
    public class EmailService : INotificationService
    {
        public void Send()
        {
            Console.WriteLine("Email Sent..");
        }
    }
    public class SMSService : INotificationService 
    {
        public void Send()
        {
            Console.WriteLine("SMS Sent...");
        }
    }
    public class NotificationService
    {
        public readonly IEnumerable<INotificationService> _notificationServices;

        public NotificationService(IEnumerable<INotificationService> notificationServices)
        {
            _notificationServices = notificationServices;
        }

        public void Notify()
        {
            foreach(var notificationService in _notificationServices)
            {
                notificationService.Send();
            }
        }
    }
}
