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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace rpm
{
   
    public partial class addtrener : Window
    {
        byte[] photo = null;
        public addtrener()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    autorization autorization = new autorization();
        //    autorization.Show();
        //    this.Close();
        //}

        private void Photo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if ((bool)openFileDialog.ShowDialog())
            {
                try
                {
                    this.photo = File.ReadAllBytes(openFileDialog.FileName);
                    Photo.Text = "Успешно загружено";
                }
                catch
                {
                    Photo.Text = "Ошибка";
                }
            }
        }

        private void AddButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (PROEKTEntities6 db = new PROEKTEntities6())
                {
                    if (Surname.Text.Trim() != "" && FirstName.Text.Trim() != "" && Patronymic.Text.Trim() != "" && Photo != null && PhoneNumber.Text.Trim() != "" && int.Parse(IdDirection.Text.Trim()) != null)
                    {
                        try
                        {
                            Treners treners = new Treners()
                            {
                                Surname = Surname.Text,
                                FirstName = FirstName.Text,
                                Patronymic = Patronymic.Text,
                                Photo = photo,
                                PhoneNumber = PhoneNumber.Text,
                                IdDirection = int.Parse(IdDirection.Text)
                            };
                            db.Treners.Add(treners);                            
                            db.SaveChanges();
                            MessageBox.Show("Успешно добавлено");


                            Treners2 treners2 = new Treners2();
                            treners2.Show();
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
