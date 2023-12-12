using CatShelter.Entities;
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
    /// Логика взаимодействия для AddEditApplicationPage.xaml
    /// </summary>
    public partial class AddEditApplicationPage : Page
    {
        Cats cat = new Cats();
        public AddEditApplicationPage(Cats cats)
        {
            InitializeComponent();
            cat = cats;
            DataContext = cat;
            FIOTxt.Text = App.CurrentUser.FIO.ToString();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var applications = new Applications()
            {
                Client = App.CurrentUser.UserID,
                Cat = cat.CatID
            };
            if (cat.CatID != 0)
                App.Context.Applications.Add(applications);
            try
            {
                App.Context.SaveChanges();
                MessageBox.Show("Заявка на принятие кота в семью отправлена", "Увдеомление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
