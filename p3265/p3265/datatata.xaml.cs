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
using p3265.p3DataSetTableAdapters;

namespace p3265
{
    /// <summary>
    /// Логика взаимодействия для datatata.xaml
    /// </summary>
    public partial class datatata : Window
    {

        StudentsTableAdapter Student = new StudentsTableAdapter();
        public datatata()
        {
            InitializeComponent();

            Datata.ItemsSource = Student.GetDataBy();

            Datata.Columns[0].Visibility = Visibility.Collapsed;
            Datata.Columns[4].Visibility = Visibility.Collapsed;
            Datata.Columns[8].Visibility = Visibility.Collapsed;
        }

        private void FOUND_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CLICK(object sender, RoutedEventArgs e)
        {

        }
    }
}
