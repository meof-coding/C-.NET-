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
    /// Interaction logic for ComboBox.xaml
    /// </summary>
    public partial class ComboBox : Window
    {
        public ComboBox()
        {
            InitializeComponent();
        }

        private void btnGetColor_Click(object sender, RoutedEventArgs e)
        {
            var stackPanel = (StackPanel)cbColors.SelectedItem;
            var label = (Label)stackPanel.Children[1];
            string color = label.Content.ToString();
            txtSelection.Text = "Your color is: " + color;
        }

        private void cbColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var stackPanel = (StackPanel)cbColors.SelectedItem;
            var label = (Label)stackPanel.Children[1];
            string color = label.Content.ToString();
            txtSelection.Text = "Your color is: " + color;
        }

        private void btnGetCity_Click(object sender, RoutedEventArgs e)
        {
            var item = cbCity.SelectedItem as ComboBoxItem;
            txtResult.Text = item.Content.ToString();
        }
    }
}
