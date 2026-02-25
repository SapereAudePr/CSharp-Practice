using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndDelegates
{
    public delegate void LogHandler(string s);

    class MulticastDelegate
    {
        class Logger
        {
            public void ConsoleLogger(string s)
            {
                Console.WriteLine("[Console] " + s);
            }

            public void FileLogger(string s)
            {
                Console.WriteLine("[File] " + s);
            }

            public void DiscordLog(string s)
            {
                Console.WriteLine("[Discord] " + s);
            }
        }

        class Service
        {
            LogHandler? _logHandler;

            public void AddService(LogHandler logHandler)
            {
                _logHandler += logHandler ??
                    throw new ArgumentNullException(nameof(logHandler));
            }

            public void LogAll(string s)
            {
                _logHandler?.Invoke(s);
            }
        }

        public void Run()
        {
            //Logger logger = new();
            //LogHandler? logHandler = null;
            //logHandler += logger.FileLogger;
            //logHandler += logger.ConsoleLogger;
            //logHandler += logger.DiscordLog;
            //logHandler("Testing");


            Logger logger = new();
            Service service = new();
            service.AddService(logger.ConsoleLogger);
            service.AddService(null);
            service.AddService(logger.FileLogger);
            service.AddService(logger.DiscordLog);

            service.LogAll("Testing");
        }
    }
}
