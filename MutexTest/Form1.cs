using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutexTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMutex_Click(object sender, EventArgs e)
        {
            bool reqCreation = true; // to request creation of a mutex
            bool alreadyExists; // if a mutex already exists
            //int thId = AppDomain.GetCurrentThreadId();        // This is obselete
            int thId = Thread.CurrentThread.ManagedThreadId;
            Mutex m1 = new Mutex(reqCreation, "MyMutex", out alreadyExists);
            // check to see if the mutex is owned by this thread
            if (!(reqCreation && alreadyExists))
            {
                lblStatus.Text = "Mutex already exists, waiting on its release..." + thId.ToString();
                m1.WaitOne(); // this thread wil block here
            }
            lblStatus.Text = "Starting to use the resource, .. mutex owner" + thId.ToString();
            // if this is the owner thread, you can use the shared resource
            Thread.Sleep(10000);
            // done using the resource
            lblStatus.Text = "Done using mutex, releasing resource ..." + thId.ToString();
            m1.ReleaseMutex();
        }
    }
}
