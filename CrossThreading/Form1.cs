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

namespace CrossThreading
{
    delegate void UpdateDel(string msg);
    public partial class Form1 : Form
    {
        Thread thClock = null;
        bool terminate = false;
        UpdateDel udel;

        public Form1()
        {
            InitializeComponent();
            udel = new UpdateDel(UpdateLabel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            thClock = new Thread(new ThreadStart(MyLock));
            thClock.Start();
        }

        void MyLock()
        {
            for (;;)
            {
                lblTime.Text = DateTime.Now.ToString();
                // we cannot update the label because
                // that will cause cross threading
                // error, use invoke on the UI element
                if (!terminate)
                    lblTime.Invoke(udel, new string[] { DateTime.Now.ToString() });
                else
                    break;
                Thread.Sleep(1000);
            }
        }

        void UpdateLabel(string msg)
        {
            lblTime.Text = msg;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            terminate = true;
            if (thClock != null)
            {
                if (thClock.IsAlive)
                    thClock.Join();
            }
        }
    }
}
