using CatShelter.Entities;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatShelter.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditCatPage.xaml
    /// </summary>
    public partial class AddEditCatPage : Page
    {
        byte[] image = null;
        Cats cat = new Cats();
        public AddEditCatPage(Cats _cat)
        {
            InitializeComponent();
            if (_cat != null)
            {
                cat = _cat;
                Title = "Редактирование кота";
            }
            DataContext = cat;
            CBBreed.ItemsSource = App.Context.Breeds.ToList();
            CBCharacter.ItemsSource = App.Context.Characters.ToList();
            CBColor.ItemsSource = App.Context.Colors.ToList();
            CBGender.ItemsSource = App.Context.Genders.ToList();
        }

        private void SelectImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image | *.png; *.jpg; *.jpeg";
            ofd.Multiselect = false;
            if(ofd.ShowDialog() == true)
            {
                image = File.ReadAllBytes(ofd.FileName);
                ImageService.Source = new ImageSourceConverter().ConvertFrom(image) as ImageSource;
                cat.Image = image;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errorBuilder = new StringBuilder();
            if (String.IsNullOrEmpty(cat.CatName))
                errorBuilder.AppendLine("Введите имя");
            if(String.IsNullOrEmpty(cat.Age.ToString()))
                errorBuilder.AppendLine("Введите возраст");
            if (cat.CatID == 0)
                App.Context.Cats.Add(cat);
            try
            {
                App.Context.SaveChanges();
                MessageBox.Show("Информация сохранена", "Увдеомление", MessageBoxButton.OK,MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
