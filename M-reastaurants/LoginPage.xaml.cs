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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M_reastaurants
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        BinaryFormatter formatter = new BinaryFormatter();
        const string FileName = "password.txt";
        List<Password> _password;


        public LoginPage()
        {
            InitializeComponent();

        }

        private void SaveData()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("../../password.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _password);
            }
        }

        private void LoadData()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("../../password.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    _password = (List<Password>)formatter.Deserialize(fs);
                }
                catch
                {
                    _password = new List<Password>();
                }
            }
        }
        private void RefreshWindow()
        {
            textBoxLog.Text = "";
            passwordBoxPas.Password = "";
        }


        private void buttonLog_Click(object sender, RoutedEventArgs e)
        {

            LoadData();
            List<Password> lp = new List<Password>();
            if (textBoxLog.Text == "" || passwordBoxPas.Password == "")
            {
                MessageBox.Show("Для входа введите логин и пароль");
                return;
            }
            if (textBoxLog.Text != "" && passwordBoxPas.Password != "")
            {
                foreach (Password p in _password)
                {

                    if (textBoxLog.Text == p.Login && passwordBoxPas.Password == p.Psword)
                    {
                        lp.Add(p);
                        NavigationService.Navigate(Pages.MainPage);
                        return;
                    }
                }         
                            
            
                if (lp.Count == 0)
                {
                    MessageBox.Show("Проверьте правильность логина и пароля");
                    RefreshWindow();
                    return;
                }
            }
        }



        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            if (textBoxLog.Text == "" || passwordBoxPas.Password == "")
            {
                MessageBox.Show("Для регистрации введите логин и пароль");
                return;
            }
            
            if ( textBoxLog.Text.Trim() == "" || passwordBoxPas.Password.Trim() == "")
            {
                MessageBox.Show("Убедитесь, что у вас нет пробелов в Логине и Пароле");
                return;
            }

            if (textBoxLog.Text != "" && passwordBoxPas.Password != "")
            {
                foreach (Password p in _password)
                {
                    if (textBoxLog.Text == p.Login)
                    {
                        RefreshWindow();
                        MessageBox.Show("Пользователь с таким логином уже существует");
                        return;
                    }
                }
                    
                        Password user = new Password(textBoxLog.Text, passwordBoxPas.Password);
                        _password.Add(user);
                        RefreshWindow();
                        MessageBox.Show("Регстрация прошла успешно");
                        SaveData();
                        NavigationService.Navigate(Pages.MainPage);
                        return;
                    

                }
            }     

       
    }
    }

