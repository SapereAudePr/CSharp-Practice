using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    public class Logger
    {
        ILogger _logger;

        public Logger(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string s)
        {
            _logger.Log(s);
        }
    }

    class LoggerService
    {
        List<ILogger> _logProvider = new();

        public void AddService(ILogger logger)
        {
            _logProvider.Add(logger);
        }

        public void LogAll(string message)
        {
            foreach (var provide in _logProvider)
            {
                provide.Log(message);
            }
        }
    }
}
