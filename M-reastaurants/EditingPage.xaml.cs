using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace M_reastaurants
{
    /// <summary>
    /// Interaction logic for EditingPage.xaml
    /// </summary>
    public partial class EditingPage : Page
    {
        public EditingPage()
        {
            InitializeComponent();
        }
        List<Restaurant> _newrestaurant;
        private void LoadData()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("../../restaurant.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    _newrestaurant = (List<Restaurant>)formatter.Deserialize(fs);
                }
                catch
                {
                    _newrestaurant = new List<Restaurant>();
                }
            }
        }

        private void SaveData()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("../../restaurant.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _newrestaurant);
            }
        }
        private void buttonEd_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            for (int i = 0; i < _newrestaurant.Count; i++)
            {
                if (textBoxEd.Text == _newrestaurant[i].Name)
                {
                    List<Restaurant> _restaurant = new List<Restaurant>();
                    _restaurant.Add(_newrestaurant[i]);
                    dataGrid.ItemsSource = _restaurant;
                    textBoxEd.Text = "";
                    return;
                }

            }
            for (int i = 0; i < _newrestaurant.Count; i++)
            {
                if (textBoxEd.Text != _newrestaurant[i].Name)
                {
                    textBoxEd.Text = "";
                    MessageBox.Show("Такого ресторана не существует");
                    return;
                }
            }

        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < _newrestaurant.Count; i++)
            {                
                if ((_newrestaurant[i].Name != "")==false || (0 <= _newrestaurant[i].Decor && _newrestaurant[i].Decor <= 5)==false || (0 <= _newrestaurant[i].Service && _newrestaurant[i].Service <= 5)==false || (_newrestaurant[i].Location != "")==false || (_newrestaurant[i].FoodType != "")==false ||( _newrestaurant[i].Price != "до 1500 р." || _newrestaurant[i].Price != "более 5000 р." || _newrestaurant[i].Price != "от 1500 до 3500 р.") == false)
                {
                    MessageBox.Show("Проверьте корректность изменений");
                    return;
                }
            }
            SaveData();
            dataGrid.ItemsSource = null;
            MainPage mn = new MainPage();
            NavigationService.Navigate(mn);
            return;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
