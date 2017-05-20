﻿using System;
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
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
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

                for (int i = 0; i<_newrestaurant.Count; i++)
                {
                    if (textBoxDelete.Text==_newrestaurant[i].Name)
                    {
                        
                        _newrestaurant.Remove(_newrestaurant[i]);
                    textBoxDelete.Text = "";
                        SaveData(); 
                    MessageBox.Show("Ресторан был успешно удален");
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
}
    }

