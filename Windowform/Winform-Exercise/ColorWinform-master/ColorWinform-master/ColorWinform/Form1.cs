using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // choose color
        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = textBox3.BackColor;
            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                textBox3.BackColor = MyDialog.Color;

        }

        // Random code
        private void button1_Click(object sender, EventArgs e)
        {
            int code = RandomNumber(150000, 160000);
            textBox1.Text = "SE" + code.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "SExxxxxx";
        }

        // Add
        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Width = 94;
            btn.Height = 29;
            btn.Text = textBox2.Text;
            btn.BackColor = textBox3.BackColor;
            btn.Click += (sender, args) =>
            {
                String result = $"Label: {btn.Text} \n";
                result += $"RGB: ({btn.BackColor.R}, {btn.BackColor.G}, {btn.BackColor.B})";
                MessageBox.Show(result);
            };
            flowLayoutPanel1.Controls.Add(btn);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
