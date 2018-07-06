using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdiff
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    throw new Exception("You must supply two times.");
                }
                var time1 = GetTime(args[0]);
                var time2 = GetTime(args[1]);
                if (time2 < time1)
                {
                    throw new Exception("first time is after second time");
                }
                var hours = (time2 - time1) / 60;
                var mins = (time2 - time1) % 60;

                Console.WriteLine($"{hours}:{mins:D2}");
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }
        }

        private static int GetTime(string time)
        {
            if (time.Length != 5)
            {
                throw new Exception($"time format must be like 09:30 - you supplied {time}");
            }
            if (!(time.Substring(0, 2) + time.Substring(3, 2)).All(char.IsDigit))
            {
                throw new Exception($"time format must be like 09:30 - you supplied {time}");
            }
            if (time[2] != ':')
            {
                throw new Exception($"time format must be like 09:30 - you supplied {time}");
            }
            var minutes = 600 * (time[0] - '0') + 60 * (time[1] - '0') + 10 * (time[3] - '0') + (time[4] - '0');
            if (minutes > 1439)
            {
                throw new Exception($"time format must be like 09:30 - you supplied {time}");
            }
            return minutes;
        }
    }
}
