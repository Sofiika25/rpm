using Microsoft.Win32;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace rpm
{
    /// <summary>
    /// Логика взаимодействия для EditTrener.xaml
    /// </summary>
    public partial class EditTrener : Window
    {
        Treners treners;
        byte[] photo = null;
        public EditTrener(Treners treners)
        {
            InitializeComponent();
            this.treners = treners;
            Surname.Text = treners.Surname;
            FirstName.Text = treners.FirstName;
            Patronymic.Text = treners.Patronymic;
            PhoneNumber.Text = treners.PhoneNumber;
            IdDirection.Text = treners.IdDirection.ToString();
            photo = treners.Photo;
            this.WindowState = WindowState.Maximized;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            //if (Photo.Text == "Успешно загружено")
            //{
                if (FirstName.Text.Trim() != "" && Surname.Text.Trim() != "" && Patronymic.Text.Trim() != "" && PhoneNumber.Text.Trim() != "" && IdDirection.Text.Trim() != "")
                {
                    using (PROEKTEntities6 db = new PROEKTEntities6())
                    {
                        try
                        {
                            Treners f = null;
                            foreach (var en in db.Treners)
                            {
                                if (en.Id_Trener == this.treners.Id_Trener)
                                {
                                    f = db.Treners.Find(en.Id_Trener);
                                    break;
                                }
                            }
                            f.FirstName = FirstName.Text;
                            f.Surname = Surname.Text;
                            f.Patronymic = Patronymic.Text;
                            f.PhoneNumber = PhoneNumber.Text;
                            //f.Photo = photo;
                            db.SaveChanges();
                            System.Windows.MessageBox.Show("Сохранено");
                        Aboutrener aboutrener = new Aboutrener(treners);
                        aboutrener.Show();
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
            
            
            //}

        }
        //private void Photo_Click(object sender, RoutedEventArgs e)
        //{
        //    Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        //    openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
        //    if ((bool)openFileDialog.ShowDialog())
        //    {
        //        try
        //        {
        //            this.photo = File.ReadAllBytes(openFileDialog.FileName);
        //            Photo.Text = "Успешно загружено";
        //        }
        //        catch
        //        {
        //            Photo.Text = "Ошибка";
        //        }
        //    }
        //}
        private void DelButton_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = (MessageBoxResult)System.Windows.MessageBox.Show("Вы точно хотите удалить этого тренера?", "Уведомление", (MessageBoxButton)(MessageBoxButtons)MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                using (PROEKTEntities6 db = new PROEKTEntities6())
                {
                    Treners f = null;
                    foreach (var en in db.Treners)
                    {
                        if (en.Id_Trener == this.treners.Id_Trener)
                        {
                            f = db.Treners.Find(en.Id_Trener);
                            break;
                        }
                    }

                    db.Treners.Remove(f);
                    db.SaveChanges();
                    System.Windows.MessageBox.Show("Успешно удалено");

                    //Aboutrener aboutrener = new Aboutrener(treners);
                    //aboutrener.Close();
                    Treners2 treners2 = new Treners2();
                    treners2.Show();
                    this.Close();
                }
            }
        }
    }
}
