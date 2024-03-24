using System;
using System.Collections.Generic;
using System.IO;
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

namespace MyWpfApp
{
    /// <summary>
    /// Interaction logic for FileReader.xaml
    /// </summary>
    public partial class FileReader : Window
    {
        public FileReader()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var path = txtFilePath.Text;

            try
            {
                if (!File.Exists(txtFilePath.Text))
                {
                    MessageBox.Show($"File: {path} does not exist");
                    return;
                }

                if (System.IO.Path.GetExtension(txtFilePath.Text).Equals(".txt"))
                {
                    txtContent.Visibility = Visibility.Visible;
                    txtContent.Text = File.ReadAllText(txtFilePath.Text);
                    
                }
                else if(System.IO.Path.GetExtension(txtFilePath.Text).Equals(".png"))
                {
                    imgContent.Visibility = Visibility.Visible;
                    imgContent.Source = new BitmapImage(new Uri(path));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //imgContent.Visibility = Visibility.Visible;
            //imgContent.Source = new BitmapImage(new Uri(path));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (System.IO.Path.GetExtension(txtFilePath.Text).Equals(".png"))
                {
                    imgContent.Visibility = Visibility.Collapsed;
                    imgContent.Source = null;
                    return;
                }

                File.WriteAllText(txtFilePath.Text, txtContent.Text);
                txtContent.Visibility = Visibility.Collapsed;
                imgContent.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
