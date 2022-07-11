using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q2.Models;

namespace Q2
{
    public partial class Form1 : Form
    {
        PRN292_19_SpringContext db = new PRN292_19_SpringContext();

        public Form1()
        {
            InitializeComponent();
        }

        void reload()
        {
            var members = (from member in db.Members
                           join r in db.Regions on member.RegionNo equals r.RegionNo
                           select new
                           {
                               memberID = member.MemberNo,
                               fullname = member.Firstname + " " + member.Lastname,
                               regionName = r.RegionName
                           }).ToList();
            dataGridView1.DataSource = members;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int id = Int32.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                frmEdit fEdit = new frmEdit(id);
                fEdit.ShowDialog();
                reload();
            }
        }
    }
}
