using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    class NotificationModel
    {
        public class EmailNotification : BaseNotification
        {
            private readonly WriteFileUtility _writeFile = new();

            protected override string Prefix => "[EMAIL]";

            public override void Send(string recipient, string msg)
            {
                string logLine = $"{GetFormattedTime} | to {recipient} : {CleanMessage(msg)}";

                Console.WriteLine(logLine);

                _writeFile.WriteFile(Prefix, logLine);
            }
        }

        public class SmsNotification : BaseNotification
        {
            private readonly WriteFileUtility _writeFile = new();
            protected override string Prefix => "[SMS]";

            public override void Send(string recipient, string msg)
            {
                string logLine = $"{GetFormattedTime} | to {recipient} : {CleanMessage(msg)}";

                Console.WriteLine(logLine);

                _writeFile.WriteFile(Prefix, logLine);
            }
        }
    }
}
