
using System.Collections.Generic;

namespace SOLID.DIP.After
{

    internal class NotificationService
    {
        private readonly List<IMessageService> _messageServices;

        public NotificationService(List<IMessageService> messageServices)
        {
            _messageServices = messageServices;
        }
        public void Notify()
        { 
            foreach (var service in _messageServices)
            {
                service.Send();
            }
        }
    }
}
