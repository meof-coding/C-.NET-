using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManagement
{
    public partial class FrmManageCategory : Form
    {
        public FrmManageCategory()
        {
            InitializeComponent();
        }

       //Ktra tinh hop le cua du lieu dau vao
       bool Valid_Form()
        {
            Regex cat_Name = new Regex(@"^[a-zA-Z\s]+$");
            return cat_Name.IsMatch(txtCateName.Text.Trim());
        }

        CategoriesDAL catList = new CategoriesDAL();

        void LoadCategories()
        {
            List<Category> categories = catList.GetCategories();
            txtCateID.DataBindings.Clear();
            txtCateName.DataBindings.Clear();
            txtCateID.DataBindings.Add("Text",categories, "CategoryID");
            txtCateName.DataBindings.Add("Text",categories, "CategoryName");
            dgvCategories.DataSource = categories;
        }

        private void FrmManageCategory_Load(object sender, EventArgs e)
        {
            //xu ly loi trong truong hop bi loi
            try
            {
                LoadCategories();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Valid_Form())
            {
                try
                {
                    Category category = new Category()
                    {
                        CategoryName = txtCateName.Text.Trim()
                    };
                    if (catList.InsertCategory(category) > 0)
                    {
                        MessageBox.Show("Insert Successfuly!!");
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed!");
                    }

                    LoadCategories();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("CategoryName not: Empty or Number , special character");
                txtCateName.Focus();
            }
            
        }

        //Update Category_Name
      
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Category category = new Category()
                {
                    CategoryID = int.Parse(txtCateID.Text.Trim()),
                    CategoryName = txtCateName.Text.Trim()
                };
                if (catList.UpdateCategory(category) > 0)
                {
                    MessageBox.Show("Update Successfuly!!");
                }
                else
                {
                    MessageBox.Show("Update Failed!");
                }

                LoadCategories();
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
                Category category = new Category()
                {
                    CategoryID = int.Parse(txtCateID.Text.Trim()),
                    CategoryName = txtCateName.Text.Trim()
                };
                if (catList.DeleteCategory(category) > 0)
                {
                    MessageBox.Show("Delete Successfuly!!");
                }
                else
                {
                    MessageBox.Show("Delete Failed!");
                }

                LoadCategories();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

       
    }
}
//Yeu cau:
//Hoan thien not : Update,Delete
// Lam tuong tu voi Product
//Lam p1