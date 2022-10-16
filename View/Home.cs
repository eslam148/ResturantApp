using DataBase;
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
    public partial class Home : Form
    {
        ItemServices itemServices;
        public Home()
        {
            InitializeComponent();
            itemServices = new ItemServices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            List<Item> items = new List<Item>();
            items = itemServices.GetAllItems();
            dataGridView1.DataSource = items;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            List<Item> items = new List<Item>();
            items = itemServices.GetAllSealedItem();
            dataGridView1.DataSource = items;
        }
    }
}
