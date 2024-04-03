using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using static rpm.raspisanie;

namespace rpm
{
    public partial class Client : Window
    {
        public Client()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            NewData();
        }
        private void NewData()
        {           
            table1.Items.Clear();
            using (var db = new PROEKTEntities6())
            {
                foreach (var f in db.Clients)
                {
                    table1.Items.Add(new Clients { Id_Client = f.Id_Client, Surname = f.Surname,
                    FirstName = f.FirstName, Patronymic = f.Patronymic, PhoneNumber = f.PhoneNumber });
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
                this.Close();
            }
        }
        private int _id_Client;
        private string _surname;
        private string _firstName;
        private string _patronymic;
        private string _phoneNumber;

        public int Id_Client
        {
            get { return _id_Client; }
            set
            {
                if (_id_Client != value)
                {
                    _id_Client = value;
                    OnPropertyChanged(nameof(Id_Client));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}