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
using dataset1.MisevDataSetTableAdapters;
using misya1;

namespace dataset1
{
    /// <summary>
    /// Логика взаимодействия для EF.xaml
    /// </summary>
    public partial class EF : Window
    {

        private MisevEntities Pizza = new MisevEntities();
        public EF()
        {
            InitializeComponent();


            List<String> tables = new List<String> { "Цвета", "Должности", "Сотрудники" };

            ComboBoxTables.ItemsSource = tables;
            ComboBoxTables.SelectedIndex = 2;
            Sotrudnikida.ItemsSource = Pizza.Sotrudniki_View.ToList();
        }

        private void ToDataSet(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Sotrudniki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string da = ComboBoxTables.Items[ComboBoxTables.SelectedIndex] as string;

            if (da == "Цвета")
            {
                Sotrudnikida.ItemsSource = Pizza.Colors_View.ToList();
            }
            else if (da == "Должности")
            {
                Sotrudnikida.ItemsSource = Pizza.Dolzhnocti_View.ToList();
            }
            else if (da == "Сотрудники")
            {
                Sotrudnikida.ItemsSource = Pizza.Sotrudniki_View.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void izmenit(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dobavit(object sender, RoutedEventArgs e)
        {
            string da = ComboBoxTables.Items[ComboBoxTables.SelectedIndex] as string;

            if (da == "Цвета")
            {
                Colors colors = new Colors();
                colors.ColorName = TextBox1.Text;
                Pizza.Colors.Add(colors);
                Pizza.SaveChanges();
                Sotrudnikida.ItemsSource = Pizza.Colors_View.ToList();
            }
            else if (da == "Должности")
            {
                Dolzhnocti dolzhnocti = new Dolzhnocti();
                dolzhnocti.Dolzhnoct = TextBox1.Text;
                dolzhnocti.Salary = Convert.ToInt32(TextBox2.Text);
                Pizza.Dolzhnocti.Add(dolzhnocti);
                Pizza.SaveChanges();
                Sotrudnikida.ItemsSource = Pizza.Dolzhnocti_View.ToList();
            }
            else if (da == "Сотрудники")
            {
                Sotrudniki sotrudniki = new Sotrudniki();
                sotrudniki.Dolzhnosti_ID = Convert.ToInt32(TextBox1.Text);
                sotrudniki.Color_id = Convert.ToInt32(TextBox2.Text);
                sotrudniki.FirstName = TextBox3.Text;
                sotrudniki.SurName = TextBox4.Text;
                sotrudniki.MiddleName = TextBox5.Text;
                sotrudniki.Age = Convert.ToInt32(TextBox6.Text);
                Pizza.Sotrudniki.Add(sotrudniki);
                Pizza.SaveChanges();
                Sotrudnikida.ItemsSource = Pizza.Sotrudniki_View.ToList();
            }
        }

        private void udalit(object sender, RoutedEventArgs e)
        {
            string da = ComboBoxTables.Items[ComboBoxTables.SelectedIndex] as string;

            if (ComboBoxTables.SelectedItem != null) 
            {
                if (da == "Цвета")
                {
                    Pizza.Colors.Remove(ComboBoxTables.SelectedItem as Colors);
                    Pizza.SaveChanges();
                    Sotrudnikida.ItemsSource = Pizza.Colors_View.ToList();
                }
                else if (da == "Должности")
                {
                    Pizza.Dolzhnocti.Remove(ComboBoxTables.SelectedItem as Dolzhnocti);
                    Pizza.SaveChanges();
                    Sotrudnikida.ItemsSource = Pizza.Dolzhnocti_View.ToList();
                }
                else if (da == "Сотрудники")
                {
                    Pizza.Sotrudniki.Remove(ComboBoxTables.SelectedItem as Sotrudniki);
                    Pizza.SaveChanges();
                    Sotrudnikida.ItemsSource = Pizza.Sotrudniki_View.ToList();
                }
            }
        }
    }
}
