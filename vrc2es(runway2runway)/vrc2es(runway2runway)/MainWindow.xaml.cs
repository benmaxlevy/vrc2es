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

            MessageBox.Show("Please make sure you input the runways in the same format as this example: \"04  22  49  229 N031.43.54.226 W086.16.03.254 N031.44.27.755 W086.15.26.395; 04A - FRANK SIKES\"!", "VRC2ES(RUNWAY2RUNWAY) - BEN LEVY", MessageBoxButton.OK, MessageBoxImage.Information);

            es.Text = "";

            String text = vrc.Text;
            text = text.Replace(";", "");

            if(text.Length < 10)
            {
                MessageBox.Show("Please make sure you're inputing at least 1 entry from the [RUNWAY] section in your VRC SCT2.", "VRC2ES(RUNWAY2RUNWAY) - BEN LEVY", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<string> all = new List<string>();

            all = text.Split('\n').ToList();

            

            for (int i = 0; i<all.ToArray().Length; i++) 
            {

                if (all[i].ToString().Length >= 10)
                {
                    //fix apt icao code
                    if(all[i].ToString()[76] == '1' || all[i].ToString()[76] == '2' || all[i].ToString()[76] == '3' || all[i].ToString()[76] == '4' || all[i].ToString()[76] == '5' || all[i].ToString()[76] == '6' || all[i].ToString()[76] == '7' || all[i].ToString()[76] == '8' || all[i].ToString()[76] == '9' || all[i].ToString()[76] == '0' || all[i].ToString()[76] == 'X' || all[i].ToString()[76] == 'S')
                    {

                    } 
                    else
                    {
                        all[i] = all[i].ToString().Insert(76, "K");
                    }

                    //add space between "-"

                    all[i] = all[i].ToString().Insert(all[i].IndexOf('-'), " ");
                    all[i] = all[i].ToString().Insert(all[i].IndexOf('-')+1, " ");

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
                                
                            }

                        }
                        else
                        {
                            all[i] = all[i].Insert(7, " 00");
                            all[i] = all[i].Remove(10, 1);
                            all[i] = all[i].Remove(12, 2);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please make sure you're inputing at least 1 entry from the [RUNWAY] section in your VRC SCT2.", "VRC2ES(RUNWAY2RUNWAY) - BEN LEVY", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                //second heading
                if (all[i].ToString()[12] == '0' || all[i].ToString()[12] == '1' || all[i].ToString()[12] == '2' || all[i].ToString()[12] == '3' || all[i].ToString()[12] == '4' || all[i].ToString()[12] == '5' || all[i].ToString()[12] == '6' || all[i].ToString()[12] == '7' || all[i].ToString()[12] == '8' || all[i].ToString()[12] == '9')
                {
                    if (all[i].ToString()[13] == '0' || all[i].ToString()[13] == '1' || all[i].ToString()[13] == '2' || all[i].ToString()[13] == '3' || all[i].ToString()[13] == '4' || all[i].ToString()[13] == '5' || all[i].ToString()[13] == '6' || all[i].ToString()[13] == '7' || all[i].ToString()[13] == '8' || all[i].ToString()[13] == '9')
                    {

                        if (all[i].ToString()[14] == '0' || all[i].ToString()[14] == '1' || all[i].ToString()[14] == '2' || all[i].ToString()[14] == '3' || all[i].ToString()[14] == '4' || all[i].ToString()[14] == '5' || all[i].ToString()[14] == '6' || all[i].ToString()[14] == '7' || all[i].ToString()[14] == '8' || all[i].ToString()[14] == '9')
                        {
                            es.Text += all[i];
                        }
                        else
                        {
                            all[i] = all[i].Insert(11, " 0");
                            all[i] = all[i].Remove(14, 1);
                            all[i] = all[i].Remove(16, 2);
                            es.Text += all[i];
                        }

                    }
                    else
                    {
                        all[i] = all[i].Insert(11, " 00");
                        all[i] = all[i].Remove(14, 1);
                        all[i] = all[i].Remove(16, 2);
                        es.Text += all[i];

                    }
                }
                else
                {
                    MessageBox.Show("Please make sure you're inputing at least 1 entry from the [RUNWAY] section in your VRC SCT2.", "VRC2ES(RUNWAY2RUNWAY) - BEN LEVY", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


            }
           
        }
    }
}
