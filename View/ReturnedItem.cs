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
        public ReturnedItem()
        {
            InitializeComponent();
            foreach (var item in billServices.GetBillInfo(7))
            {
                dataGridView1.Rows.Add(item.id, item.itemdata.Name, item.itemdata.Quantity);
            }
        }
    }
}
