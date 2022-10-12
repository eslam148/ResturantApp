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
            //int ID = int.Parse(textBox1.Text);
            //String Name = textBox2.Text;
            //int CategoryId = int.Parse(textBox3.Text);
            //int BuyPrice = int.Parse(textBox4.Text);
            //int SellPrice = int.Parse(textBox5.Text);
            //int Quantity = int.Parse(textBox6.Text);
            //int SupplierId = int.Parse(textBox7.Text);

            if (ItemServices.AddItem(1,"eslam", 500, 550, 4, 1, 1)>0)
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
