using BLL;
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
    public partial class AddCustomer : Form
    {
        CustomerService cs = new CustomerService();
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string name = textBox2.Text;
            String ph = textBox3.Text;
            string add = textBox4.Text;
            cs.AddCustomer( name, ph, add);
            MessageBox.Show("sucssess", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
