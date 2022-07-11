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
        PE_PRN_Sum21Context db = new PE_PRN_Sum21Context();
        public Form1()
        {
            InitializeComponent();
        }
        void reLoad()
        {
            var emp = db.Employees.ToList();
            dgvEmp.DataSource = emp;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee()
            {
                EmployeeName = txtEmpName.Text,
                Male = rdMale.Checked ? true : false,
                Salary = Convert.ToInt32(numSalary.Value.ToString()),
                Phone = mtxtPhone.Text.Trim(),
            };
            db.Employees.Add(emp);
            db.SaveChanges();
            reLoad();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            
            int EmpID = Int32.Parse(dgvEmp.SelectedRows[0].Cells[0].Value.ToString());
            var result = (from i in db.Employees
                          where i.EmployeeId == EmpID
                          select i).SingleOrDefault();
            if (result != null)
            {

                result.EmployeeName = txtEmpName.Text;
                result.Male = rdMale.Checked ? true : false;
                result.Salary = Convert.ToInt32(numSalary.Value.ToString());
                result.Phone = mtxtPhone.Text.Trim();
                db.SaveChanges();
                reLoad();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int EmpID = Int32.Parse(dgvEmp.SelectedRows[0].Cells[0].Value.ToString());
            var emp = (from i in db.Employees
                       where i.EmployeeId == EmpID
                       select i).FirstOrDefault();
            db.Employees.Remove(emp);
            db.SaveChanges();
            reLoad();
        }

        private void dgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            txtEmpName.Text = dgvEmp.Rows[indexRow].Cells[1].Value.ToString();
            bool male = Convert.ToBoolean(dgvEmp.Rows[indexRow].Cells[2].Value);
            if (male == true) rdMale.Checked = true;
            else rdFemale.Checked = true;
            numSalary.Value = Convert.ToInt32(dgvEmp.Rows[indexRow].Cells[3].Value);
            mtxtPhone.Text = dgvEmp.Rows[indexRow].Cells[4].Value.ToString();
        }
    }
}
