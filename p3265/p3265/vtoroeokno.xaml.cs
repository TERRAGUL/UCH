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

namespace p3265
{
    /// <summary>
    /// Логика взаимодействия для vtoroeokno.xaml
    /// </summary>
    public partial class vtoroeokno : Window
    {
        p3Entities context = new p3Entities();
        public vtoroeokno()
        {
            InitializeComponent();

            vtorayatabl.ItemsSource = context.Courses.ToList();
        }
    }
}
