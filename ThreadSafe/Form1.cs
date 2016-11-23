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

namespace ThreadSafe
{
    public partial class Form1 : Form
    {
        Thread thCompute = null;
        Thread thWeather = null;
        Thread thStock = null;
        LongOperation lop = new LongOperation();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            lop.Data = 25;
            thCompute = new Thread(lop.Compute);
            thCompute.Start();
            thCompute.Join();
            double res = lop.Result;
            MessageBox.Show(res.ToString());
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lop.Temperature.ToString());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lop.StockPrice.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lop = new LongOperation();
            thWeather = new Thread(lop.GetWeather);
            thWeather.IsBackground = true;
            thWeather.Start();
            thStock = new Thread(lop.GetStockPrice);
            thStock.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            lop.Terminate = true;
            if (thStock != null)
            {
                if (thStock.IsAlive)
                    thStock.Join();
            }

            // NOTE: If you put the thread as IsBackground
            // You don't need this, it will close itself once
            // other threads finishes
            //if (thWeather != null)
            //{
            //    if (thWeather.IsAlive)
            //        thWeather.Join();
            //}
        }
    }
}
