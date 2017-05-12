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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace M_reastaurants
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void buttonLog_Click(object sender, RoutedEventArgs e)
        {
            LogWindow logWindow = new LogWindow();
                logWindow.Show();
        }

             private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            

            SearchWindow searchWindow = new SearchWindow();
            searchWindow.Show();
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
        }
    }
}
