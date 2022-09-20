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
    /// Interaction logic for RadioButton.xaml
    /// </summary>
    public partial class RadioButton : Window
    {
        public RadioButton()
        {
            InitializeComponent();
        }

        private void btnGetValues_Click(object sender, RoutedEventArgs e)
        {
            string result="", result1 = "";
            if (g1.IsChecked == true)
                result += g1.Content.ToString() + " is checked.\n";
            else if(g2.IsChecked==true)
                result += g2.Content.ToString() + " is checked.\n";
            else if (g3.IsChecked == true)
                result += g3.Content.ToString() + " is checked.\n";
            else
                result += g4.Content.ToString() + " is checked.\n";

            if (g5.IsChecked == true)
                result1 += g5.Content.ToString() + " is checked.\n";
            else if (g6.IsChecked == true)
                result1 += g6.Content.ToString() + " is checked.\n";
            else if (g7.IsChecked == true)
                result1 += g7.Content.ToString() + " is checked.\n";
            else
                result1 += g8.Content.ToString() + " is checked.\n";

            txtSelection.Text = result + result1;
        }
    }
}
