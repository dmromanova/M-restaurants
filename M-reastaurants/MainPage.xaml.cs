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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M_reastaurants
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        List<Restaurant> _newrestaurant = new List<Restaurant>();

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
        private void RefreshWindow()
        {
            textBoxName.Text = "";
            textBoxLocation.Text = "";
            textBoxType.Text = "";
            comboBoxService.Text = "";
            comboBoxPrice.Text = "";
            comboBoxDecor.Text = "";

        }

        private void buttonAll_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 360;
            da.Duration = new Duration(TimeSpan.FromSeconds(2));          
            RotateTransform rt = new RotateTransform();
            buttonAll.RenderTransform = rt;
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
            LoadData();
            dataGrid.ItemsSource = _newrestaurant;
        }

        private void buttonRef_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 360;
            da.Duration = new Duration(TimeSpan.FromSeconds(2));
            RotateTransform rt = new RotateTransform();
            buttonRef.RenderTransform = rt;
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
            RefreshWindow();
            dataGrid.ItemsSource = null;
        }

        private void buttonRed_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            NavigationService.Navigate(Pages.EditingPage);
            dataGrid.ItemsSource = _newrestaurant;
            return;
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.DeletePage);
            return;
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 360;
            da.Duration = new Duration(TimeSpan.FromSeconds(2));
            RotateTransform rt = new RotateTransform();
            buttonSearch.RenderTransform = rt;
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
            if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text == "" && comboBoxDecor.Text == "" && textBoxType.Text == "" && textBoxLocation.Text == "")
            {
                MessageBox.Show("Укажите параметры поиска");
            }
            if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text == "" && comboBoxDecor.Text != "" && textBoxType.Text == "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text))
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text == "" && comboBoxDecor.Text == "" && textBoxType.Text == "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Price == comboBoxPrice.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text != "" && comboBoxDecor.Text == "" && textBoxType.Text == "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Service == int.Parse(comboBoxService.Text))
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text == "" && comboBoxDecor.Text == "" && textBoxType.Text != "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.FoodType == textBoxType.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text == "" && comboBoxDecor.Text == "" && textBoxType.Text == "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text != "" && comboBoxPrice.Text == "" && comboBoxService.Text == "" && comboBoxDecor.Text == "" && textBoxType.Text == "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Name == textBoxName.Text)
                    {
                        _restaurant.Add(rs);
                    }
                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text != "" && comboBoxDecor.Text != "" && textBoxType.Text == "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Service == int.Parse(comboBoxService.Text))
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text == "" && comboBoxDecor.Text != "" && textBoxType.Text == "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Price == comboBoxPrice.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text == "" && comboBoxDecor.Text != "" && textBoxType.Text == "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text == "" && comboBoxDecor.Text != "" && textBoxType.Text != "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.FoodType == textBoxType.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text != "" && comboBoxDecor.Text == "" && textBoxType.Text == "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Service == int.Parse(comboBoxService.Text) && rs.Price == comboBoxPrice.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text != "" && comboBoxDecor.Text == "" && textBoxType.Text == "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Service == int.Parse(comboBoxService.Text) && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text != "" && comboBoxDecor.Text == "" && textBoxType.Text != "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Service == int.Parse(comboBoxService.Text) && rs.FoodType == textBoxType.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text == "" && comboBoxDecor.Text == "" && textBoxType.Text == "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Price == comboBoxPrice.Text && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text == "" && comboBoxDecor.Text == "" && textBoxType.Text != "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Price == comboBoxPrice.Text && rs.FoodType == textBoxType.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text == "" && comboBoxDecor.Text == "" && textBoxType.Text != "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Location == textBoxLocation.Text && rs.FoodType == textBoxType.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text != "" && comboBoxDecor.Text != "" && textBoxType.Text == "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Service == int.Parse(comboBoxService.Text) && rs.Price == comboBoxPrice.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text != "" && comboBoxDecor.Text != "" && textBoxType.Text == "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Service == int.Parse(comboBoxService.Text) && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text != "" && comboBoxDecor.Text != "" && textBoxType.Text != "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Service == int.Parse(comboBoxService.Text) && rs.FoodType == textBoxType.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text == "" && comboBoxDecor.Text != "" && textBoxType.Text != "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Price == comboBoxPrice.Text && rs.FoodType == textBoxType.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text == "" && comboBoxDecor.Text != "" && textBoxType.Text == "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Price == comboBoxPrice.Text && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text == "" && comboBoxDecor.Text != "" && textBoxType.Text != "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.FoodType == textBoxType.Text && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text != "" && comboBoxDecor.Text == "" && textBoxType.Text != "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Service == int.Parse(comboBoxService.Text) && rs.FoodType == textBoxType.Text && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text == "" && comboBoxDecor.Text == "" && textBoxType.Text != "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Price == comboBoxPrice.Text && rs.FoodType == textBoxType.Text && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text != "" && comboBoxDecor.Text == "" && textBoxType.Text != "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Service == int.Parse(comboBoxService.Text) && rs.FoodType == textBoxType.Text && rs.Price == comboBoxPrice.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text != "" && comboBoxDecor.Text == "" && textBoxType.Text == "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Service == int.Parse(comboBoxService.Text) && rs.Price == comboBoxPrice.Text && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text != "" && comboBoxDecor.Text != "" && textBoxType.Text == "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Service == int.Parse(comboBoxService.Text) && rs.Price == comboBoxPrice.Text && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text != "" && comboBoxDecor.Text != "" && textBoxType.Text != "" && textBoxLocation.Text == "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Service == int.Parse(comboBoxService.Text) && rs.Price == comboBoxPrice.Text && rs.FoodType == textBoxType.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text == "" && comboBoxService.Text != "" && comboBoxDecor.Text != "" && textBoxType.Text != "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Service == int.Parse(comboBoxService.Text) && rs.FoodType == textBoxType.Text && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text == "" && comboBoxDecor.Text != "" && textBoxType.Text != "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.FoodType == textBoxType.Text && rs.Price == comboBoxPrice.Text && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text != "" && comboBoxDecor.Text == "" && textBoxType.Text != "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.FoodType == textBoxType.Text && rs.Service == int.Parse(comboBoxService.Text) && rs.Price == comboBoxPrice.Text && rs.Location == textBoxLocation.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text == "" && comboBoxPrice.Text != "" && comboBoxService.Text != "" && comboBoxDecor.Text != "" && textBoxType.Text != "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Service == int.Parse(comboBoxService.Text) && rs.Price == comboBoxPrice.Text && rs.Location == textBoxLocation.Text && rs.FoodType == textBoxType.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            else if (textBoxName.Text != "" && comboBoxPrice.Text != "" && comboBoxService.Text != "" && comboBoxDecor.Text != "" && textBoxType.Text != "" && textBoxLocation.Text != "")
            {
                List<Restaurant> _restaurant = new List<Restaurant>();
                LoadData();
                foreach (var rs in _newrestaurant)
                {
                    if (rs.Name == textBoxName.Text && rs.Decor == int.Parse(comboBoxDecor.Text) && rs.Service == int.Parse(comboBoxService.Text) && rs.Price == comboBoxPrice.Text && rs.Location == textBoxLocation.Text && rs.FoodType == textBoxType.Text)
                    {
                        _restaurant.Add(rs);
                    }

                }
                dataGrid.ItemsSource = _restaurant;
            }
            RefreshWindow();

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 360;
            da.Duration = new Duration(TimeSpan.FromSeconds(2));
            RotateTransform rt = new RotateTransform();
            buttonAdd.RenderTransform = rt;
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
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
            LoadData();
            foreach (Restaurant i in _newrestaurant)
                if (textBoxName.Text == i.Name)
                {
                    MessageBox.Show("Ресторан с таким названием уже внесен в базу");
                    RefreshWindow();
                    textBoxName.Focus();
                    return;
                }

            Restaurant rest = new Restaurant(textBoxName.Text,
             int.Parse(comboBoxDecor.Text),
            int.Parse(comboBoxService.Text),
            comboBoxPrice.Text,
             textBoxLocation.Text,
             textBoxType.Text);
            _newrestaurant.Add(rest);
            SaveData();
            RefreshWindow();
            dataGrid.ItemsSource = _newrestaurant;

        }

        private void buttinExit_Click(object sender, RoutedEventArgs e)
        {
            LoginPage log = new LoginPage();
            NavigationService.Navigate(log);
        }
    }
}
