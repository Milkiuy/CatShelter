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
    /// Логика взаимодействия для CatsPage.xaml
    /// </summary>
    public partial class CatsPage : Page
    {
        public CatsPage()
        {
            InitializeComponent();
            ListCats.ItemsSource = App.Context.Cats.ToList();
            if(App.CurrentUser == null || App.CurrentUser.Role == 2)
                AddBtn.Visibility = Visibility.Hidden;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InfoBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите вернуться?","Уведомление",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
            }
        }
    }
}
