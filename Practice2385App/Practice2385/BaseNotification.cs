using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    abstract class BaseNotification : INotification
    {
        protected abstract string Prefix { get; }

        protected string GetFormattedTime => $"{Prefix} {DateTime.Now:yyyy:MM:dd - HH:mm:ss}";

        protected string CleanMessage(string msg) => msg.Trim();

        public abstract void Send(string recipient, string message);
    }
}
