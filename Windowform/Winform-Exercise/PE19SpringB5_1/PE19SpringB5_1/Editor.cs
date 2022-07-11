using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PE19SpringB5_1
{
    public partial class Editor : Form
    {
        int mykey;
        public Editor(string name,string street,DateTime date,int key)
        {
            InitializeComponent();
            txtCo_Name.Text = name;
            txtStreet.Text = street;
            dateTimePicker1.Value = date;
            this.mykey = key;
    }

        private bool ValidForm()
        {
            bool flag = true;
            Regex checkName = new Regex(@"\D+");
            Regex checkStreet = new Regex(@"\w+");
            if (!checkName.IsMatch(txtCo_Name.Text.Trim()))
            {
                flag = false;
                MessageBox.Show("Name not: Empty or Number , special character");
            }
            if (!checkStreet.IsMatch(txtStreet.Text.Trim()))
            {
                flag = false;
                MessageBox.Show("Street not: Empty, special character");
            }
            return flag;
        }

        Cor_DAL corporate = new Cor_DAL();
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ValidForm())
            {
                try
                {
                    CorporationListForm corporation = new CorporationListForm();
                    string name = txtCo_Name.Text.Trim();
                    string street = txtStreet.Text.Trim();
                    string date = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                    if (corporate.UpdateInfoCor(name,street,date,mykey) > 0)
                    {
                        MessageBox.Show("Update Successfuly!!");
                        corporation.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed!");
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error");
                }
            }
             
        }

    }
}
