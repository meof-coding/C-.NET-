using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyStoreManagement
{
    public partial class ProductManagement : Form
    {
        public ProductManagement()
        {
            InitializeComponent();
        }

        bool Valid_Form()
        {
            bool flag = true;
            string Err = "";
            Regex cat_Name = new Regex(@"^[a-zA-Z\s0-9]+$");
            if(!cat_Name.IsMatch(txtProName.Text.Trim()))
            {
                flag = false;
                Err += "ProductName not: empty or contain specials character\n";
                txtProName.Focus();
            }
            Regex Uprice = new Regex(@"^[0-9]+$");
            if (!Uprice.IsMatch(txtPrice.Text.Trim()))
            {
                flag = false;
                Err += "Price not: empty or contain word and specials character\n";
                txtPrice.Focus();
            }
            if (cmbCatName.SelectedIndex == -1)
            {
                flag = false;
                Err += "CategoryName should be selected\n";
                cmbCatName.Focus();
            }
           
            if (!flag)
            {
                MessageBox.Show(Err);
            }
            return flag;
        }

        ProductsDAL ProductList = new ProductsDAL();
        CategoriesDAL catList = new CategoriesDAL();
        void LoadProduct()
        {
            List<Products> products = ProductList.GetProducts();
            txtProID.DataBindings.Clear();
            txtProName.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            cmbCatName.SelectedIndex = -1;
            txtU_Stock.DataBindings.Clear();
            cmbCatName.DataSource = catList.GetCategories();
            cmbCatName.DisplayMember = "CategoryName";
            cmbCatName.ValueMember = "CategoryID";
            //cmbCatName.DataBindings.Add("Text", products, "CategoryID");
            txtProID.DataBindings.Add("Text", products, "ProductID");
            txtProName.DataBindings.Add("Text", products, "ProductName");
            cmbCatName.SelectedValue = GetCateID(int.Parse(txtProID.Text.Trim()));
            txtPrice.DataBindings.Add("Text", products, "UnitPrice");
            txtU_Stock.DataBindings.Add("Text", products, "UnitsInStock");
            dgvProducts.DataSource = products;
        }

        public int GetCateID(int pID)
        {
            int result = 0;
            foreach (var item in ProductList.GetProducts())
            {
                if (item.ProductID == pID)
                {
                    result = item.CategoryID;
                }
            }
            return result;
        }
        private void ProductManagement_Load(object sender, EventArgs e)
        {
                //xu ly loi trong truong hop bi loi
                try
                {
                    LoadProduct();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error");
                }
            }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (Valid_Form())
            {
                try
                {
                    Products products = new Products()
                    {
                        ProductName = txtProName.Text.Trim(),
                        UnitPrice = decimal.Parse(txtPrice.Text.Trim()),
                        CategoryID = int.Parse(cmbCatName.SelectedValue.ToString()),
                        UnitsInStock = int.Parse(txtU_Stock.Text.Trim())
                    };
                    if (ProductList.InsertProduct(products) > 0)
                    {
                        MessageBox.Show("Insert Successfuly!!");
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed!");
                    }

                    LoadProduct();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error");
                }
            }
            
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbCatName.SelectedValue = GetCateID(int.Parse(txtProID.Text.Trim()));
            if(e.RowIndex==-1 && e.ColumnIndex == -1)
            {
                List<Products> products2 = ProductList.SortProduct();
                cmbCatName.DataSource = catList.GetCategories();
                cmbCatName.DisplayMember = "CategoryName";
                cmbCatName.ValueMember = "CategoryID";
                dgvProducts.DataSource = products2;
               
            }
            txtProID.Text = dgvProducts.CurrentRow.Cells[0].Value.ToString();
            txtProName.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            txtU_Stock.Text = dgvProducts.CurrentRow.Cells[4].Value.ToString();
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Valid_Form())
            {
                try
                {
                    Products products = new Products()
                    {
                        ProductID = int.Parse(txtProID.Text.Trim()),
                        ProductName = txtProName.Text.Trim(),
                        UnitPrice = decimal.Parse(txtPrice.Text.Trim()),
                        CategoryID = int.Parse(cmbCatName.SelectedValue.ToString()),
                        UnitsInStock = int.Parse(txtU_Stock.Text.Trim())
                    };
                    if (ProductList.UpdateProduct(products) > 0)
                    {
                        MessageBox.Show("Update Successfuly!!");
                    }
                    else
                    {
                        MessageBox.Show("Update Failed!");
                    }

                    LoadProduct();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
              try
             {
                 string mulDel = "";
                 if (dgvProducts.SelectedRows.Count>0)
                 {
                     for (int i = 0; i < dgvProducts.SelectedRows.Count; i++)
                     {
                         if (i==dgvProducts.SelectedRows.Count-1)
                         {
                            mulDel += dgvProducts.SelectedRows[i].Cells[0].Value;
                         }
                         else
                         {
                             mulDel += $"{dgvProducts.SelectedRows[i].Cells[0].Value},";
                         }
                     }

                    DialogResult d = MessageBox.Show($"Are you sure you want to DELETE {dgvProducts.SelectedRows.Count} product", "Alert", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        if (ProductList.DeleteMultipleProduct(mulDel) > 0)
                        {
                            MessageBox.Show($"Delete ProductID {mulDel}  Successfuly!!");
                        }
                        else
                        {
                            MessageBox.Show("Delete Failed!");
                        }
                    }
                 
                }
                else
                {
                    Products products = new Products()
                    {
                        ProductID = int.Parse(txtProID.Text.Trim()),
                    };
                    if (ProductList.DeleteProduct(products) > 0)
                    {
                        MessageBox.Show("Delete Successfuly!!");
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed!");
                    }
                }
                 
                LoadProduct();
                txtProID.Clear();
                txtProName.Clear();
                txtPrice.Clear();
                cmbCatName.SelectedIndex = -1;
                txtU_Stock.Clear();
            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error");
             }
            
        }

        private void dgvProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string a = $"SELECT * FROM Products ORDER BY { dgvProducts.Columns[e.ColumnIndex].HeaderText.Trim()}";
            List<Products> sorted = ProductList.SortColumn(a);
            dgvProducts.DataSource = sorted;

        }
    }
}
