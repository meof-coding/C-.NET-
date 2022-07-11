
namespace EX3_PE2020
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lboxKhachhang = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(632, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày yêu cầu";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(845, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(400, 39);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(632, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Địa chỉ giao hàng";
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(845, 152);
            this.txtAdress.Multiline = true;
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(482, 256);
            this.txtAdress.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(981, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 64);
            this.button1.TabIndex = 5;
            this.button1.Text = "Tạo đơn hàng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lboxKhachhang
            // 
            this.lboxKhachhang.FormattingEnabled = true;
            this.lboxKhachhang.ItemHeight = 32;
            this.lboxKhachhang.Items.AddRange(new object[] {
            "Giáp Phương Thảo",
            "Hoàng Đức Chính",
            "Vũ Thu Phương",
            "Võ Lan Viên",
            "Đoàn Thanh Hải"});
            this.lboxKhachhang.Location = new System.Drawing.Point(54, 117);
            this.lboxKhachhang.Name = "lboxKhachhang";
            this.lboxKhachhang.Size = new System.Drawing.Size(299, 356);
            this.lboxKhachhang.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 635);
            this.Controls.Add(this.lboxKhachhang);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lboxKhachhang;
    }
}

