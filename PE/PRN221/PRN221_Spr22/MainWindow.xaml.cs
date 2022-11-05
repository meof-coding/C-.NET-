using Microsoft.EntityFrameworkCore;
using PRN221_Spr22.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRN221_Spr22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PRN221_Spr22Context _context = new PRN221_Spr22Context();
        public MainWindow()
        {
            InitializeComponent();
            GetEmployees();
        }
        //View Model for this screen
        public class Employee_View
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Gender { get; set; }
            public string? Dob { get; set; }
            public string? Phone { get; set; }
            public string? Idnumber { get; set; }
        }

        //Get Employee from Database
        private void GetEmployees()
        { 
            using var context1 = new PRN221_Spr22Context();
            List<Employee_View> employee_Views = new List<Employee_View>();
            //get all emplooyee whi has phone number not null
            foreach (var emp in context1.Employees)
            {
                if (!String.IsNullOrEmpty(emp.Phone.Trim()))
                {
                    Employee_View employee_view = new Employee_View();
                    employee_Views.Add(new Employee_View
                    {
                        Id = emp.Id,
                        Name = emp.Name,
                        Gender = emp.Gender,
                        Dob = emp.Dob.ToString(),
                        Phone = emp.Phone,
                        Idnumber = emp.Idnumber
                    });
                } 
            }
            lvEmployees.ItemsSource = employee_Views;
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            tbDate.Text = "";
            txtPhone.Text = "";
            txtIDNumber.Text = "";
            radioButton1.IsChecked = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee
            {
                Name = txtEmployeeName.Text,
                Dob = DateTime.Parse(tbDate.Text),
                Phone = txtPhone.Text,
                Idnumber = txtIDNumber.Text
            };
            if (radioButton1.IsChecked == true)
            {
                employee.Gender = "Male";
            }
            else if (radioButton2.IsChecked == true)
            {
                employee.Gender = "Female";
            }

            using (var context = new PRN221_Spr22Context())
            {
                context.Add(employee);
                context.SaveChanges();
            }

            btnRefresh_Click(sender, e);
            GetEmployees();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtEmployeeID.IsEnabled = false;
            Employee_View employee_View = new Employee_View();
            employee_View.Name = txtEmployeeName.Text;
            employee_View.Phone = txtPhone.Text;
            employee_View.Dob = tbDate.Text;
            employee_View.Idnumber = txtIDNumber.Text;
            employee_View.Id = Convert.ToInt32(txtEmployeeID.Text);
            if (radioButton1.IsChecked == true)
            {
                employee_View.Gender = "Male";
            }
            else if (radioButton2.IsChecked == true)
            {
                employee_View.Gender = "Female";
            }
            Employee employee = new Employee()
            {
                Name = employee_View.Name,
                Phone = employee_View.Phone,
                Dob = DateTime.Parse(employee_View.Dob),
                Gender = employee_View.Gender,
                Id = employee_View.Id,
                Idnumber = employee_View.Idnumber,
            };
            using (PRN221_Spr22Context context1 = new PRN221_Spr22Context())
            {
                context1.Update(employee);
                context1.SaveChanges();
            }
            btnRefresh_Click(sender, e);
            GetEmployees();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (var context1 = new PRN221_Spr22Context())
            {
                var services = context1.Services.Where(s => s.Employee == Convert.ToInt32(txtEmployeeID.Text)).ToList();
                foreach (var service in services)
                {
                    context1.Remove(service);
                }
                var employee = context1.Employees.Find(Convert.ToInt32(txtEmployeeID.Text));
                context1.Remove(employee);
                context1.SaveChanges();
            }

            btnRefresh_Click(sender, e);
            GetEmployees();
        }

        private void lvEmployees_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (lvEmployees.SelectedItems.Count <= 0) return;
            var selected = (Employee_View)lvEmployees.SelectedValue;
            if (selected.Gender != null)
            {
                if (selected.Gender.Equals("Male"))
                {
                    radioButton1.IsChecked = true;
                }
                else
                {
                    radioButton2.IsChecked = true;
                }
            }
            tbDate.Text = selected.Dob;

        }
    }
}
