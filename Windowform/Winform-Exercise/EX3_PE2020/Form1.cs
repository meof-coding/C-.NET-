using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EX3_PE2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (this.lboxKhachhang.Items.Count > 0)
                this.lboxKhachhang.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAdress.Text.Equals("")){
                MessageBox.Show("Dia chi khong the de trong");
            }
        }
    }
}
