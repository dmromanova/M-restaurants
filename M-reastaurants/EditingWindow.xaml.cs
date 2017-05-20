using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M_reastaurants
{
    /// <summary>
    /// Interaction logic for EditingWindow.xaml
    /// </summary>
    public partial class EditingWindow : Window
    {
        public EditingWindow()
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
            
            SaveData();
        }
    }
}
