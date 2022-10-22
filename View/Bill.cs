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
    public partial class Bill : Form
    {
        BillServices billServices = new BillServices();
        CategoryServices categoryServices = new CategoryServices();
        CustomerService customerService = new CustomerService();
        ItemServices itemServices = new ItemServices();
        SellerService sellerService = new SellerService();
        int CatagoryID;
        int ItemID;
        int CustomerID;
        int SellerID;
        List<BillView> BillViews = new List<BillView>();
        public Bill()
        {
            InitializeComponent();
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "ID";
            comboBoxCategory.DataSource = categoryServices.GetAllCategories();
            /////////////////////
            comboBoxCustomer.DisplayMember = "Name";
            comboBoxCustomer.ValueMember = "ID";
            comboBoxCustomer.DataSource = customerService.GetCustomer();
            /////////////////////

            
            /////////////////////

            comboBoxSeller.DisplayMember = "Name";
            comboBoxSeller.ValueMember = "ID";
            comboBoxSeller.DataSource = sellerService.GetSeller();
            ///////////////////////////////////
            comboBox5.Items.Add("Cach");
            comboBox5.Items.Add("Installement");

        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            var Catogary = categoryServices.GetAllCategories().Select(i => i.ID).ToArray()[CatagoryID];
            var Customer = customerService.GetCustomer().Select(i => i.ID).ToArray()[CustomerID];
            var item = itemServices.GetAllItems().Select(i => i.ID).ToArray()[ItemID];
            var seller = sellerService.GetSeller().Select(i => i.ID).ToArray()[SellerID];
            int Quantaty = (int)numericUpDown1.Value;
            BillViews.Add(new BillView
            {
                CustomerID=Customer,
                itemdId=item,
                Quntaty =  Quantaty,
                sellerId = seller,
              
            });
            int price = itemServices.GetAllItems().FirstOrDefault(i => i.ID == item).BuyPrice;
            dataGridView1.Rows.Add(comboBoxCategory.Text, comboBoxItem.Text, Quantaty, price, price*Quantaty, comboBoxCustomer.Text, "ss", "ss");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var seller = sellerService.GetSeller().Select(i => i.ID).ToArray()[SellerID];
            int total = 0;
            bool typeOfPay = true;
            int DownPayment = 0;
            if (comboBox5.SelectedIndex==0)
            {
                typeOfPay = false;
            }
            else
            {
                typeOfPay = true;
                DownPayment = int.Parse(textBox1.Text) ;

            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[3].Value != null)
                    total += (int)row.Cells[4].Value;
            }

            billServices.AddBill(typeOfPay, seller, total, DownPayment);
     
            foreach (var item in BillViews)
            {
                if(billServices.AddToBill(item.Quntaty, item.CustomerID, item.itemdId)>0)
                {
                    MessageBox.Show("عمليه ناجحه");
                }
                else
                {
                    MessageBox.Show("عمليه فاشله");

                }
            }
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatagoryID = comboBoxCategory.SelectedIndex;
            var Catogary = categoryServices.GetAllCategories().Select(i => i.ID).ToArray()[CatagoryID];
            comboBoxItem.DataSource = null;
            comboBoxItem.DisplayMember = "Name";
            comboBoxItem.ValueMember = "ID";
            comboBoxItem.DataSource = itemServices.GetAllItems().Where(i=>i.CategoryId == Catogary).ToList();
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerID= comboBoxCustomer.SelectedIndex;

        }

        private void comboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemID= comboBoxItem.SelectedIndex;

        }

        private void comboBoxSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            SellerID= comboBoxSeller.SelectedIndex;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int valuetest = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Cells[3].Value != null)
                    valuetest += (int)row.Cells[4].Value;
            }
            totalPrice.Text =valuetest.ToString();
            var seller = sellerService.GetSeller().Select(i => i.ID).ToArray()[SellerID];
            textBox3.Text = seller.ToString();
            textBox2.Text = billServices.GetBillID().ToString();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox5.SelectedIndex == 1) {
                textBox1.Visible = true;
                label6.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                label6.Visible = false;

            }
        }
    }
}
