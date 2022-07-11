using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRN292_Sum2020_B5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BookDAL Mybook = new BookDAL();
       
        void LoadBook()
        {
            List<Book> books = Mybook.GetBook();
            List<string> titles = new List<string>();
            foreach (var item in books)
            {
                titles.Add(item.BookName);
            }
            cmbTittle.DataSource = titles.Distinct().ToList();
            cmbYear.DataSource = Mybook.GetYear(cmbTittle.Text.Trim().Replace("'", "''"));
            listBox1.DataSource = Mybook.GetAuthor(cmbTittle.Text.Trim().Replace("'", "''"));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBook();
        }

        private void cmbTittle_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbYear.DataSource = Mybook.GetYear(cmbTittle.Text.Trim());
            listBox1.DataSource = Mybook.GetAuthor(cmbTittle.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int BookID = Mybook.GetBookID(cmbTittle.Text.Trim().Replace("'", "''"));
            string Author_name= listBox1.SelectedItem.ToString().Trim();
            int AuthorID = Mybook.GetAuthorID(Author_name);
            DialogResult d = MessageBox.Show("Do you really want to remove this author?", "Confirm", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                if (Mybook.DeleteAuthor(AuthorID, BookID) > 0)
                {
                    MessageBox.Show("Delete Successfuly!!");
                    LoadBook();
                }
                else
                {
                    MessageBox.Show("Delete Failed!");
                }
            }
            
          
        }
    }
}
