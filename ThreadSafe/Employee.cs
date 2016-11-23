using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafe
{
    class Employee
    {
        object lock1 = new object();
        object lock2 = new object();

        public int HoursWorked
        {
            get
            {
                lock (lock1)
                {
                    return HoursWorked;
                }
            }
            set
            {
                lock (lock1)
                {
                    HoursWorked = value;
                }
            }
        }

        public double PayRate
        {
            get
            {
                lock (lock2)
                {
                    return PayRate;
                }
            }
            set
            {
                lock (lock2)
                {
                    PayRate = value;
                }
            }
        }

        public double ComputePay()
        {
            double Hours = 0;
            Hours = HoursWorked;

            double Rate = 0;
            Rate = PayRate;

            return Hours * Rate;
        }
    }
}
