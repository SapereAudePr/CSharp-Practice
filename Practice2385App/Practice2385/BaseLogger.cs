using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    abstract class BaseLogger: ILogger
    {
        protected string GetTime(string? identifier)
        {
            var prefix = identifier switch
            {
                "console" => "[ConsoleLOG]",
                "file" => "[FileLOG]",
                _ => null
            };

            DateTime now = DateTime.Now;
            return $"" +
                $"{prefix} | " +
                $"{now.Year}:" +
                $"{now.Month}:" +
                $"{now.Day} - " +
                $"{now.Hour}:" +
                $"{now.Minute}:" +
                $"{now.Second}";
        }

        public abstract void Log(string s);
    }
}
