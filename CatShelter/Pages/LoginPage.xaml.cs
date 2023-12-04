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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = App.Context.Users.Where(p => p.Login == LoginTxt.Text && p.Password == PassTxt.Password).FirstOrDefault();
            if (currentUser != null)
            {
                App.CurrentUser = currentUser;
                NavigationService.Navigate(new CatsPage());
            }
            else MessageBox.Show("Неправильный логин или пароль");
        }
    }
}
