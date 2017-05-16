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
            /*try { 
            using (StreamReader sr1 = new StreamReader(FileName))
            {
                var password = new Password(textBoxLog.Text, textBoxLog.Text);
                object[] pasarr = new object[2];
                pasarr[0] = textBoxLog.Text;
                pasarr[1] = textBoxPas.Text;
                _password.Add(password);

                    if (!File.Exists(FileName))
                    {
                        File.Create(FileName).Close();
                        TextWriter tw = new StreamWriter(FileName);
                        tw.Write(_password);
                        tw.Close();
                    }
                    else if (File.Exists(FileName))
                    {
                        string s;
                        var lines = string.Join(",", pasarr);
                        if ((s = sr1.ReadLine()) != lines)
                        {
                            sr1.Close();
                            File.AppendAllText(FileName, lines + Environment.NewLine);
                            MessageBox.Show("Регистрация прошла успешно");
                        }
                        else if ((s = sr1.ReadLine()) == lines) { sr1.Close(); MessageBox.Show("Пользователь с таким логином уже зарегестрирован"); }

                    }
                    
                }

            }
            catch
            {
                MessageBox.Show("Ошибка чтения из файла");
            }*/
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

            /*
                var password = new Password(textBoxLog.Text, textBoxLog.Text);
                object[] pasarr = new object[2];
                pasarr[0] = textBoxLog.Text;
                pasarr[1] = textBoxPas.Text;
                _password.Add(password);

                string s;
                var lines = string.Join(",", pasarr);

                if (textBoxLog.Text == "" || textBoxPas.Text == "")
                {
                    MessageBox.Show("Для входа введите логин и пароль");
                }
                
                else if ((s = sr2.ReadLine()) == lines)
                {
                    sr2.Close();
                    
                }

                else if((s = sr2.ReadLine()) != lines)
                {
                    sr2.Close();
                    MessageBox.Show("Проверьте правильности логина и пароля");
                    RefreshWindow();
                }*/
            LoadData();
            foreach (Password p in _password)
            {
                if (textBoxLog.Text==p.Login && textBoxPas.Text==p.Psword )
                {
                    MessageBox.Show("Авторизация прошла успешно");
                }
            }
            
            
        }

        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            if (textBoxLog.Text == "" || textBoxPas.Text == "")
            {
                MessageBox.Show("Для регистрации введите логин и пароль");
            }
            else
            { Password user = new Password(textBoxLog.Text, textBoxPas.Text);
                _password.Add(user);        
                    SaveData();
                    RefreshWindow();
                
                
            }
        }
    }
}
