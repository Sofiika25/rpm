using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using static rpm.raspisanie;

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
            NewData();
        }
        private void NewData()
        {           
            table1.Items.Clear();
            using (var db = new PROEKTEntities4())
            {
                foreach (var f in db.Clients)
                {
                    table1.Items.Add(new Clients { Id_Client = f.Id_Client, Surname = f.Surname, FirstName = f.FirstName, Patronymic = f.Patronymic, PhoneNumber = f.PhoneNumber });
                   
                }               
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            addclient addclient = new addclient(null);
            addclient.Show();
            this.Close();
        }

        private void EditButton_Click_1(object sender, RoutedEventArgs e)
        {

            Editclient editclient = new Editclient(null);
            editclient.Show();

        }

        private void table1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Clients path = table1.SelectedItem as Clients;
            if (path != null)
            {
                Editclient editclient2 = new Editclient(path);
                editclient2.Show();
            }
        }
    }
}