using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    abstract class BaseNotification : BaseLogger, INotification
    {
        public abstract void Send(string recipient, string message);

        // Notification classes doesn't need this method.
        // I've initialized empty here so child classes doesn't have to
        public override void Log(string s) { }

        protected string CleanMessage(string msg) => msg.Trim();
    }
}
