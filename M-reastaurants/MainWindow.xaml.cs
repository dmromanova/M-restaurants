using System.Windows;


namespace M_reastaurants
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            frameMain.Navigate(new LoginPage());
        }
    }
}
