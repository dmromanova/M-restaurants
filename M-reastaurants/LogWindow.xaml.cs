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
using System.Runtime.Serialization.Formatters.Binary;

namespace M_reastaurants
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        BinaryFormatter formatter = new BinaryFormatter();
        const string FileName = "password.txt";
        List<Password> _password;


        public LogWindow()
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
            textBoxPas.Text = "";
        }


        private void buttonLog_Click(object sender, RoutedEventArgs e)
        {

            LoadData();

            if (textBoxLog.Text != "" && textBoxPas.Text != "")
            {
                foreach (Password p in _password)
                {

                    if (textBoxLog.Text == p.Login && textBoxPas.Text == p.Psword)
                    {
                        MessageBox.Show("Авторизация прошла успешно");
                        return;
                    }
                    else if (textBoxLog.Text != p.Login && textBoxPas.Text != p.Psword)
                    {
                        MessageBox.Show("Проверьте правильность логина и пароля");
                        RefreshWindow();
                        return;
                    }
                }
            }
            else if (textBoxLog.Text == "" || textBoxPas.Text == "")
            {
                MessageBox.Show("Если вы зарегестрированы, для входа введите логин и пароль");
                RefreshWindow();
                return;
            }
        }



        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            if (textBoxLog.Text == "" || textBoxPas.Text == "")
            {
                MessageBox.Show("Для регистрации введите логин и пароль");
                return;
            }
            else if (textBoxLog.Text != "" && textBoxPas.Text != "")
            {
                //List<Password> _newpassword = new List<Password>();
                foreach (Password p in _password)
                {
                    if (textBoxLog.Text != p.Login && textBoxPas.Text != p.Psword)
                    {

                        Password user = new Password(textBoxLog.Text, textBoxPas.Text);
                        _password.Add(user);
                        RefreshWindow();
                        MessageBox.Show("Регстрация прошла успешно");
                        return;

                    }
                    SaveData();
                }
            }
            else if (textBoxLog.Text != "" && textBoxPas.Text != "")
            {
                foreach (Password p in _password)
                {
                    if ((textBoxLog.Text == p.Login && textBoxPas.Text == p.Psword) || (textBoxLog.Text == p.Login && textBoxPas.Text != p.Psword))
                    {
                        RefreshWindow();
                        MessageBox.Show("Пользователь с таким логином уже существует");
                        return;
                    }
                }
            }
            }
        }
    }

    
