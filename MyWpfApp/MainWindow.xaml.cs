﻿using CSharpConsole.Exercises;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWpfApp
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

        private void BtnOK_Clicked2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked!");
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            
            txtContent.Text += txtDescription.Text + Environment.NewLine;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var names = new[] {"John", "Mark", "Bob", "Anna" };
            //cbxNames.ItemsSource = names;
            var users = CreateCollection.GetUsers().Where(u => u is not null).ToArray();

            cbxNames.ItemsSource = users;
            cbxNames.DisplayMemberPath = "Name";

            cbxNames.SelectedIndex = 0;
        }

        private void cbxNames_SelectionChanged(object seneder, SelectionChangedEventArgs e)
        {
            txtContent.Text += ((User)cbxNames.SelectedItem).Name + Environment.NewLine;
        }

        private void btnOK_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            var usersWindow = new UsersWindow() { Users = cbxNames.Items.OfType<User>().ToArray() };

            usersWindow.ShowDialog();
            
        }
    }
}