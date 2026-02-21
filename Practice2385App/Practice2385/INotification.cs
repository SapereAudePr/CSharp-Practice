using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    interface INotification
    {
        public void Send(string recipient, string message);
    }
}
