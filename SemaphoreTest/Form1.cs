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

namespace SemaphoreTest
{
    public partial class Form1 : Form
    {
        LimoCar limo = new LimoCar(1234, 5);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            Thread thLimo = new Thread(new ThreadStart(limo.UseLimo));
            thLimo.Start();
        }
    }
}
