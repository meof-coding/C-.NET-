using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FStored
{
    /// <summary>
    /// Interaction logic for ProductManagementPopup.xaml
    /// </summary>
    public partial class ProductManagementPopup : Window
    {
        private int _productId;
        private bool _isAddOrUpdate;
        ProductManagementWindow _productManagement;
        IProductRepository _productRepository = new ProductRepository();
        public ProductManagementPopup(ProductManagementWindow productManagement)
        {
            _isAddOrUpdate = true;
            _productManagement = productManagement;
            InitializeComponent();
            lbAdd_Update.Content = "Add";
            btnAdd_Update.Content = "Add";
        }

        public ProductManagementPopup(int productId, ProductManagementWindow productManagement)
        {
            _isAddOrUpdate = false;
            _productId = productId;
            _productManagement = productManagement;
            InitializeComponent();
            SetUpdateForm();
        }

        private void btnAdd_Update_Click(object sender, RoutedEventArgs e)
        {
            if (_isAddOrUpdate)
            {
                _productRepository.AddNew(GetFormInfo());
                _productManagement.LoadProductsList();
                MessageBox.Show("Success");
                this.Close();
            }
            else
            {
                _productRepository.Update(GetFormInfo());
                _productManagement.LoadProductsList();
                MessageBox.Show("Success");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetUpdateForm()
        {
            try
            {
                var product = _productRepository.GetProductById(_productId);
                txtProductId.Text = product.ProductId.ToString();
                txtCategoryId.Text = product.CategoryId.ToString();
                txtProductName.Text = product.ProductName;
                txtWeight.Text = product.Weight;
                txtUnitInStock.Text = product.UnitslnStock.ToString();
                txtUnitPrice.Text = product.UnitPrice.ToString();
                txtProductId.IsEnabled = false;
                lbAdd_Update.Content = "Update";
                btnAdd_Update.Content = "Update";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private Product GetFormInfo()
        {
            return new Product {
                CategoryId = int.Parse(txtCategoryId.Text),
                ProductId = int.Parse(txtProductId.Text),
                ProductName = txtProductName.Text,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                UnitslnStock = int.Parse(txtUnitInStock.Text),
                Weight = txtWeight.Text
            };
        }
    }
}
