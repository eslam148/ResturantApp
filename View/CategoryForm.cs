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
    public partial class CategoryForm : Form
    {
        CategoryServices categoryServices = new CategoryServices();
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }

        private void ADDbutton_Click(object sender, EventArgs e)
        {
            string name = NametextBox.Text;
            if (categoryServices.AddCategory(name) > 0)
            {
                MessageBox.Show("Succesfully added");
            }
            else
            {
                MessageBox.Show("Failed to add");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
