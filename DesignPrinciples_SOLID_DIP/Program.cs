using System;
using System.Collections.Generic;

namespace SOLID.DIP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var customers = Before.Repository.Customers;

            //foreach (var customer in customers)
            //{
            //    var notificationService = new Before.NotificationService(customer);
            //    notificationService.Notify();
            //}

            var customers = Before.Repository.Customers;
            foreach (var customer in customers)
            {
                var messageService = new List<After.IMessageService>
                {
                    new After.EmailService {EmailAddress = customer.EmailAddress },
                    new After.SMSService {MobileNo = customer.MobileNo },
                    new After.MailService {Address = customer.Address}
                };

                // constructor injection
                var notificationService = new After.NotificationService(messageService);
                notificationService.Notify();
            }

            Console.ReadKey();
        }
    }
}
