using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string server = "127.0.0.1";
        int port = 1500;

        static TcpClient client = new TcpClient("127.0.0.1", 1500);
        static NetworkStream stream = client.GetStream();

        void Reload()
        {
            String result = ConnectServer(server, port, "getAllProduct", null);
            List<ProductDTO> productDTOs = JsonConvert.DeserializeObject<List<ProductDTO>>(result);

            lvProducts.ItemsSource = productDTOs;
        }

        private ProductDTO getProductObject()
        {
            ProductDTO productDTO = new ProductDTO();

            productDTO.ProductName = txtProductName.Text;
            productDTO.SupplierId = Int32.Parse(txtSupplierID.Text);
            productDTO.CategoryId = Int32.Parse(txtCategoryId.Text);
            productDTO.QuantityPerUnit = txtQuantityPerUnit.Text;
            productDTO.UnitPrice = Decimal.Parse(txtUnitPrice.Text);
            productDTO.UnitsInStock = Int16.Parse(txtUnitsInStock.Text);
            productDTO.UnitsOnOrder = Int16.Parse(txtUnitsOnOrder.Text);
            productDTO.ReorderLevel = Int16.Parse(txtReorderLevel.Text);
            productDTO.Discontinued = rbYes.IsChecked.Value ? true : false;

            return productDTO;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public static string ConnectServer(string server, int port, string action, string parameter)
        {
            string path;
            if (parameter == null)
            {
                path = action;
            }
            else
            {
                path = action + "/" + parameter;
            }
            string request, response;

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(path);
            stream.Write(data, 0, data.Length);
            Console.WriteLine($"Sent: {path}");

            data = new Byte[102400];
            int count = stream.Read(data, 0, data.Length);
            response = System.Text.Encoding.ASCII.GetString(data, 0, count);

            return response;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            client.Close();

            this.Close();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            ProductDTO productDTO = getProductObject();

            String jsonProduct = JsonConvert.SerializeObject(productDTO);

            String result = ConnectServer(server, port, "addProduct", jsonProduct);

            Reload();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ProductDTO productDTO = getProductObject();
            productDTO.ProductId = Int32.Parse(txtProductId.Text);

            String jsonProduct = JsonConvert.SerializeObject(productDTO);

            String result = ConnectServer(server, port, "updateProduct", jsonProduct);

            Reload();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            String result = ConnectServer(server, port, "deleteProduct", txtProductId.Text);

            Reload();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            //dlg.DefaultExt = ".png";
            //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                using (StreamReader r = new StreamReader(filename))
                {
                    string json = r.ReadToEnd();
                    List<ProductDTO> items = JsonConvert.DeserializeObject<List<ProductDTO>>(json);

                    String productJSON = JsonConvert.SerializeObject(items);

                    String output = ConnectServer(server, port, "importProduct", productJSON);
                }

                Reload();
            }
        }
    }
}
