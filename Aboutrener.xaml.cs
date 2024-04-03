using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace rpm
{
    public partial class Aboutrener : Window
    {
        Treners treners;
        public Aboutrener(Treners treners)
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.treners = treners;
            NewData();
        }
        public void NewData()
        {
            using (PROEKTEntities6 db = new PROEKTEntities6())
            {
                foreach (var e in db.Treners)
                {
                    if (e.Id_Trener == treners.Id_Trener)
                    {
                        Surname.Text = e.Surname;
                        FirstName.Text = e.FirstName;
                        Patronymic.Text = e.Patronymic;
                        PhoneNumber.Text = e.PhoneNumber;
                        var direction = db.Direction.FirstOrDefault(d => d.Id_Dir == e.IdDirection);
                        IdDirection.Text = direction?.NameDir;  
                        MemoryStream stream = new MemoryStream(e.Photo);
                        Photo.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                }
            }
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EditTrener editTrener = new EditTrener(treners);
            editTrener.Show();
            this.Close();
        }

    }
}
