using LAB_02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Khai bao 1 DB
        static MyStocksContext MyStocks = new MyStocksContext();

        public int SetCarID;
        public string SetCarName;
        public decimal SetPrice;
        public int SetYear;
        public string SetManu;
       
        private void LoadCategries()
        {
           
            var stocks = (from c in MyStocks.Cars
                              select new { c.CarId, c.CarName,c.Manufacturer,c.ReleasedYear,c.Price }).ToList();
            // Clear databinding trong cac control
            txtCarID.DataBindings.Clear();
            txtCarNAme.DataBindings.Clear();
            txtManu.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtYear.DataBindings.Clear();
            txtCarID.DataBindings.Add("Text", stocks, "CarID");
            txtCarNAme.DataBindings.Add("Text", stocks, "CarName");
            txtManu.DataBindings.Add("Text", stocks, "Manufacturer");
            txtPrice.DataBindings.Add("Text", stocks, "Price");
            txtYear.DataBindings.Add("Text", stocks, "ReleasedYear");
            dgvCar.DataSource = stocks;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                LoadCategries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            List<Car> car = (from c in MyStocks.Cars select c).ToList();
            AddCar addCar = new AddCar(car);
            addCar.Show();
            this.Hide();
            addCar.FormClosing += Frm_Closing;

        }

        private void Frm_Closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCategries();
        }

        private void dgvCar_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Car> car = (from c in MyStocks.Cars select c).ToList();
            SetCarID = int.Parse(txtCarID.Text.Trim());
            SetCarName = txtCarNAme.Text.Trim();
            SetManu = txtManu.Text.Trim();
            SetPrice = decimal.Parse(txtPrice.Text.Trim());
            SetYear = int.Parse(txtYear.Text.Trim());
            UpdateCar updateCar = new UpdateCar(SetCarID, SetCarName, SetManu, SetPrice, SetYear,car);
            updateCar.Show();
            this.Hide();
            updateCar.FormClosing += Frm_Closing; 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Car car = new Car {
                    CarId = int.Parse(txtCarID.Text),
                    CarName = txtCarNAme.Text,
                    Manufacturer = txtManu.Text.Trim(),
                    Price = decimal.Parse(txtPrice.Text.Trim()),
                    ReleasedYear = int.Parse(txtYear.Text.Trim()),
            };
                MyStocks.Cars.Remove(car);
                int count = MyStocks.SaveChanges();
                if (count > 0)
                {
                    MessageBox.Show("Delete success.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
