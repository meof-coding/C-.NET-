using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResourceManagement
{
    public partial class FrmEmployeeDetail : Form
    {
        public FrmEmployeeDetail()
        {
            InitializeComponent();
        }

        bool Addnew = true;
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Kiem tra tinh hop le cua du lieu dau vao
            if (ValidForm())
            {
                Employee em = new Employee()
                {
                    Emp_ID = txtEmployeeID.Text.Trim(),
                    Emp_Name = txtEmployeeName.Text.Trim(),
                    Phone = mtxtPhone.Text,
                    Gender = rbMale.Checked ? "Male" : "Female",
                    Degree = cboDegree.SelectedItem.ToString()
                };
                if (Addnew == true)
                {
                    if (checkExist(em) == null)
                    {
                        emplList.Add(em);
                        txtEmployeeID.Clear();
                        txtEmployeeName.Clear();
                        mtxtPhone.Clear();
                        rbMale.Checked = true;
                        cboDegree.ResetText();
                        Reload_Form();
                    }
                    else
                    {
                        MessageBox.Show($"{em.Emp_ID} already exist");
                        txtEmployeeName.Focus();
                    }
                }
                else
                {
                        Employee update = checkExist(em);
                        update.Emp_Name = txtEmployeeName.Text.Trim();
                        update.Phone = mtxtPhone.Text;
                        update.Gender = rbMale.Checked ? "Male" : "Female";
                        update.Degree = cboDegree.SelectedItem.ToString();
                        txtEmployeeID.Clear();
                        txtEmployeeName.Clear();
                        mtxtPhone.Clear();
                        rbMale.Checked = true;
                        Addnew = true;
                        txtEmployeeID.Enabled = true;
                        txtEmployeeID.Focus();
                        txtEmployeeName.Focus();
                        cboDegree.ResetText();
                        Reload_Form();                   
                }

            }
            
            //neu hop le => load du lieu vao data grid view
            
        }

        private Employee checkExist(Employee employee)
        {
            foreach (var item in emplList)
            {
                if (item.Emp_ID.Equals(employee.Emp_ID))
                {
                    return item;
                }
            }
            return null;
        }

        private bool ValidForm()
        {
            bool flag = true;
            string Err = "";
            Regex reg_emID = new Regex(@"^E\d{4}$");
            if (!reg_emID.IsMatch(txtEmployeeID.Text.Trim()))
            {
                flag = false;
                Err += "Empployee_ID invalid\n";
                txtEmployeeID.Focus();
            }
            Regex reg_emName = new Regex(@"^[a-zA-Z\s]+$");
            if (!reg_emName.IsMatch(txtEmployeeName.Text.Trim()))
            {
                flag = false;
                Err += "Empployee_Name not: Empty or Number , special character\n";
                txtEmployeeName.Focus();
            }

            if(cboDegree.SelectedIndex == -1)
            {
                flag = false;
                Err += "Degree should be selected\n";
                cboDegree.Focus();
            }
            if (!flag)
            {
                MessageBox.Show(Err);
            }
            return flag;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Dong Forms
            this.Close();
            //Neu muon Close tat ca cac Form cua Project dang show
            //Application.Exit();
        }

        List<Employee> emplList = new List<Employee>();

        void Reload_Form()
        {
            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = emplList;
            dgvEmployee.Columns[0].HeaderText = "Employee ID";
            dgvEmployee.Columns[1].HeaderText = "Employee Name";
            dgvEmployee.Columns[2].HeaderText = "Gender";
            dgvEmployee.Columns[3].HeaderText = "Phone";
            dgvEmployee.Columns[4].HeaderText = "Degree";
        }
        private void FrmEmployeeDetail_Load(object sender, EventArgs e)
        {
           
            //Khoi tao du lieu mac dinh cho empList
            emplList.Add(new Employee()
            {
                Emp_ID = "E1234",
                Emp_Name = "Dung Leee Beo",
                Gender="Male",
                Phone="1245345650",
                Degree = "Master"
            });
            Reload_Form();
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Addnew = false;
            btnSave.Text = "Update";
            txtEmployeeID.Enabled = false;
            txtEmployeeID.Text = dgvEmployee.CurrentRow.Cells[0].Value.ToString();
            txtEmployeeName.Text = dgvEmployee.CurrentRow.Cells[1].Value.ToString();
            mtxtPhone.Text = dgvEmployee.CurrentRow.Cells[3].Value.ToString();
            if (dgvEmployee.CurrentRow.Cells[2].Value.ToString().Equals("Male")) {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }
            cboDegree.SelectedItem = dgvEmployee.CurrentRow.Cells[4].Value.ToString();
            //cboDegree.Text = dgvEmployee.CurrentRow.Cells[4].Value.ToString();;
        }
    }

    public class Employee
    {
        public string Emp_ID { get; set; }

        public string Emp_Name { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Degree { get; set; }

    }
}
