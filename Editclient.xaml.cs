using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace rpm
{
    /// <summary>
    /// Логика взаимодействия для Editclient.xaml
    /// </summary>
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
            if (FirstName.Text.Trim() != "" && Surname.Text.Trim() != "" && Patronymic.Text.Trim() != "" && PhoneNumber.Text.Trim() != "")
            {
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
                        System.Windows.MessageBox.Show("Неверно введены данные");
                    }
                }
            }
            else
                System.Windows.MessageBox.Show("Не все поля заполнены");
        }

        private void DelButton_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = (MessageBoxResult)System.Windows.MessageBox.Show("Вы точно хотите удалить этого клиента?", "Уведомление", (MessageBoxButton)(MessageBoxButtons)MessageBoxButton.YesNo);
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
