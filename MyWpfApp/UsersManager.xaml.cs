using Microsoft.EntityFrameworkCore;
using MyEFLibrary.Models;
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

namespace MyWpfApp
{
    /// <summary>
    /// Interaction logic for UsersManager.xaml
    /// </summary>
    public partial class UsersManager : Window
    {
        private EftestDbContext _dbCtx;
        public UsersManager()
        {
            InitializeComponent();
        }

        private async void Load_Click(object sender, RoutedEventArgs e)
        {
            await _dbCtx.Users.LoadAsync();


            var singleUser = await _dbCtx.Users.FirstOrDefaultAsync( u => u.Id == 13);


            dgUsers.ItemsSource = _dbCtx.Users.Local.ToBindingList();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await _dbCtx.SaveChangesAsync();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _dbCtx = new EftestDbContext();
        }

        private void dgUsers_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if(e.Column.Header.Equals("Id"))
            {
                e.Column.IsReadOnly = true;
            }
        }
    }
}
