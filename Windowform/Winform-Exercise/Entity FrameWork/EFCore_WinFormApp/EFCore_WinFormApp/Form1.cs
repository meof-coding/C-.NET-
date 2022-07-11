using EFCore_WinFormApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCore_WinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Khai bao 1 DB
        MyStoreContext MyStore = new MyStoreContext();

        private void LoadCategries()
        {
            var categories = (from c in MyStore.Categories
                             select new { c.CategoryId, c.CategoryName }).ToList();
            // Clear databinding trong cac control
            txtCatID.DataBindings.Clear();
            txtCatName.DataBindings.Clear();
            txtCatID.DataBindings.Add("Text", categories, "CategoryID");
            txtCatName.DataBindings.Add("Text", categories, "CategoryName");
            dgvCategories.DataSource = categories;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCategries();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Category category = new Category { CategoryName = txtCatName.Text };
            try
            {
                MyStore.Categories.Add(category);
                int count = MyStore.SaveChanges();
                if (count > 0)
                {
                    MessageBox.Show("Insert success.");
                    LoadCategries();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Category category = new Category { CategoryName = txtCatName.Text };
            try
            {
                var result = MyStore.Categories.SingleOrDefault(c => c.CategoryId == int.Parse(txtCatID.Text));
                if (result != null)
                {
                    result.CategoryName = txtCatName.Text;
                    int count = MyStore.SaveChanges();
                    if(count>0)
                        MessageBox.Show("Update success.");
                    LoadCategries();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Category category = new Category { CategoryId = int.Parse(txtCatID.Text), CategoryName = txtCatName.Text };
                MyStore.Categories.Remove(category);
                int count = MyStore.SaveChanges();
                if (count > 0)
                {
                    MessageBox.Show("Delete success.");
                    LoadCategries();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
