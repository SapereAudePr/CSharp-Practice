using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    class NotificationModel
    {
        public class EmailNotification : BaseNotification
        {
            public override void Send(string recipient, string message)
            {
                string cleanMsg = CleanMessage(message);
                string getTime = GetTime("email");
                Console.WriteLine($"{getTime} | to {recipient} : {cleanMsg} ");
            }
        }

        public class SmsNotification : BaseNotification
        {
            public override void Send(string recipient, string message)
            {
                string cleanMsg = CleanMessage(message);
                string getTime = GetTime("sms");
                Console.WriteLine($"{getTime} | to {recipient} : {cleanMsg} ");
            }
        }
    }
}
