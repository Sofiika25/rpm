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
    /// Логика взаимодействия для Aboutrener.xaml
    /// </summary>
    public partial class Aboutrener : Window
    {
        public Aboutrener()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новый экземпляр Window2.xaml
            Client client = new Client();

            // Открываем окно Window2
            client.Show();
        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новый экземпляр Window2.xaml
            Treners window1 = new Treners();

            // Открываем окно Window2
            window1.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            autorization autorization = new autorization();

            // Открываем окно Window2
            autorization.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
