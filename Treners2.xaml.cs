using System.Windows;
using System.Windows.Input;

namespace rpm
{
    public partial class Treners2 : Window
    {
        public Treners2()
        {
            InitializeComponent();
            NewData();
            this.WindowState = WindowState.Maximized;
        }
        private void NewData()
        {
            table1.Items.Clear();
            using (var db = new PROEKTEntities6())
            {
                foreach (var f in db.Treners)
                {
                    table1.Items.Add(new Treners { Id_Trener = f.Id_Trener, Photo = f.Photo,
                    Surname = f.Surname, FirstName = f.FirstName, Patronymic = f.Patronymic,
                    PhoneNumber = f.PhoneNumber, IdDirection = f.IdDirection });

                }
            }
        }

        private void table1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Treners path = table1.SelectedItem as Treners;
            if (path != null)
            {
                Aboutrener aboutrener = new Aboutrener(path);
                aboutrener.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addtrener addtrener = new addtrener();
            addtrener.Show();
            this.Close();
        }
    }
}
