using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    abstract class BaseLogger : ILogger
    {
        protected abstract string Prefix { get; }

        protected string GetFormattedTime => $"{Prefix} {DateTime.Now:yyyy:MM:dd - HH:mm:ss}";

        public abstract void Log(string s);
    }
}
