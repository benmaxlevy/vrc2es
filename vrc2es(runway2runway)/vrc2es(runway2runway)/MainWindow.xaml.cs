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

namespace vrc2es_runway2runway_
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
            es.Text = "";

            String text = vrc.Text;
            text = text.Replace(";", "");

            List<string> all = new List<string>();

            all = text.Split('\n').ToList();

            for (int i = 0; i<all.ToArray().Length; i++) 
            {
                if (all[i].ToString()[8] == '0' || all[i].ToString()[8] == '1' || all[i].ToString()[8] == '2' || all[i].ToString()[8] == '3' || all[i].ToString()[8] == '4' || all[i].ToString()[8] == '5' || all[i].ToString()[8] == '6' || all[i].ToString()[8] == '7' || all[i].ToString()[8] == '8' || all[i].ToString()[8] == '9')
                {
                    if (all[i].ToString()[9] == '0' || all[i].ToString()[9] == '1' || all[i].ToString()[9] == '2' || all[i].ToString()[9] == '3' || all[i].ToString()[9] == '4' || all[i].ToString()[9] == '5' || all[i].ToString()[9] == '6' || all[i].ToString()[9] == '7' || all[i].ToString()[9] == '8' || all[i].ToString()[9] == '9')
                    {

                        if (all[i].ToString()[10] == '0' || all[i].ToString()[10] == '1' || all[i].ToString()[10] == '2' || all[i].ToString()[10] == '3' || all[i].ToString()[10] == '4' || all[i].ToString()[10] == '5' || all[i].ToString()[10] == '6' || all[i].ToString()[10] == '7' || all[i].ToString()[10] == '8' || all[i].ToString()[10] == '9')
                        {
                            
                        }
                        else
                        {
                            all[i] = all[i].Insert(7, " 0");
                            all[i] = all[i].Remove(9, 1);
                            all[i] = all[i].Remove(11, 1);
                            es.Text += all[i];
                        }

                    }
                    else
                    {
                        all[i] = all[i].Insert(7, " 00");
                        all[i] = all[i].Remove(10, 1);
                        all[i] = all[i].Remove(12, 2);
                        es.Text += all[i];
                        
                    }
                }
                else
                {
                    MessageBox.Show("Please make sure you're inputing at least 1 entry from the [RUNWAY] section in your VRC SCT2.", "VRC2ES(RUNWAY2RUNWAY) - BEN LEVY", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                //NEED TO MAKE IT DO ^, BUT FOR THE SECOND HEADING IN THE LINE
            }
           
        }
    }
}
