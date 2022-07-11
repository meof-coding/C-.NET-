
namespace PE19SpringB5_1
{
    partial class CorporationListForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDelCor = new System.Windows.Forms.Button();
            this.dgvCorp = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Corporation_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Region_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Corporation_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelCor
            // 
            this.btnDelCor.Location = new System.Drawing.Point(1338, 30);
            this.btnDelCor.Name = "btnDelCor";
            this.btnDelCor.Size = new System.Drawing.Size(211, 54);
            this.btnDelCor.TabIndex = 0;
            this.btnDelCor.Text = "Delete Corporation ";
            this.btnDelCor.UseVisualStyleBackColor = true;
            this.btnDelCor.Click += new System.EventHandler(this.btnDelCor_Click);
            // 
            // dgvCorp
            // 
            this.dgvCorp.AllowUserToAddRows = false;
            this.dgvCorp.AllowUserToDeleteRows = false;
            this.dgvCorp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.Corporation_Name,
            this.Street,
            this.Region_Name,
            this.Edit});
            this.dgvCorp.Location = new System.Drawing.Point(23, 114);
            this.dgvCorp.Name = "dgvCorp";
            this.dgvCorp.RowHeadersWidth = 72;
            this.dgvCorp.RowTemplate.Height = 37;
            this.dgvCorp.Size = new System.Drawing.Size(1591, 604);
            this.dgvCorp.TabIndex = 1;
            this.dgvCorp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCorp_CellContentClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Select";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 9;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 175;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Corporation_No";
            this.dataGridViewTextBoxColumn1.HeaderText = "Corporation No";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 9;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 175;
            // 
            // Corporation_Name
            // 
            this.Corporation_Name.DataPropertyName = "Corporation_Name";
            this.Corporation_Name.HeaderText = "Corporation Name";
            this.Corporation_Name.MinimumWidth = 9;
            this.Corporation_Name.Name = "Corporation_Name";
            this.Corporation_Name.Width = 175;
            // 
            // Street
            // 
            this.Street.DataPropertyName = "Street";
            this.Street.HeaderText = "Street";
            this.Street.MinimumWidth = 9;
            this.Street.Name = "Street";
            this.Street.Width = 175;
            // 
            // Region_Name
            // 
            this.Region_Name.DataPropertyName = "Region_Name";
            this.Region_Name.HeaderText = "Region Name";
            this.Region_Name.MinimumWidth = 9;
            this.Region_Name.Name = "Region_Name";
            this.Region_Name.Width = 175;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.MinimumWidth = 9;
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 175;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Select";
            this.Column1.MinimumWidth = 9;
            this.Column1.Name = "Column1";
            this.Column1.Width = 175;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.MinimumWidth = 10;
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.Width = 175;
            // 
            // Corporation_No
            // 
            this.Corporation_No.DataPropertyName = "Corporation_No";
            this.Corporation_No.HeaderText = "Corporation_No";
            this.Corporation_No.MinimumWidth = 9;
            this.Corporation_No.Name = "Corporation_No";
            this.Corporation_No.Width = 175;
            // 
            // CorporationListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1654, 738);
            this.Controls.Add(this.dgvCorp);
            this.Controls.Add(this.btnDelCor);
            this.Name = "CorporationListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CorporationListForm";
            this.Load += new System.EventHandler(this.CorporationListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelCor;
        private System.Windows.Forms.DataGridView dgvCorp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Corporation_No;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Corporation_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Street;
        private System.Windows.Forms.DataGridViewTextBoxColumn Region_Name;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}

