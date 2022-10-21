using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace View
{
    public partial class spplier : Form
    {
        supplierServices services;
        public spplier()
        {
            InitializeComponent();
            services = new supplierServices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string address = textBox3.Text;
            String phone = textBox2.Text;
            int res = services.AddSupplier(name, phone, address);
            if (res > 0)
            {
                MessageBox.Show(name + " " + address + "" + phone);
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
