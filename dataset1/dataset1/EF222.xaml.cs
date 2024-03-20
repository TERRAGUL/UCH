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

namespace dataset1
{
    /// <summary>
    /// Логика взаимодействия для EF222.xaml
    /// </summary>
    public partial class EF222 : Window
    {
        private MisevDB Pizza = new MisevDB();
        public EF222()
        {
            InitializeComponent();

            Grid.ItemsSource = Pizza.Sotrudniki.ToList();            
        }

        private void Exit2(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
