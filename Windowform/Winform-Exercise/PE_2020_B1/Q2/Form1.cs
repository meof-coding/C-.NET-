using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CourseDAL course = new CourseDAL();
        void LoadCourse()
        {
            List<Subject> subjects = course.GetSubject();
            List<string> sname = new List<string>();
            foreach (var item in subjects)
            {
                sname.Add(item.SubjectName);
            }
            cmbSubject.DataSource = sname;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCourse();
        }
    }
}
