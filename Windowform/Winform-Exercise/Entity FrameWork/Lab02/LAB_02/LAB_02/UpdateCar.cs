using LAB_02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LAB_02
{
    public partial class UpdateCar : Form
    {
        List<Car> cars;
        public UpdateCar(int CarID, string CarName, string Manufacturer, decimal Price, int ReleasedYear,List<Car> cars)
        {
            InitializeComponent();
            txtCarID.Text = CarID.ToString();
            txtCarName.Text = CarName;
            cmbManufacturer.Text = Manufacturer;
            txtPrice.Text = Price.ToString();
            txtReleasedYear.Text = ReleasedYear.ToString();
            this.cars = cars;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        MyStocksContext MyStocksContext = new MyStocksContext();
        private void btnSave_Click(object sender, EventArgs e)
        {

            Car car = new Car
            {
                CarId = int.Parse(txtCarID.Text),
                CarName = txtCarName.Text,
                Manufacturer = cmbManufacturer.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text.Trim()),
                ReleasedYear = int.Parse(txtReleasedYear.Text.Trim()),
            };
            try
            {
                var result = MyStocksContext.Cars.SingleOrDefault(c => c.CarId == int.Parse(txtCarID.Text));
                if (result != null)
                {
                    result.CarName = txtCarName.Text;
                    result.Manufacturer = cmbManufacturer.SelectedItem.ToString();
                    result.Price = decimal.Parse(txtPrice.Text);
                    result.ReleasedYear = int.Parse(txtReleasedYear.Text);
                    int count = MyStocksContext.SaveChanges();
                    if (count > 0)
                        MessageBox.Show("Update success.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void UpdateCar_Load(object sender, EventArgs e)
        {
            cmbManufacturer.DataSource = cars;
            cmbManufacturer.DisplayMember = "Manufacturer";
        }
    }
}
