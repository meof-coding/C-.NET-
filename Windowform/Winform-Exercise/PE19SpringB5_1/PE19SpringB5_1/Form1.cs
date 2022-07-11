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

namespace PE19SpringB5_1
{
   
    public partial class CorporationListForm : Form
    {
        public CorporationListForm()
        {
            InitializeComponent();

        }

        Cor_DAL cor = new Cor_DAL();
        // Value to pass to another form
        public string SetCorpName;
        public string SetStreet;
        public DateTime SetDate;
        public int key;

        void LoadCorp()
        {
            List<Corporation> corporations = cor.GetCor();
            dgvCorp.DataSource = corporations;
        }

        private void CorporationListForm_Load(object sender, EventArgs e)
        {
            //xu ly loi trong truong hop bi loi
            try
            {
                LoadCorp();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        //Edit Button onClick
        private void dgvCorp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&  e.RowIndex >= 0)
            {
                SetCorpName = dgvCorp.Rows[e.RowIndex].Cells[3].Value.ToString();
                SetStreet = dgvCorp.Rows[e.RowIndex].Cells[4].Value.ToString();
                SetDate = cor.GetSpecific_Date(int.Parse(dgvCorp.Rows[e.RowIndex].Cells[2].Value.ToString()));
                key = int.Parse(dgvCorp.Rows[e.RowIndex].Cells[2].Value.ToString());
                Editor editor = new Editor(SetCorpName, SetStreet, SetDate,key);
                editor.Show();
                this.Hide();
                editor.FormClosing += Frm_Closing;
            }
        }

        private void Frm_Closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void btnDelCor_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "";
                int count = 0;
                foreach (DataGridViewRow item in dgvCorp.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value))
                    {
                        a += $"{item.Cells[2].Value},";
                        count++;
                    }
                }
                String query_index = a.TrimEnd(',');
                DialogResult d = MessageBox.Show(count > 0 ? $"Are you sure you want to DELETE {count} corporation?" : "You must select one corporation at least!!", "Alert", count > 0 ? MessageBoxButtons.YesNo : MessageBoxButtons.OK);
                if (d == DialogResult.Yes)
                {
                    if (cor.DeleteMultipleCorporation(query_index) > 0)
                    {
                        MessageBox.Show($"Delete ProductID {query_index}  Successfuly!!");
                        LoadCorp();
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed!");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
            
        }
    }
}
