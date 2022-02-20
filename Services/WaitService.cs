using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AspireTest.Services
{
    public class WaitService
    {
        public static bool WaitFor(Func<bool> condition, int timeout = 10)
        {
            bool result = false;
            var watch = new Stopwatch();
            watch.Start();

            while (true)
            {
                try
                {
                    if (condition())
                    {
                        result = true;
                        break;
                    }
                }
                catch { }

                if (watch.Elapsed.TotalSeconds >= timeout)
                {
                    watch.Stop();
                    break;
                }
            }
            return result;
        }
    }
}
