using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    class NotificationModel
    {
        public class EmailNotification : INotification
        {
            public void Send(string recipent, string message)
            {

            }
        }

        public class SmsNotification : INotification
        {
            public void Send(string recipent ,string message)
            {

            }
        }

        public class Notification
        {
            INotification _notification;

            public Notification(INotification notification)
            {
                _notification = notification;
            }

            public void Send(string recipient, string message)
            {
                _notification.Send(recipient, message);
            }
        }

        public class NotificationService
        {
            private readonly List<INotification> _providers = new();

            public void AddProvider(INotification provider)
            {
                _providers.Add(provider);
            }

            public void NotifyAll(string recipient, string message)
            {
                foreach (var provider in _providers)
                {
                    provider.Send(recipient, message);
                }
            }
        }
    }
}
