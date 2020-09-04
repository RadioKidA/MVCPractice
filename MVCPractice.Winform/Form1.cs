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

namespace MVCPractice.Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        delegate void WriteControl(string str);

        public void WriteLabel(string str)
        {
            Thread.Sleep(2000);
            label1.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Task.Run(() => { this.Invoke(new WriteControl(WriteLabel),new object[] {"new text" }); });

            Task.Run(() => { Thread.Sleep(2000); });

        }
    }
}
