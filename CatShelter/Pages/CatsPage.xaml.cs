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
    /// Логика взаимодействия для CatsPage.xaml
    /// </summary>
    public partial class CatsPage : Page
    {
        public CatsPage()
        {
            InitializeComponent();
            UpdateCats();
            if(App.CurrentUser == null || App.CurrentUser.Role == 2)
                AddBtn.Visibility = Visibility.Hidden;
            CBSort.SelectedIndex = 0;
            CBFilter.SelectedIndex = 0;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditCatPage((sender as Button).DataContext as Cats));
        }

        private void UpdateCats()
        {
            var breeds = App.Context.Breeds.OrderBy(p => p.BreedID).Select(p => p.BreedName).ToList();
            for (int i = 0; i < breeds.Count; i++)
                CBFilter.Items.Add(breeds[i]);

            var cat = App.Context.Cats.ToList();
            cat = cat.Where(p => p.CatName.ToLower().Contains(SearchTxt.Text.ToLower())).ToList();
            
            if(CBSort.SelectedIndex == 1)
                cat = cat.OrderBy(p => p.CatName).ToList();
            else if (CBSort.SelectedIndex == 2)
                cat = cat.OrderByDescending(p => p.CatName).ToList();
            else if (CBSort.SelectedIndex == 3)
                cat = cat.OrderBy(p => p.Age).ToList();
            else if (CBSort.SelectedIndex == 4)
                cat = cat.OrderByDescending(p => p.CatName).ToList();

            for (int i = 0; i < breeds.Count; i++)
            {
                if(i == 0)
                    ListCats.ItemsSource = cat;
                else if(CBFilter.SelectedIndex == i)
                    cat = cat.Where(p => p.Breed == CBFilter.SelectedIndex).ToList();
            }
            ListCats.ItemsSource = cat;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var cat = (sender as Button).DataContext as Cats;
            if(MessageBox.Show($"Вы точно хотите удалить кота по имени {cat.CatName}","Уведомление",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.Context.Cats.Remove(cat);
                App.Context.SaveChanges();
                UpdateCats();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditCatPage(null));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите вернуться?","Уведомление",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCats();
        }

        private void SearchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCats();
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCats();
        }

        private void CBFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCats();
        }

        private void ApplicationBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
