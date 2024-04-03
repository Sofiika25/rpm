using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;

namespace rpm
{
    public partial class Editclient : Window
    {
        Clients clients;
        public Editclient(Clients clients)
        {
            InitializeComponent();
            this.clients = clients;
            FirstName.Text = clients.FirstName;
            Surname.Text = clients.Surname;
            Patronymic.Text = clients.Patronymic;
            PhoneNumber.Text = clients.PhoneNumber;
            this.WindowState = WindowState.Maximized;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.MessageBoxButton btn = System.Windows.MessageBoxButton.OK;
            System.Windows.MessageBoxImage ico = System.Windows.MessageBoxImage.Information;
            string caption = "Дата сохранения";

            if (string.IsNullOrWhiteSpace(Surname.Text) || string.IsNullOrWhiteSpace(FirstName.Text)
                || string.IsNullOrWhiteSpace(Patronymic.Text) || string.IsNullOrWhiteSpace(PhoneNumber.Text))
            {
                System.Windows.MessageBox.Show("Все поля обязательны для ввода.");
                FirstName.Text = "";
                Surname.Text = "";
                Patronymic.Text = "";
                PhoneNumber.Text = "";
                return;
            }
            if (!Regex.IsMatch(FirstName.Text, "^[А-Яа-яA-Za-z]{5,20}$"))
            {
                System.Windows.MessageBox.Show("Пожалуйста,введите имя повторно!", caption, btn, ico);
                FirstName.Text = "";
                return;
            }

            if (!Regex.IsMatch(Surname.Text, "^[А-Яа-яA-Za-z]{5,20}$"))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите фамилию правильно!", caption, btn, ico);
                Surname.Text = "";
                return;
            }

            if (!Regex.IsMatch(Patronymic.Text, "^[А-Яа-яA-Za-z]{5,20}$"))
            {
                System.Windows.MessageBox.Show("Пожалуйста,введите отчество повторно!", caption, btn, ico);
                Patronymic.Text = "";
                return;
            }

            if (!Regex.IsMatch(PhoneNumber.Text, @"^\d{11}$"))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите телефон правильно!", caption, btn, ico);
                PhoneNumber.Text = "";
                return;
            }

            using (PROEKTEntities6 db = new PROEKTEntities6())
            {
                try
                {
                    Clients f = null;
                    foreach (var en in db.Clients)
                    {
                        if (en.Id_Client == this.clients.Id_Client)
                        {
                            f = db.Clients.Find(en.Id_Client);
                            break;
                        }
                    }
                    f.FirstName = FirstName.Text;
                    f.Surname = Surname.Text;
                    f.Patronymic = Patronymic.Text;
                    f.PhoneNumber = PhoneNumber.Text;
                    db.SaveChanges();
                    System.Windows.MessageBox.Show("Сохранено");

                    Client client = new Client();
                    client.Show();
                    this.Close();
                }
                catch
                {
                    System.Windows.MessageBox.Show("Возникла ошибка");
                }
            }
     
        }

        private void DelButton_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = (MessageBoxResult)System.Windows.MessageBox.Show("Вы точно хотите удалить этого клиента?",
                "Уведомление", (MessageBoxButton)(MessageBoxButtons)MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                using (PROEKTEntities6 db = new PROEKTEntities6())
                {
                    Clients f = null;
                    foreach (var en in db.Clients)
                    {
                        if (en.Id_Client == this.clients.Id_Client)
                        {
                            f = db.Clients.Find(en.Id_Client);
                            break;
                        }
                    }
                    ScheduleClient scheduleClient = null;
                    foreach (var sp in db.ScheduleClient)
                    {
                        if (sp.IdClient == f.Id_Client)
                        {
                            scheduleClient = db.ScheduleClient.Find(sp.IdClient);

                            db.ScheduleClient.Remove(scheduleClient);
                        }
                    }
                    db.Clients.Remove(f);
                    db.SaveChanges();
                    System.Windows.MessageBox.Show("Успешно удалено");
                    Client client = new Client();
                        client.Show();
                    this.Close();
                }
            }
        }
    }
}
