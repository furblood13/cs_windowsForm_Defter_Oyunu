using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22deftersonartikdefter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 gecis = new Form1();
            gecis.Show();
            this.Hide();
            
            const int Size = 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 gecis = new Form1();
            gecis.Show();
            this.Hide();
            const int Size = 5;
        }
    }
}
