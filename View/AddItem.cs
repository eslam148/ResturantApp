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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace View
{
    public partial class AddItem : Form
    {
        ItemServices ItemServices = new ItemServices();

        public AddItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Name = textBox1.Text;
            int CategoryId = comboBox1.SelectedIndex;
            int BuyPrice = int.Parse(textBox2.Text);
            int SellPrice = int.Parse(textBox3.Text);
            int Quantity = int.Parse(textBox4.Text);
            int SupplierId = comboBox2.SelectedIndex;

            if (ItemServices.AddItem(Name, BuyPrice, SellPrice, Quantity, SupplierId, CategoryId)>0)
            {
                MessageBox.Show("Add Success");

            }
            else
            {
                MessageBox.Show("Add Fail");

            }
        }


    }
}
