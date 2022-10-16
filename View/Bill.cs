using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Catagory = comboBox1.SelectedIndex;
            int item = comboBox2.SelectedIndex;
            int Quantaty = int.Parse(textBox1.Text);
            int price = int.Parse(textBox2.Text);////////////
            int customer = comboBox3.SelectedIndex;
        }
    }
}
