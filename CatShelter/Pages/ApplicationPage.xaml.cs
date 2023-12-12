using CatShelter.Entities;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatShelter.Pages
{
    /// <summary>
    /// Логика взаимодействия для ApplicationPage.xaml
    /// </summary>
    public partial class ApplicationPage : Page
    {
        public ApplicationPage()
        {
            InitializeComponent();
            ListApplication.ItemsSource = App.Context.Applications.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var delete = (sender as Button).DataContext as Applications;
            if(MessageBox.Show($"Вы точно хотите удалить заявку {delete.FIO}","Уведомление",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.Context.Applications.Remove(delete);
                App.Context.SaveChanges();
            }
        }
    }
}
