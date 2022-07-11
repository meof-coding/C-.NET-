using Q2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Q2
{
    public partial class frmEdit : Form
    {
        int ID;
        PRN292_19_SpringContext db = new PRN292_19_SpringContext();

        public frmEdit(int memberID)
        {
            InitializeComponent();
            ID = memberID;
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            var member = (from mem in db.Members
                          where mem.MemberNo == ID
                          select mem).First();
            textBox1.Text = member.Firstname;
            textBox2.Text = member.Lastname;
            dateTimePicker1.Value = member.IssueDt;
            dateTimePicker2.Value = member.ExprDt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag1 = textBox1.Text.Length > 0 && textBox2.Text.Length > 0;
            bool flag2 = dateTimePicker1.Value.AddDays(90) <= dateTimePicker2.Value;
            if (flag1 && flag2)
            {
                var member = (from mem in db.Members
                              where mem.MemberNo == ID
                              select mem).First();
                member.Firstname = textBox1.Text;
                member.Lastname = textBox2.Text;
                member.IssueDt = dateTimePicker1.Value;
                member.ExprDt = dateTimePicker2.Value;
                db.Members.Update(member);
                db.SaveChanges();
                this.Close();
            }
            else MessageBox.Show("Input Error");
        }
    }
}
