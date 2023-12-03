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

namespace rpm
{
    /// <summary>
    /// Логика взаимодействия для Left.xaml
    /// </summary>
    public partial class Left : UserControl
    {
        public Left()
        {
            InitializeComponent();
        }
        private void CloseWindow()
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            client.Show();
            this.CloseWindow();
        }
        private void TrenerButton_Click(object sender, RoutedEventArgs e)
        {
            Treners treners = new Treners();
            treners.Show();
            this.CloseWindow();
        }

        private void RaspisanieButton_Click(object sender, RoutedEventArgs e)
        {
            raspisanie raspisanie = new raspisanie();
            raspisanie.Show();
            this.CloseWindow();
        }
    }
}
