﻿using System;
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
using dataset1;
using System.Data;
using dataset1.MisevDataSetTableAdapters;
using System.Management.Instrumentation;

namespace misya1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Colors_ViewTableAdapter Colors = new Colors_ViewTableAdapter();
        Dolzhnocti_ViewTableAdapter Dolzhnocti = new Dolzhnocti_ViewTableAdapter();
        Sotrudniki_ViewTableAdapter Sotrudniki = new Sotrudniki_ViewTableAdapter();

        ColorsTableAdapter ColorsTable = new ColorsTableAdapter();
        DolzhnoctiTableAdapter DolzhnoctiTable = new DolzhnoctiTableAdapter();
        SotrudnikiTableAdapter SotrudnikiTable = new SotrudnikiTableAdapter();
        public MainWindow()
        {
            InitializeComponent();


            List<String> tables = new List<String> { "Цвета", "Должности", "Сотрудники" };

            ComboBoxTables.ItemsSource = tables;
            ComboBoxTables.SelectedIndex = 2;
            Sotrudnikida.ItemsSource = Sotrudniki.GetData();
        }

        private void Sotrudniki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string da = ComboBoxTables.Items[ComboBoxTables.SelectedIndex] as string;

            if (da == "Цвета")
            {
                Sotrudnikida.ItemsSource = Colors.GetData();
            }
            else if (da == "Должности")
            {
                Sotrudnikida.ItemsSource = Dolzhnocti.GetData();
            }
            else if (da == "Сотрудники")
            {
                Sotrudnikida.ItemsSource = Sotrudniki.GetData();
            }
        }

        private void ToEf(object sender, RoutedEventArgs e)
        {
            EF eF = new EF();
            eF.Show();
            Close();
        }

        private void dobavit(object sender, RoutedEventArgs e)
        {
            string da = ComboBoxTables.Items[ComboBoxTables.SelectedIndex] as string;
            
            switch (da)
            {
                case "Цвета":
                    ColorsTable.InsertQuery(TextBox1.Text);
                    Sotrudnikida.ItemsSource = Colors.GetData();
                    break;

                case "Должности":
                    DolzhnoctiTable.InsertQuery(TextBox1.Text, Convert.ToInt32(TextBox2.Text));
                    Sotrudnikida.ItemsSource = Dolzhnocti.GetData();
                    break;

                case "Сотрудники":
                    SotrudnikiTable.InsertQuery(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text), TextBox3.Text, TextBox4.Text, TextBox5.Text, Convert.ToInt32(TextBox6.Text));
                    Sotrudnikida.ItemsSource = Sotrudniki.GetData();
                    break;


            }
        }
        private void udalit(object sender, RoutedEventArgs e)
        {
            if (Sotrudnikida.SelectedItem != null)
            {
                string da = ComboBoxTables.Items[ComboBoxTables.SelectedIndex] as string;

                if (da == "Цвета")
                {
                    object id = (Sotrudnikida.SelectedItem as DataRowView).Row[0];
                    ColorsTable.DeleteQuery(Convert.ToInt32(id));
                    Sotrudnikida.ItemsSource = Colors.GetData();
                }
                else if (da == "Должности")
                {
                    object id = (Sotrudnikida.SelectedItem as DataRowView).Row[0];
                    DolzhnoctiTable.DeleteQuery(Convert.ToInt32(id));
                    Sotrudnikida.ItemsSource = Dolzhnocti.GetData();
                }
                else if (da == "Сотрудники")
                {
                    object id = (Sotrudnikida.SelectedItem as DataRowView).Row[0];
                    SotrudnikiTable.DeleteQuery(Convert.ToInt32(id));

                    Sotrudnikida.ItemsSource = Sotrudniki.GetData();
                }
            }
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
    }
} 