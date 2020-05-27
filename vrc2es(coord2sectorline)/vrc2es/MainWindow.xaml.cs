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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vrc2es
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Convert(object sender, RoutedEventArgs e)
        {

            if (vrc.Text.Contains("N"))
            {
                string replaced = vrc.Text.Replace("N", "COORD:N0").Replace(' ', ':');
                es.Text = replaced;
                return;
            } else if (vrc.Text.Contains("S"))
            {
                string replaced = vrc.Text.Replace("S", "COORD:S0").Replace(' ', ':');
                es.Text = replaced;
                return;
            } else
            {
                return;
            }
        }
    }
}
