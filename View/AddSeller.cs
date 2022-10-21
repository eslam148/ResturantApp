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
    public partial class AddSeller : Form
    {
        SellerService sl = new SellerService();
        public AddSeller()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string name = textBox2.Text;
            String ph = textBox3.Text;
            string add = textBox4.Text;
            sl.AddSeller( name, ph, add);
            MessageBox.Show("sucssess", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }
    }
}
