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
    /// Логика взаимодействия для autorization.xaml
    /// </summary>
    public partial class autorization : Window
    {
        public autorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string LoginA = log.Text;
            string PasswordA = pas.Password;
            if (string.IsNullOrWhiteSpace(LoginA) || string.IsNullOrWhiteSpace(PasswordA))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }
            bool isAuthenticated = AuthenticateUser(LoginA, PasswordA);

            if (isAuthenticated)
            {
                MessageBox.Show("Вход успешен!");
                Treners2 treners2 = new Treners2();
                treners2.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Неверные логин или пароль.");
            }
        }
        private bool AuthenticateUser(string login, string password)
        {
            using (PROEKTEntities4 db = new PROEKTEntities4())
            {
                var user = db.Admins.FirstOrDefault(u => u.LoginA == login && u.PasswordA == password);

                return user != null;
            }
        }
    }
}
