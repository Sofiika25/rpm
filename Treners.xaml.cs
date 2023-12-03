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
    /// Логика взаимодействия для Treners.xaml
    /// </summary>
    public partial class Treners : Window
    {
        public Treners()
        {
            InitializeComponent();
        }

        private void About_trener(object sender, RoutedEventArgs e)
        {
            Aboutrener aboutrener = new Aboutrener();
            aboutrener.Show();
            this.Close();
        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }
        
        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            client.Show();
            this.Close();
        }
        private void RaspisanieButton_Click(object sender, RoutedEventArgs e)
        {
            raspisanie raspisanie = new raspisanie();
            raspisanie.Show();
            this.Close();
        }

        private void AddtrenerButton_Click(object sender, RoutedEventArgs e)
        {
            addtrener addtrener = new addtrener();
            addtrener.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }
    }
}
