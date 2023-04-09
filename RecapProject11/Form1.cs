using RecapProject11.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapProject11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListProducts();
            ListCategories();

        }

        private void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource = context.Products.ToList();


            }
        }
        private void ListCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                cbxCategory.DataSource = context.Categories.ToList();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryId";


            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch { }
            
        }
        private void ListProductsByCategory(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource = context.Products.Where(p=>p.CategoryId==categoryId).ToList();


            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if(tbxSearch.Text.Length>0) {
                ListProductsByProductName();
            }
            

        }
        private void ListProductsByProductName( )
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource = context.Products.Where(p => p.ProductName.Contains(tbxSearch.Text)).ToList();


            }
        }
    }
}
