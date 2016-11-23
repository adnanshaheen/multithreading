using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTime time = new MyTime();
            Thread t1 = new Thread(new ThreadStart(time.Inc));
            Thread t2 = new Thread(time.ReadTime);
            t1.Start();
            //Thread.Sleep(50);   // since we are not waiting the full time i.e. more than 100 ms. So we won't get updated result
            t2.Start();
        }
    }
}
