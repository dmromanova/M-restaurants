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
using System.Windows.Shapes;
using System.IO;

namespace M_reastaurants
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        const string FileName = "password.txt";
        List<Password> _password = new List<Password>();

        public LogWindow()
        {
            InitializeComponent();

            
        }

     

        private void buttonLog_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxLog.Text == "" || textBoxPas.Text == "")
            {
                MessageBox.Show("Для входа введите логин и пароль");
            }

        }

        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxLog.Text == "" || textBoxPas.Text == "")
            {
                MessageBox.Show("Для регистрации введите логин и пароль");
            }
        }
    }
}
