using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для addclient.xaml
    /// </summary>
    public partial class addclient : Window
    {
        private Clients _currentClients;
        public addclient(Clients selectedClient)
        {
            InitializeComponent();
          
                _currentClients = selectedClient;
            DataContext = _currentClients;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            autorization autorization = new autorization();
            autorization.Show();
            this.Close();
        }

        private void AddButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using(PROEKTEntities4 db = new PROEKTEntities4())
                {
                    if (Surname.Text.Trim() != "" && FirstName.Text.Trim() != "" && Patronymic.Text.Trim() !="" && PhoneNumber.Text.Trim() !="")
                    {
                        try
                        {
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
                        catch
                        {
                            MessageBox.Show("Неверно введены данные");
                        }
                    }
                    else
                        MessageBox.Show("Не все поля заполнены");
                }
            }
            catch
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
