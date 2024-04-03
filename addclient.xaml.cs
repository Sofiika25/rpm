using System.Text.RegularExpressions;
using System.Windows;

namespace rpm
{
    public partial class addclient : Window
    {
        private Clients _currentClients;
        public addclient(Clients selectedClient)
        {
            InitializeComponent();
          
            _currentClients = selectedClient;
            DataContext = _currentClients;
            this.WindowState = WindowState.Maximized;
        }

        private void AddButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (PROEKTEntities6 db = new PROEKTEntities6())
                {
                    MessageBoxButton btn = MessageBoxButton.OK;
                    MessageBoxImage ico = MessageBoxImage.Information;
                    string caption = "Дата сохранения";
                    if (string.IsNullOrWhiteSpace(Surname.Text) || string.IsNullOrWhiteSpace(FirstName.Text) || string.IsNullOrWhiteSpace(Patronymic.Text) || string.IsNullOrWhiteSpace(PhoneNumber.Text))
                    {
                        MessageBox.Show("Все поля обязательны для ввода.");
                        FirstName.Text = "";
                        Surname.Text = "";
                        Patronymic.Text = "";
                        PhoneNumber.Text = "";
                        return;
                    }
                    if (!Regex.IsMatch(FirstName.Text, "^[А-Яа-яA-Za-z]{2,20}$"))
                    {
                        MessageBox.Show("Пожалуйста,введите имя повторно!", caption, btn, ico);
                        FirstName.Text = "";
                        return;
                    }

                    if (!Regex.IsMatch(Surname.Text, "^[А-Яа-яA-Za-z]{2,20}$"))
                    {
                        MessageBox.Show("Пожалуйста, введите фамилию правильно!", caption, btn, ico);
                        Surname.Text = "";
                        return;
                    }

                    if (!Regex.IsMatch(Patronymic.Text, "^[А-Яа-яA-Za-z]{5,20}$"))
                    {
                        MessageBox.Show("Пожалуйста,введите отчество повторно!", caption, btn, ico);
                        Patronymic.Text = "";
                        return;
                    }

                    if (!Regex.IsMatch(PhoneNumber.Text, @"^\d{11}$"))
                    {
                        MessageBox.Show("Пожалуйста, введите телефон правильно!", caption, btn, ico);
                        PhoneNumber.Text = "";
                        return;
                    }

                    Clients clients = new Clients()
                    {
                        Surname = Surname.Text,
                        FirstName = FirstName.Text,
                        Patronymic = Patronymic.Text,
                        PhoneNumber = PhoneNumber.Text
                    };
                    db.Clients.Add(clients);
                    db.SaveChanges();
                    MessageBox.Show("Успешно добавлено");
                                  
                    Client client = new Client();
                    client.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
    }
}
