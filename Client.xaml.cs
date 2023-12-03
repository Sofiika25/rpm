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

namespace rpm
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        public Client()
        {
            InitializeComponent();
        }
        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новый экземпляр Window2.xaml
            Client client = new Client();

            // Открываем окно Window2
            client.Show();
        }
        //private void AdminButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Создаем новый экземпляр Window2.xaml
        //    Treners window1 = new Treners();

        //    // Открываем окно Window2
        //    window1.Show();
        //}
        //private void MoreButton(object sender, RoutedEventArgs e)
        //{
        //    // Создаем новый экземпляр Window2.xaml
        //    Window2 window2 = new Window2();

        //    // Открываем окно Window2
        //    window2.Show();
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            autorization autorization = new autorization();

            // Открываем окно Window2
            autorization.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            addclient addclient = new addclient();
            addclient.Show();
            this.Close();
        }

        private void TrenerButton_Click_2(object sender, RoutedEventArgs e)
        {
            // Создаем новый экземпляр Window2.xaml
            Treners window1 = new Treners();

            // Открываем окно Window2
            window1.Show();
        }
    }
}