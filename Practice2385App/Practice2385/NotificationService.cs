using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    class NotificationService
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

    class Notify
    {
        INotification _notification;

        public Notify(INotification notification)
        {
            _notification = notification;
        }

        public void NotifyOne(string recipient, string message)
        {
            _notification.Send(recipient, message);
        }
    }
}
