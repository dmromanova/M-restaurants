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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace M_reastaurants
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Restaurant> _newrestaurant = new List<Restaurant>();
        BinaryFormatter formatter; 
        
        private void buttonLog_Click(object sender, RoutedEventArgs e)
        {
            LogWindow logWindow = new LogWindow();
                logWindow.Show();

           
            
        }

             private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "" && comboBoxPrice.Text=="" && comboBoxService.Text=="" && comboBoxDecor.Text!="" && textBoxType.Text=="" && textBoxLocation.Text=="")
            {


                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor==int.Parse(comboBoxDecor.Text))
                    {
                        _restaurant.Add(rs);
                    }
                }
                dataGrid.ItemsSource = _restaurant;
            }
        }

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
        private void SaveData() {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("../../restaurant.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _newrestaurant);
            }
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrWhiteSpace(textBoxName.Text))
             {
                 MessageBox.Show("Необходимо ввести название");
                 textBoxName.Focus();
                 return;
             }

             if (comboBoxDecor.SelectedItem == null)
             {
                 MessageBox.Show("Необходимо оценить декор");
                 comboBoxDecor.Focus();
                 return;
             }

             if (comboBoxService.SelectedItem == null)
             {
                 MessageBox.Show("Необходимо оценить сервис");
                 comboBoxService.Focus();
                 return;
             }

             if (comboBoxPrice.SelectedItem == null)
             {
                 MessageBox.Show("Необходимо выбрать ценовую категорию");
                 comboBoxPrice.Focus();
                 return;
             }

             if (string.IsNullOrWhiteSpace(textBoxLocation.Text))
             {
                 MessageBox.Show("Необходимо указать месторасположение");
                 textBoxLocation.Focus();
                 return;
             }

             if (string.IsNullOrWhiteSpace(textBoxType.Text))
             {
                 MessageBox.Show("Необходимо указать тип кухни");
                 textBoxType.Focus();
                 return;
             }
             /*var restaurant = new Restaurant(textBoxName.Text, int.Parse(comboBoxDecor.Text), int.Parse(comboBoxService.Text), comboBoxPrice.Text, textBlockLocation.Text, textBlockType.Text);
             object[] restaurantarr = new object[6];
             restaurantarr[0] = textBoxName.Text;
             restaurantarr[1] = int.Parse(comboBoxDecor.Text);
             restaurantarr[2] = int.Parse(comboBoxService.Text);
             restaurantarr[3] = comboBoxPrice.Text;
             restaurantarr[4] = textBoxLocation.Text;
             restaurantarr[5] = textBoxType.Text;

             _newrestaurant.Add(restaurant);



             textBoxName.Clear();
             comboBoxDecor.SelectedItem = null;
             comboBoxService.SelectedItem = null;
             comboBoxPrice.SelectedItem = null;
             textBoxLocation.Clear();
             textBoxType.Clear();


             var lines = String.Join(",", restaurantarr);
             string path = "C:/Users/Lenovo/Documents/Visual Studio 2015/Projects/M-reastaurants/M-reastaurants/bin/Debug/restaurants.txt";

             if (!File.Exists(path))
             {
                 File.Create(path).Close();
                 TextWriter tw = new StreamWriter(path);
                 tw.Write(_newrestaurant);
                 tw.Close();
             }
             else if (File.Exists(path))
             {
                 File.AppendAllText(path, lines + Environment.NewLine);
             }

             MessageBox.Show("Ресторан был успешно добавлен");
         }
         catch
         {
             MessageBox.Show("Ошибка чтения из файла");
         }*/

            Restaurant rest = new Restaurant(textBoxName.Text,
             int.Parse(comboBoxDecor.Text),
            int.Parse(comboBoxService.Text),
            comboBoxPrice.Text,
             textBoxLocation.Text,
             textBoxType.Text);
            _newrestaurant.Add(rest);
                SaveData();

            dataGrid.ItemsSource = _newrestaurant;
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow();
            deleteWindow.Show();
        }
    }
}
