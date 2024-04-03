using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace rpm
{
    public partial class autorization : Window
    {
        public autorization()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OK;
            MessageBoxImage ico = MessageBoxImage.Information;
            string caption = "Дата сохранения";
            string LoginA = log.Text;
            string PasswordA = pas.Password;

            if (string.IsNullOrWhiteSpace(LoginA) || string.IsNullOrWhiteSpace(PasswordA))
            {
                MessageBox.Show("Все поля обязательны для ввода.");
                LoginA = "";
                PasswordA = ""; 
                return;
            }
            if (!Regex.IsMatch(LoginA, "^[A-za-z]{5,15}$"))
            {
                MessageBox.Show("Пожалуйста,введите логин повторно!", caption, btn, ico);
                LoginA = ""; 
                return;
            }

            if (!Regex.IsMatch(PasswordA, "^(?=.*[a-z])(?=.*\\d)[a-zA-Z\\d]{5,15}$"))
            {
                MessageBox.Show("Пожалуйста, введите пароль правильно!", caption, btn, ico);
                PasswordA = ""; 
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
            using (PROEKTEntities6 db = new PROEKTEntities6())
            {
                var user = db.Admins.FirstOrDefault(u => u.LoginA == login && u.PasswordA == password);

                return user != null;
            }
        }
    }
}
