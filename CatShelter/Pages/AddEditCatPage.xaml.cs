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
    /// Логика взаимодействия для AddEditCatPage.xaml
    /// </summary>
    public partial class AddEditCatPage : Page
    {
        Cats cat = new Cats();
        public AddEditCatPage(Cats _cat)
        {
            InitializeComponent();
            if (_cat != null)
                cat = _cat;
            DataContext = cat;
            CBBreed.ItemsSource = App.Context.Breeds.ToList();
            CBCharacter.ItemsSource = App.Context.Characters.ToList();
            CBColor.ItemsSource = App.Context.Colors.ToList();
            CBGender.ItemsSource = App.Context.Genders.ToList();
        }

        private void SelectImageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
