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
using dataset1.MisevDataSet1TableAdapters;

namespace dataset1
{
    /// <summary>
    /// Логика взаимодействия для DataSet.xaml
    /// </summary>
    public partial class DataSet : Window
    {
        SotrudnikiTableAdapter SotrudnikiTable = new SotrudnikiTableAdapter();
        ColorsTableAdapter ColorsTable = new ColorsTableAdapter(); 
        public DataSet()
        {
            InitializeComponent();
            MisevGrid.ItemsSource = SotrudnikiTable.GetHull();

           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MisevGrid.Columns[0].Visibility = Visibility.Collapsed;
            MisevGrid.Columns[1].Visibility = Visibility.Collapsed;
            MisevGrid.Columns[2].Visibility = Visibility.Collapsed;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
