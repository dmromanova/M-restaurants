using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace M_reastaurants
{
    /// <summary>
    /// Interaction logic for DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        public DeletePage()
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
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

            LoadData();

            for (int i = 0; i < _newrestaurant.Count; i++)
            {
                if (textBoxDelete.Text == _newrestaurant[i].Name)
                {

                    _newrestaurant.Remove(_newrestaurant[i]);
                    textBoxDelete.Text = "";
                    SaveData();
                    MessageBox.Show("Ресторан был успешно удален");
                    NavigationService.Navigate(Pages.MainPage);
                    return;
                }

            }
            for (int i = 0; i < _newrestaurant.Count; i++)
            {
                if (textBoxDelete.Text != _newrestaurant[i].Name)
                {
                    textBoxDelete.Text = "";
                    MessageBox.Show("Такого ресторана не существует");
                    return;
                }
            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MainPage mn = new MainPage();
            NavigationService.Navigate(mn);
            return;
            
        }
    }
}
