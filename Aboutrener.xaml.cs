using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Aboutrener.xaml
    /// </summary>
    public partial class Aboutrener : Window
    {
        Treners treners;
        public Aboutrener(Treners treners)
        {
            InitializeComponent();
            this.treners = treners;
            NewData();
        }
        public void NewData()
        {
            using (PROEKTEntities4 db = new PROEKTEntities4())
            {
                foreach (var e in db.Treners)
                {
                    if (e.Id_Trener == treners.Id_Trener)
                    {
                        Surname.Text = e.Surname;
                        FirstName.Text = e.FirstName;
                        Patronymic.Text = e.Patronymic;
                        PhoneNumber.Text = e.PhoneNumber;
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
            
        }

    }
}
