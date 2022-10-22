using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace View
{
    public partial class Inventory : Form
    {
        ItemServices ItemServices = new ItemServices();
        CategoryServices categoryServices = new CategoryServices();
        supplierServices supplierServices = new supplierServices();
        List<ItemView> itemView = new List<ItemView>();
        SellerService sellerService = new SellerService();
        CustomerService customerService = new CustomerService();

        /// <summary>
        /// //////////
        /// </summary>
        BillServices billServices = new BillServices();
        int CatagoryID;
        int ItemID;
        int CustomerID;
        int SellerID;
        List<BillView> BillViews = new List<BillView>();
        public Inventory()
        {
            InitializeComponent();
            AddCatagoryInfoTab();
            AddSupplierInfoTab();
            BillCombo();
            AddItemInfoTap();
            KindOfBayComboBox.Items.Add("Cach");
            KindOfBayComboBox.Items.Add("Installement");
            KindOfBayComboBox.SelectedIndex = 0;
        }
        public void BillCombo()
        {
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "ID";
            comboBoxCategory.DataSource = categoryServices.GetAllCategories();
            /////////////////////
            comboBoxCustomer.DisplayMember = "Name";
            comboBoxCustomer.ValueMember = "ID";
            comboBoxCustomer.DataSource = customerService.GetCustomer();

            /////////////////////

            comboBoxSeller.DisplayMember = "Name";
            comboBoxSeller.ValueMember = "ID";
            comboBoxSeller.DataSource = sellerService.GetSeller();
        }
        private void AddItemInfoTap()
        {
            comboBoxAddItem.DisplayMember = "Name";
            comboBoxAddItem.ValueMember = "ID";
            comboBoxAddItem.DataSource = ItemServices.GetAllItems();
            comboBoxItem.DisplayMember = "Name";
            comboBoxItem.ValueMember = "ID";
            comboBoxItem.DataSource = ItemServices.GetAllItems();
            
        }
        private void AddCatagoryInfoTab()
        {
            comboCatagory.DisplayMember = "Name";
            comboCatagory.ValueMember = "ID";
            comboCatagory.DataSource = categoryServices.GetAllCategories();
        }
        private void AddSupplierInfoTab()
        {
            comboBoxSupplir.DisplayMember = "Name";
            comboBoxSupplir.ValueMember = "ID";
            comboBoxSupplir.DataSource = supplierServices.GetAllSuppliers();
        }


        private void SaveItems_Click(object sender, EventArgs e)
        {
            if(New.Checked == true) { 
                foreach (var item in itemView)
                {
                    if (ItemServices.AddItem(item.Name, item.BuyPrice, item.SellPrice, item.Quantity, item.SupplierID, item.CategoryId)>0)
                    {
                        MessageBox.Show("Add Success");
                        dataGridViewItem.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Add Fail");

                    }
                }
             
            }
            else if (Exist.Checked == true)
            {


                int itemID = ItemServices.GetAllItems().Select(i => i.ID).ToArray()[comboBoxAddItem.SelectedIndex];
                int BuyPrice = int.Parse(textBoxBuy.Text);
                int SellPrice = int.Parse(textBoxSell.Text);
                int Quantity = int.Parse(QuntatyItem.Text);

                if (ItemServices.updateItems(itemID, Quantity, SellPrice, BuyPrice)>0)
                {
                    MessageBox.Show("Add Success");

                }
                else
                {
                    MessageBox.Show("Add Fail");

                }

            }
            AddCatagoryInfoTab();
            AddItemInfoTap();
            AddSupplierInfoTab();
            BillCombo();
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            if(New.Checked == true) { 
                int catagoryid = categoryServices.GetAllCategories().Select(s => s.ID).ToArray()[comboCatagory.SelectedIndex];
                int Supplierid = supplierServices.GetAllSuppliers().Select(s => s.ID).ToArray()[comboBoxSupplir.SelectedIndex];

                itemView.Add(new ItemView
                {
                    Name = textBoxItem.Text,
                    CategoryId = catagoryid,
                    SellPrice = int.Parse(textBoxSell.Text),
                    BuyPrice = int.Parse(textBoxBuy.Text),
                    Quantity= (int)QuntatyItem.Value,
                    SelledQuantity = 0,
                    SupplierID = Supplierid
                }) ;
                dataGridViewItem.Rows.Add(textBoxItem.Text,int.Parse(textBoxSell.Text),int.Parse(textBoxBuy.Text), QuntatyItem.Value, comboCatagory.Text, comboBoxSupplir.Text);
                AddCatagoryInfoTab();
                AddItemInfoTap();
                AddSupplierInfoTab();
                BillCombo();
            }
        }

        private void AddCatagory_Click(object sender, EventArgs e)
        {
            if (categoryServices.AddCategory(CatagoryName.Text)>0)
            {
                MessageBox.Show("Add Success");

            }
            else
            {
                MessageBox.Show("Add Fail");

            }
            AddCatagoryInfoTab();
            AddItemInfoTap();
            AddSupplierInfoTab();
            BillCombo();
        }

      

        private void AddSeller_Click(object sender, EventArgs e)
        {
            String Name = SellerName.Text;
            String Phone = SellerPhone.Text;
            String Address = SellerAddress.Text;

            if (sellerService.AddSeller(Name, Phone, Address)>0)
            {
                MessageBox.Show("Add Success");

            }
            else
            {
                MessageBox.Show("Add Fail");

            }
            AddCatagoryInfoTab();
            AddItemInfoTap();
            AddSupplierInfoTab();
            BillCombo();
        }

     

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            String Name = CustomerName.Text;
            String Phone = CustomerPhone.Text;
            String Address = CustomerAddress.Text;

            if (customerService.AddCustomer(Name, Phone, Address)>0)
            {
                MessageBox.Show("Add Success");

            }
            else
            {
                MessageBox.Show("Add Fail");

            }
            AddCatagoryInfoTab();
            AddItemInfoTap();
            AddSupplierInfoTab();
            BillCombo();
        }
        private void AddSupplier_Click(object sender, EventArgs e)
        {
            String Name = SupplierName.Text;
            String Phone = SupplierPhone.Text;
            String Address = SupplierAddress.Text;

            if (supplierServices.AddSupplier(Name, Phone, Address)>0)
            {
                MessageBox.Show("Add Success");

            }
            else
            {
                MessageBox.Show("Add Fail");

            }
            AddCatagoryInfoTab();
            AddItemInfoTap();

            AddSupplierInfoTab();
            BillCombo();
        }

        private void AddToBill_Click(object sender, EventArgs e)
        {
            var Catogary = categoryServices.GetAllCategories().Select(i => i.ID).ToArray()[CatagoryID];
            var Customer = customerService.GetCustomer().Select(i => i.ID).ToArray()[CustomerID];
            var item = ItemServices.GetAllItems().Select(i => i.ID).ToArray()[ItemID];
            var seller = sellerService.GetSeller().Select(i => i.ID).ToArray()[SellerID];
            int Quantaty = (int)QuantityBill.Value;
            BillViews.Add(new BillView
            {
                CustomerID=Customer,
                itemdId=item,
                Quntaty =  Quantaty,
                sellerId = seller,
                KindOfInvoice = "ss",
                KindOfPay = "ss"
            });
            int price = ItemServices.GetAllItems().FirstOrDefault(i => i.ID == item).SellPrice;
            dataGridViewBill.Rows.Add(comboBoxCategory.Text, comboBoxItem.Text, Quantaty, price, price*Quantaty, comboBoxCustomer.Text, "ss", "ss");
            AddCatagoryInfoTab();
            AddItemInfoTap();

            AddSupplierInfoTab();
            BillCombo();
        }

        private void SaveBill_Click(object sender, EventArgs e)
        {
            var seller = sellerService.GetSeller().Select(i => i.ID).ToArray()[SellerID];
            int total = 0;
            bool typeOfPay = true;
            int DownPayment = 0;
            if (KindOfBayComboBox.SelectedIndex==0)
            {
                typeOfPay = true;
            }
            else
            {
                typeOfPay = false;
                DownPayment = int.Parse(DownPaymentText.Text);

            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[3].Value != null)
                    total += (int)row.Cells[4].Value;
            }

            billServices.AddBill(typeOfPay, seller, total, DownPayment);

            foreach (var item in BillViews)
            {
                if (billServices.AddToBill(item.Quntaty, item.CustomerID, item.itemdId)>0)
                {
                    MessageBox.Show("عمليه ناجحه");
                }
                else
                {
                    MessageBox.Show("عمليه فاشله");

                }
            }
            AddCatagoryInfoTab();
                        AddItemInfoTap();

            AddSupplierInfoTab();
            BillCombo();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatagoryID = comboBoxCategory.SelectedIndex;
            var Catogary = categoryServices.GetAllCategories().Select(i => i.ID).ToArray()[CatagoryID];
            comboBoxItem.DataSource = null;
            comboBoxItem.DisplayMember = "Name";
            comboBoxItem.ValueMember = "ID";
            comboBoxItem.DataSource = ItemServices.GetAllItems().Where(i => i.CategoryId == Catogary).ToList();
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

        private void CalcTotalPrice_Click(object sender, EventArgs e)
        {
            int valuetest = 0;

            foreach (DataGridViewRow row in dataGridViewItem.Rows)
            {
                if (row.Cells[3].Value != null)
                    valuetest += (int)row.Cells[4].Value;
            }
            totalPrice.Text =valuetest.ToString();
            var seller = sellerService.GetSeller().Select(i => i.ID).ToArray()[SellerID];
            SellerIdText.Text = seller.ToString();
            IDBillText.Text = billServices.GetBillID().ToString();
        }


        private void ShowAllItemsbutton_Click(object sender, EventArgs e)
        {

            List<ItemData> items = new List<ItemData>();
            items = ItemServices.GetAllItems();
            dataGridView1.DataSource = items;
            dataGridView1.Visible = true;
        }

        private void ShowSelledItemsbutton_Click(object sender, EventArgs e)
        {
            List<ItemData> items = new List<ItemData>();
            items = ItemServices.GetSelledItems();
            dataGridView1.DataSource = items;
            dataGridView1.Visible = true;
        }

        private void ShowStayedItemsbutton_Click(object sender, EventArgs e)
        {
            List<ItemData> items = new List<ItemData>();
            items = ItemServices.GetStayedItems();
            dataGridView1.DataSource = items;
            dataGridView1.Visible = true;
        }

        private void ShowItemsLessThan10button_Click(object sender, EventArgs e)
        {

            List<ItemData> items = new List<ItemData>();
            items = ItemServices.GetItemsLessThanTen();
            dataGridView1.DataSource = items;
            dataGridView1.Visible = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KindOfBayComboBox.SelectedIndex == 1)
            {
                DownPaymentText.Visible = true;
                PaymentLabl.Visible = true;
            }
            else
            {
                DownPaymentText.Visible = false;
                PaymentLabl.Visible = false;

            }
        }

        private void New_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxAddItem.Visible = false;
        }

        private void Exist_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxAddItem.Visible = true;
        

        }

        private void comboCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Exist.Checked == true)
            {
                int CategoryId = categoryServices.GetAllCategories().Select(i => i.ID).ToArray()[comboCatagory.SelectedIndex];
                var Item = ItemServices.GetAllItems().Where(i => i.CategoryId ==CategoryId).Select(i => i.Name).ToList();
                comboBoxAddItem.DataSource = Item;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int billId = (int)(UpDownUpdateBilliD.Value);
            int money = (int)(UpDownBillMoney.Value);
           int res= billServices.UpdateBill(billId, money);
            if (res > 0)
            {
                MessageBox.Show("Your Bill Is Update");

            }
            else 
            {
                MessageBox.Show("Error Try Again");
            }

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }
    }
}
