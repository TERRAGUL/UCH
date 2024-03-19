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
using p3265.p3DataSetTableAdapters;

namespace p3265
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();


        }

        private void left(object sender, RoutedEventArgs e)
        {
            datatata datatatatatata = new datatata();
            datatatatatata.Show();
            Close();
        }

        private void right(object sender, RoutedEventArgs e)
        {
            vtoroeokno supervtoroe = new vtoroeokno();
            supervtoroe.Show();
            Close();
        }

    }
}
