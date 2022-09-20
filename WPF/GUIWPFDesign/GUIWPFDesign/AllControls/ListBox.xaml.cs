using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace AllControls
{
    /// <summary>
    /// Interaction logic for ListBox.xaml
    /// </summary>
    public partial class ListBox : Window
    {
        public ListBox()
        {
            InitializeComponent();
        }

        private void btnGetValues_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder s = new StringBuilder();
            foreach (CheckBox item in lst.Items)
            {
                if (item.IsChecked==true)
                {
                    s.Append(item.Content + " is checked.");
                    s.Append("\r\n");
                }
            }
            txtSelection.Text = s.ToString();
        }
    }
}
