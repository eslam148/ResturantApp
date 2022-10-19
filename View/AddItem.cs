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
        CategoryServices categoryServices = new CategoryServices();

        public AddItem()
        {
            InitializeComponent();
            AddItemInfoTab();
        }
        private void AddItemInfoTab()
        {
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = categoryServices.GetAllCategories();
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

        private void Exist_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxItem.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Exist.Checked == true)
            {
                comboBoxItem.ValueMember = "Name";
                comboBoxItem.DataSource = ItemServices.GetAllItems().Where(i => i.CategoryId == comboBox1.SelectedIndex).ToList();
            }
        }

        private void New_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxItem.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (New.Checked == true) { 
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
            else if(Exist.Checked == true)
            {


                    int itemID = ItemServices.GetAllItems().Select(i=>i.ID).ToArray()[comboBoxItem.SelectedIndex];
                    int CategoryId = comboBox1.SelectedIndex;
                    int BuyPrice = int.Parse(textBox2.Text);
                    int SellPrice = int.Parse(textBox3.Text);
                    int Quantity = int.Parse(textBox4.Text);
                    int SupplierId = comboBox2.SelectedIndex;

                    if (ItemServices.updateItems(itemID, Quantity, SellPrice, BuyPrice)>0)
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
}
