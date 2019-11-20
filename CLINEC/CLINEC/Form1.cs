using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLINEC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            patients p = new patients();
            p.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doctors d = new Doctors();
            d.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Departments dep = new Departments();
            dep.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            page_of_detection page = new page_of_detection();
            page.ShowDialog();
        }
    }
}
