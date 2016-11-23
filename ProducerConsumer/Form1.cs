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

namespace ProducerConsumer
{
    delegate void DisplayDel(string msg);
    public partial class Form1 : Form
    {
        Thread thConsumer;
        Thread thProducer;
        Thread thConsumerMR;
        Thread thProducerMR;
        object olock = new object();
        bool dataReady = false;
        int data = 0;
        DisplayDel ddel = null;
        ManualResetEvent mr = new ManualResetEvent(false);

        public Form1()
        {
            InitializeComponent();
            ddel = new DisplayDel(DisplayStatus);
        }

        private void DisplayStatus(string msg)
        {
            lblStatus.Text = msg;
        }

        void Consumer()
        {
            for (int i = 0; i < 2; i++)
            {
                statusStrip1.Invoke(ddel, new string[]{
                    "Consumer thread started.."});
                if (dataReady == false)
                {
                    lock (olock)
                    {
                        Monitor.Wait(olock);
                    }
                    // Monitor.Wait and Monitor.Pulse
                    // are required to be inside the same
                    // lock they are testing
                }
                Thread.Sleep(1000);
                statusStrip1.Invoke(ddel, new string[]{
                    "starting to consume data.."});
                lock (olock)
                {
                    data = data - 2000;
                    dataReady = false;
                }
                Thread.Sleep(4000); // pretend it takes 4 secs to
                                    // consume data
                statusStrip1.Invoke(ddel, new string[]{
                    "Data consumed: data = " + data.ToString()});
            }
        }

        void Producer()
        {
            statusStrip1.Invoke(ddel, new string[]{
                "Producer started.."});
            Thread.Sleep(9000); // 9 secs to produce data
            lock (olock)
            {
                data = 2375;
                dataReady = true;
            }
            lock (olock)
            {
                Monitor.Pulse(olock); // signal the waiting thread
            }
        }

        void ConsumerMR() // uses ManualResetEvent for
        { // synchronization
            for (int i = 0; i < 2; i++)
            {
                statusStrip1.Invoke(ddel, new string[]{
                    "Consumer thread started.."});
                if (dataReady == false)
                {
                    mr.WaitOne(); // wait for producer
                    mr.Reset(); // close the gate
                }
                Thread.Sleep(1000);
                statusStrip1.Invoke(ddel, new string[]{
                    "starting to consume data.."});
                lock (olock)
                {
                    data = data - 2000;
                    dataReady = false;
                }
                Thread.Sleep(4000); // pretend it takes 4 secs to
                                    // consume data
                statusStrip1.Invoke(ddel, new string[] { "Data consumed: data = " + data.ToString() });
            }
        }
        void ProducerMR() // based on ManualResetEvent
        {
            statusStrip1.Invoke(ddel, new string[]{
                "Producer started.."});
            Thread.Sleep(9000); // 9 secs to produce data
            lock (olock)
            {
                data = 2375;
                dataReady = true;
            }
            mr.Set(); // send signal to waiting thread
        }

        private void btnConsumer_Click(object sender, EventArgs e)
        {
            thConsumer = new Thread(new ThreadStart(Consumer));
            thConsumer.Start();
        }

        private void btnProducer_Click(object sender, EventArgs e)
        {
            thProducer = new Thread(new ThreadStart(Producer));
            thProducer.Start();
        }

        private void btnConsumerMR_Click(object sender, EventArgs e)
        {
            thConsumerMR = new Thread(new ThreadStart(ConsumerMR));
            thConsumerMR.Start();
        }

        private void btnProducerMR_Click(object sender, EventArgs e)
        {
            thProducerMR = new Thread(new ThreadStart(ProducerMR));
            thProducerMR.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // thread.join will not work if the consumer is waiting
            // or the consumerMR is waiting
            //if (thConsumer != null && thConsumer.IsAlive)
            //    thConsumer.Join();
            //if (thProducer != null && thProducer.IsAlive)
            //    thProducer.Join();
        }
    }
}
