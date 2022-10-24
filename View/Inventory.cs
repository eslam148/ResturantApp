using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        String RegPhone = @"(^(011||012||010||015)[0-9]{11})";
        public Inventory()
        {
            InitializeComponent();
            RefreshTab();
            Exist.Checked = true;
            KindOfBayComboBox.Items.Add("Cach");
            KindOfBayComboBox.Items.Add("Installement");
            KindOfBayComboBox.SelectedIndex = 0;
        }
        private void RefreshTab()
        {
            AddCatagoryInfoTab();
            AddSupplierInfoTab();
            BillCombo();
            AddItemInfoTap();
            ReturnedItemInfoTab();
           

        }
        private void AddItemInfoTap()
        {
            comboBoxAddItem.DataSource = null;
            comboBoxAddItem.DisplayMember = "Name";
            comboBoxAddItem.ValueMember = "ID";
            comboBoxAddItem.DataSource = ItemServices.GetAllItems();
            comboBoxItem.DataSource = null;
            comboBoxItem.DisplayMember = "Name";
            comboBoxItem.ValueMember = "ID";
            comboBoxItem.DataSource = ItemServices.GetAllItems();

        }
        public void BillCombo()
        {
            comboBoxCategory.DataSource = null;
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "ID";
            comboBoxCategory.DataSource = categoryServices.GetAllCategories();
            /////////////////////
            comboBoxCustomer.DataSource = null;
           comboBoxCustomer.DisplayMember = "Name";
            comboBoxCustomer.ValueMember = "ID";
            comboBoxCustomer.DataSource = customerService.GetCustomer();

            /////////////////////
            comboBoxSeller.DataSource = null;
            comboBoxSeller.DisplayMember = "Name";
            comboBoxSeller.ValueMember = "ID";
            comboBoxSeller.DataSource = sellerService.GetSeller();
        }

        private void AddCatagoryInfoTab()
        {
            comboCatagory.DataSource = null;
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
                bool flag = false;
                foreach (var item in itemView)
                {
                    if (ItemServices.AddItem(item.Name, item.BuyPrice, item.SellPrice, item.Quantity, item.SupplierID, item.CategoryId)>0)
                    {
                        flag = true;
                        dataGridViewItem.Rows.Clear();
                        comboBoxAddItem.Text = "";
                        numericUpDownBuy.Value = 1;
                        numericUpDownSell.Value = 1;
                    }
                    else
                    {
                        flag = false;

                    }
                }
                if (flag ==true)
                {
                    MessageBox.Show("Add Success");        
                }
                else
                {
                    MessageBox.Show("Add Fail");

                }
                RefreshTab();
            }
            else if (Exist.Checked == true)
            {


                int itemID = ItemServices.GetAllItems().Select(i => i.ID).ToArray()[comboBoxAddItem.SelectedIndex];
                int BuyPrice = (int)numericUpDownBuy.Value;
                int SellPrice = (int)numericUpDownSell.Value;
                int Quantity = int.Parse(QuntatyItem.Text);

                if (ItemServices.updateItems(itemID, Quantity, SellPrice, BuyPrice)>0)
                {
                    MessageBox.Show("Add Success");
                    comboBoxAddItem.Text = "";
                    numericUpDownBuy.Value = 1;
                    numericUpDownSell.Value = 1;

                }
                else
                {
                    MessageBox.Show("Add Fail");

                }

            }
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            if(New.Checked == true) {
                if (textBoxItem.Text != "")
                {
                    EmptyItem.Visible = false;

                    int catagoryid = categoryServices.GetAllCategories().Select(s => s.ID).ToArray()[comboCatagory.SelectedIndex];
                    int Supplierid = supplierServices.GetAllSuppliers().Select(s => s.ID).ToArray()[comboBoxSupplir.SelectedIndex];

                    itemView.Add(new ItemView
                    {
                        Name = textBoxItem.Text,
                        CategoryId = catagoryid,
                        SellPrice = (int)numericUpDownSell.Value,
                        BuyPrice = (int)numericUpDownBuy.Value,
                        Quantity = (int)QuntatyItem.Value,
                        SelledQuantity = 0,
                        SupplierID = Supplierid
                    });
                    dataGridViewItem.Rows.Add(textBoxItem.Text, numericUpDownSell.Value, numericUpDownBuy.Value, QuntatyItem.Value, comboCatagory.Text, comboBoxSupplir.Text);
                    RefreshTab();
                }
                else
                {
                    EmptyItem.Visible = true ;

                }
            }
        }

        private void AddCatagory_Click(object sender, EventArgs e)
        {
            if (CatagoryName.Text != "") {
                EmptyCategory.Visible = false;
            if (categoryServices.AddCategory(CatagoryName.Text)>0)
                {
                    MessageBox.Show("Add Success");
                    CatagoryName.Text = "";

                }
                else
                {
                    MessageBox.Show("Add Fail");

                }
                RefreshTab();
            }
            else
            {
                EmptyCategory.Visible = true;
            }
        }

      

        private void AddSeller_Click(object sender, EventArgs e)
        {

            String Name = SellerName.Text;
            String Phone = SellerPhone.Text;
            String Address = SellerAddress.Text;
            if (Name != ""&& Address != "" && Phone != "")
            {
                EmptySeller.Visible = false;
                Regex re = new Regex(RegPhone);
                if (re.IsMatch(Phone))
                {
                    if (sellerService.AddSeller(Name, Phone, Address)>0)
                    {
                        SellerPhoneError.Visible = false;
                        MessageBox.Show("Add Success");
                        SellerName.Text = "";
                        SellerPhone.Text = "";
                        SellerAddress.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Add Fail");

                    }
                    RefreshTab();
                }
                else
                {
                    SellerPhoneError.Visible = true;

                }
            }
            else
            {
                EmptySeller.Visible = true;
            }
        }

     

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            String Name = CustomerName.Text;
            String Phone = CustomerPhone.Text;
            String Address = CustomerAddress.Text;
            if(Name != ""&& Address != "" && Phone != "") {
                EmptyCustomer.Visible = false;
                Regex re = new Regex(RegPhone);
                if (re.IsMatch(Phone))
                {

                    if (customerService.AddCustomer(Name, Phone, Address)>0)
                    {
                        CustomerPhoneError.Visible = false;
                        MessageBox.Show("Add Success");
                        CustomerName.Text = "";
                        CustomerPhone.Text = "";
                        CustomerAddress.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Add Fail");

                    }
                    RefreshTab();
                }
                else
                {
                    CustomerPhoneError.Visible = true;
                }
            }
            else
            {
                EmptyCustomer.Visible = true;
            }
        }
        private void AddSupplier_Click(object sender, EventArgs e)
        {
            String Name = SupplierName.Text;
            String Phone = SupplierPhone.Text;
            String Address = SupplierAddress.Text;
            if (Name != ""&& Address != "" && Phone != "")
            {
                EmptySupplier.Visible = false;
                Regex re = new Regex(RegPhone);
                if (re.IsMatch(Phone))
                {
                    if (supplierServices.AddSupplier(Name, Phone, Address)>0)
                    {
                        SupplierPhoneError.Visible = false;
                        MessageBox.Show("Add Success");
                        SupplierName.Text = "";
                        SupplierPhone.Text = "";
                        SupplierAddress.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Add Fail");

                    }
                    RefreshTab();
                }
                else
                {
                    SupplierPhoneError.Visible = true;
                }
            }
            else
            {
                EmptySupplier.Visible = true;
            }
        }

        private void AddToBill_Click(object sender, EventArgs e)
        {
            var Catogary = categoryServices.GetAllCategories().Select(i => i.ID).ToArray()[CatagoryID];
            var Customer = customerService.GetCustomer().Select(i => i.ID).ToArray()[CustomerID];
            var item = ItemServices.GetAllItems().Select(i => i.ID).ToArray()[ItemID];
            var seller = sellerService.GetSeller().Select(i => i.ID).ToArray()[SellerID];
            int Quantaty = (int)QuantityBill.Value;
            bool typeOfPay = true;
            int DownPayment = 0;
            if (KindOfBayComboBox.SelectedIndex==0)
            {
                typeOfPay = false;
            }
            else
            {
                typeOfPay = true;
                DownPayment =(int)DownPaymentNumeric.Value;

            }

            var ExistItem = BillViews.FirstOrDefault(i => i.itemdId == item);
            int QuantatyDB = ItemServices.GetAllItems().ToArray()[ItemID].Quantity;

            if (ExistItem != null)
            {
                if (ExistItem.Quntaty < QuantatyDB)
                { 
                    ExistItem.Quntaty +=Quantaty;
                    foreach (DataGridViewRow r in dataGridViewBill.Rows)
                    {
                        if (int.Parse(r.Cells[0].Value.ToString())==item)
                        {
                            r.Cells[3].Value =  ExistItem.Quntaty;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("the Quantaty not Exist");
                }
            }
            else
            {
                if (Quantaty <= QuantatyDB) { 
                    BillViews.Add(new BillView
                    {
                        CustomerID=Customer,
                        itemdId=item,
                        Quntaty =  Quantaty,
                        sellerId = seller,
                        KindOfPay=typeOfPay
                    });
                    int price = ItemServices.GetAllItems().FirstOrDefault(i => i.ID == item).SellPrice;
                    dataGridViewBill.Rows.Add(item.ToString(), comboBoxCategory.Text, comboBoxItem.Text, Quantaty, price, price*Quantaty, comboBoxCustomer.Text);
                    QuantityBill.Value = 1;
                }
            }
            //RefreshTab();

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
                DownPayment = (int)DownPaymentNumeric.Value;


            }

            foreach (DataGridViewRow row in dataGridViewBill.Rows)
            {
                if (row.Cells[3].Value != null)
                    total += (int)row.Cells[4].Value;
            }

            billServices.AddBill(typeOfPay, seller, total, DownPayment);
            bool flag = false;
            foreach (var item in BillViews)
            {
                if (billServices.AddToBill(item.Quntaty, item.CustomerID, item.itemdId)>0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;

                }
            }
            if (flag== true)
            {
                MessageBox.Show("successful");
            }
            else
            {
                MessageBox.Show("successful");

            }
            dataGridViewBill.Rows.Clear();
            DownPaymentNumeric.Value=1;
            BillViews.Clear();
            RefreshTab();

        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatagoryID = comboBoxCategory.SelectedIndex;
            if (CatagoryID==-1)
            {
                CatagoryID=0;
                comboBoxCategory.SelectedIndex=0;
            }
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
            if (comboBoxItem.SelectedIndex==-1)
            {
                ItemID = 0;
            }
            int Quantaty = 0;
            var item = ItemServices.GetAllItems().Select(i => i.ID).ToArray()[ItemID];
            var BillValue =BillViews.FirstOrDefault(i => i.itemdId ==item);
           
            Quantaty= ItemServices.GetAllItems().ToArray()[ItemID].Quantity;
            //StayedQuantaty.Text = Quantaty.ToString();
            if (Quantaty==0) { 
                QuantityBill.Maximum = 1;
                QuantityBill.Minimum = 1;
            }
            else
            {
                QuantityBill.Maximum = Quantaty;
                QuantityBill.Minimum = 1;
            }
        }

        private void comboBoxSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            SellerID= comboBoxSeller.SelectedIndex;
        }

        private void CalcTotalPrice_Click(object sender, EventArgs e)
        {
            int valuetest = 0;

            foreach (DataGridViewRow row in dataGridViewBill.Rows)
            {
                if (row.Cells[4].Value != null)
                 valuetest += (int)row.Cells[4].Value;
            }
            totalPrice.Text =valuetest.ToString();
           
        }


        private void ShowAllItemsbutton_Click(object sender, EventArgs e)
        {
            List<ItemData> items = new List<ItemData>();
            items = ItemServices.GetAllItems();
            dataGridView1.DataSource=null;

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
                DownPaymentNumeric.Visible = true;
                PaymentLabl.Visible = true;
            }
            else
            {
                DownPaymentNumeric.Visible = false;
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
                if (comboCatagory.SelectedIndex!=-1) { 
                int CategoryId = categoryServices.GetAllCategories().Select(i => i.ID).ToArray()[comboCatagory.SelectedIndex];
                var Item = ItemServices.GetAllItems().Where(i => i.CategoryId ==CategoryId).Select(i => i.Name).ToList();
                comboBoxAddItem.DataSource = Item;
                }
            }
        }

        public void ReturnedItemInfoTab()
        {
            CustomercomboBox.DisplayMember = "Name";
            CustomercomboBox.ValueMember = "ID";
            CustomercomboBox.DataSource = customerService.GetCustomer();
           
        }

        private void CustomercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BillscomboBox.DataSource = null;
            int ID = customerService.GetCustomer().Select(c => c.ID).ToArray()[CustomercomboBox.SelectedIndex];
            var billID = billServices.GetBillOfCustomer(ID).Distinct().ToList();
            BillscomboBox.DataSource = billID;
        }

        private void BillscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            if ((int.Parse(BillscomboBox.SelectedItem.ToString()))!=null)
            {
                var BillItem = billServices.GetBillInfo(int.Parse(BillscomboBox.SelectedItem.ToString()));
                foreach (var item in BillItem)
                {
                    dataGridView2.Rows.Add(item.id, item.itemdata.ID, item.itemdata.Name, item.itemdata.Quantity);
                }
            }
        }


        private void Savebutton_Click(object sender, EventArgs e)
        {
            if (billServices.ReturnItem(int.Parse(BillscomboBox.Text), (int)numericUpDownItemID.Value, (int)numericUpDown1.Value) > 0)
            {
                BillscomboBox_SelectedIndexChanged(sender, e);
                MessageBox.Show("successful pay");
                numericUpDownItemID.Value = 1;
            }
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = e.RowIndex;
            DataGridViewRow selected = dataGridView2.Rows[selectedIndex];
            numericUpDownItemID.Value =int.Parse(selected.Cells[1].Value.ToString());
        }

        private void comboBoxAddItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Exist.Checked==true)
            {
                if (comboBoxAddItem.SelectedIndex!=-1)
                {
                    var item = ItemServices.GetAllItems().ToArray()[comboBoxAddItem.SelectedIndex];
                    numericUpDownBuy.Value = item.BuyPrice;
                    numericUpDownSell.Value = item.SellPrice;
                    QuntatyItem.Value = 1;
                }
            }
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            int billId = (int)(UpDownUpdateBilliD.Value);
            int money = (int)(UpDownBillMoney.Value);
            int res = billServices.UpdateBill(billId, money);
            if (res > 0)
            {
                MessageBox.Show("Your Bill Is Update");
                UpDownBillMoney.Value=1;

            }
            else
            {
                MessageBox.Show("Error Try Again");
            }
        }

        private void numericUpDownItemID_ValueChanged(object sender, EventArgs e)
        {
            int Itemid = (int)numericUpDownItemID.Value;
            int BillID = int.Parse(BillscomboBox.SelectedItem.ToString());
            var itemQumtaty = billServices.GetBillInfo(BillID).FirstOrDefault(i => i.itemdata.ID == Itemid);
            if (itemQumtaty !=null) { 
                numericUpDown1.Maximum = itemQumtaty.itemdata.Quantity;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            int index = dataGridViewBill.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridViewBill.Rows[index];
            int ID = int.Parse(row.Cells[0].Value.ToString());
            var delete = BillViews.FirstOrDefault(i => i.itemdId == ID);
            BillViews.Remove(delete);
            dataGridViewBill.Rows.RemoveAt(index);
        }
    }
}
