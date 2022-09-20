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

namespace AllControls
{
    /// <summary>
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class DataGrid : Window
    {
        public DataGrid()
        {
            InitializeComponent();
        }

        private void LoadAllCars()
        {
            // Tạo 1 danh sách Cars
            List<dynamic> carList = new List<dynamic>()
            {
                new {CarName="A6", Color="White", Brand="Audi"},
                new {CarName="Lexus 570", Color="Black", Brand="Toyota"},
                new {CarName="Ford Ranger", Color="White", Brand="Ford"}
            };
            // Binding dữ liệu cho dgCars
            dgCars.ItemsSource = carList;
        }


        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            LoadAllCars();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllCars();
        }
    }
}
