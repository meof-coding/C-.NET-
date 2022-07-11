using LAB_02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAB_02
{
    public partial class AddCar : Form
    {
        List<Car> Cars;
        public AddCar(List<Car> cars)
        {
            InitializeComponent();
            this.Cars = cars;
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
                MyStocksContext.Cars.Add(car);
                int count = MyStocksContext.SaveChanges();
                if (count > 0)
                {
                    MessageBox.Show("Insert success.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void AddCar_Load(object sender, EventArgs e)
        {
           cmbManufacturer.DataSource = Cars;
            cmbManufacturer.DisplayMember = "Manufacturer";
        }
    }
}
