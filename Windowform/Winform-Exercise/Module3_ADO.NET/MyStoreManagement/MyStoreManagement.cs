using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyStoreManagement
{
    public partial class MyStoreManagement : Form
    {
        public MyStoreManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmManageCategory mCate = new FrmManageCategory();
            mCate.Show();
            this.Hide();
            mCate.FormClosing += Frm_CLosing;
        }

        private void Frm_CLosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductManagement productManagement = new ProductManagement();
            productManagement.Show();
            this.Hide();
            productManagement.FormClosing += Frm_CLosing;
        }
    }
}
