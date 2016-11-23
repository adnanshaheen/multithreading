using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    class MyTime
    {
        int Hours = 3;
        int Minutes = 59;
        int Seconds = 59;
        object olock = new object();

        public void Inc()
        {
            lock (olock)
            {
                Seconds = Seconds + 1;
                if (Seconds == 60)
                {
                    Seconds = 0;
                    Minutes = Minutes + 1;
                    if (Minutes == 60)
                    {
                        Minutes = 0;
                        Thread.Sleep(100);  // 100 ms
                        Hours = Hours + 1;
                    }
                }
            }
        }

        public void ReadTime()
        {
            lock (olock)
            {
                Console.WriteLine(Hours.ToString() + ":" + Minutes.ToString() + ":" + Seconds.ToString());
            }
        }
    }
}
