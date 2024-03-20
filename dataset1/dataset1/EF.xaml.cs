using System;
using System.Collections.Generic;
using System.Data;
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

        private MisevDB Pizza = new MisevDB();
        public EF()
        {
            InitializeComponent();


            List<String> tables = new List<String> { "Цвета", "Должности", "Сотрудники" };

            ComboBoxTables.ItemsSource = tables;
            ComboBoxTables.SelectedIndex = 2;
            Sotrudnikida.ItemsSource = Pizza.Sotrudniki_View.ToList();



            CbxDol.ItemsSource = Pizza.Dolzhnocti.ToList();
            CbxDol.DisplayMemberPath = "Dolzhnoct";

            CbxCol.ItemsSource = Pizza.Colors.ToList();
            CbxCol.DisplayMemberPath = "ColorName";

            DanyaCbx.ItemsSource = Pizza.Colors.ToList();
            DanyaCbx.DisplayMemberPath = "ColorName";
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
                sotrudniki.Dolzhnosti_ID = CbxDol.SelectedIndex + 1;
                sotrudniki.Color_id = CbxCol.SelectedIndex + 1;
                sotrudniki.FirstName = TextBox1.Text;
                sotrudniki.SurName = TextBox2.Text;
                sotrudniki.MiddleName = TextBox3.Text;
                sotrudniki.Age = Convert.ToInt32(TextBox4.Text);
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


        private void SEARCHALL_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FOUND(object sender, RoutedEventArgs e)
        {

            string da = ComboBoxTables.Items[ComboBoxTables.SelectedIndex] as string;

            

            if (da == "Цвета")
            {
                Sotrudnikida.ItemsSource = Pizza.Colors.ToList().Where(item => item.ColorName.Contains(SEARCHALL.Text));
                Sotrudnikida.Columns[0].Visibility = Visibility.Hidden;
            }
            else if (da == "Должности")
            {
                Sotrudnikida.ItemsSource = Pizza.Dolzhnocti.ToList().Where(item => item.Dolzhnoct.Contains(SEARCHALL.Text));
            }
            else if (da == "Сотрудники")
            {
                Sotrudnikida.ItemsSource = Pizza.Sotrudniki.ToList().Where(item => item.SurName.Contains(SEARCHALL.Text));
                Sotrudnikida.Columns[0].Visibility = Visibility.Hidden;
                Sotrudnikida.Columns[1].Visibility = Visibility.Hidden;
            }
        }

        private void ComboBox_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {
            if (DanyaCbx.SelectedItem != null)
            {
                var selected = DanyaCbx.SelectedItem as Colors;
                Sotrudnikida.ItemsSource = Pizza.Sotrudniki.ToList().Where(item => item.Color_id == selected.ID_Color);
                Sotrudnikida.Columns[0].Visibility = Visibility.Hidden;
                Sotrudnikida.Columns[1].Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Sotrudnikida.ItemsSource = Pizza.Sotrudniki.ToList();
            Sotrudnikida.Columns[7].Visibility = Visibility.Hidden;
            Sotrudnikida.Columns[8].Visibility = Visibility.Hidden;
        }

        private void CbxDol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
