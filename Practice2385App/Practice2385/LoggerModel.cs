using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    class LoggerModel
    {
        public class LogConsole : BaseLogger
        {
            private readonly WriteFileUtility _writeFile = new();

            protected override string Prefix => "[ConsoleLOG]";

            public override void Log(string s)
            {
                string logLine = $"{GetFormattedTime} : {CleanMessage(s)}";

                Console.WriteLine(logLine);

                _writeFile.WriteFile(Prefix, logLine);
            }
        }
    }
}
