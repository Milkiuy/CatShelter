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
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
