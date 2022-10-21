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
    public partial class ReturnedItem : Form
    {
        BillServices billServices = new BillServices();
        CustomerService customerService = new CustomerService();
        public ReturnedItem()
        {
            InitializeComponent();
            comboBox1.DisplayMember = "Name";

            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = customerService.GetCustomer();
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = null;
            int ID = customerService.GetCustomer().Select(c => c.ID).ToArray()[comboBox1.SelectedIndex];
            var billID = billServices.GetBillOfCustomer(ID);
            comboBox2.DataSource = billID;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var BillItem = billServices.GetBillInfo(int.Parse(comboBox2.SelectedItem.ToString()));
            foreach (var item in BillItem)
            {
                dataGridView1.Rows.Add(item.id, item.itemdata.ID, item.itemdata.Name, item.itemdata.Quantity);
            }
        }
        int billID;
        private void button1_Click(object sender, EventArgs e)
        {

           if(billServices.ReturnItem(billID,int.Parse(textBoxItem.Text), (int)numericUpDown1.Value)>0)
            {
                comboBox2_SelectedIndexChanged(sender, e);
                MessageBox.Show("عمليه ناجحه");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = e.RowIndex;
            DataGridViewRow selected = dataGridView1.Rows[selectedIndex];
            textBoxItem.Text = selected.Cells[1].Value.ToString();
            billID = int.Parse(selected.Cells[0].Value.ToString());
        }
    }
}
