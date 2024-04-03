using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

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
                MessageBoxButton btn = MessageBoxButton.OK;
                MessageBoxImage ico = MessageBoxImage.Information;
                string caption = "Дата сохранения";
                if (string.IsNullOrWhiteSpace(Surname.Text) || string.IsNullOrWhiteSpace(FirstName.Text) 
                    || string.IsNullOrWhiteSpace(Patronymic.Text) || string.IsNullOrWhiteSpace(PhoneNumber.Text) 
                    || string.IsNullOrWhiteSpace(IdDirection.Text))
                {
                    MessageBox.Show("Все поля обязательны для ввода.");
                    FirstName.Text = "";
                    Surname.Text = "";
                    Patronymic.Text = "";
                    PhoneNumber.Text = "";
                    IdDirection.Text = "";
                    return;
                }
                if (!Regex.IsMatch(FirstName.Text, "^[А-Яа-яA-Za-z]{5,20}$"))
                {
                    MessageBox.Show("Пожалуйста,введите имя повторно!", caption, btn, ico);
                    FirstName.Text = "";
                    return;
                }

                if (!Regex.IsMatch(Surname.Text, "^[А-Яа-яA-Za-z]{5,20}$"))
                {
                    MessageBox.Show("Пожалуйста, введите фамилию правильно!", caption, btn, ico);
                    Surname.Text = "";
                    return;
                }
               
                 if (!Regex.IsMatch(Patronymic.Text, "^[А-Яа-яA-Za-z]{5,20}$"))
                {
                    MessageBox.Show("Пожалуйста,введите отчество повторно!", caption, btn, ico);
                    Patronymic.Text = "";
                    return;
                }
                
                if (!Regex.IsMatch(PhoneNumber.Text, @"^\d{11}$"))
                {
                    MessageBox.Show("Пожалуйста, введите телефон правильно!", caption, btn, ico);
                    PhoneNumber.Text = ""; 
                    return;
                }
                
                if (!Regex.IsMatch(IdDirection.Text, @"^\d{1,5}$"))
                {
                    MessageBox.Show("Пожалуйста, введите направление правильно!", caption, btn, ico);
                    IdDirection.Text = ""; 
                    return;
                }
                
              

                using (PROEKTEntities6 db = new PROEKTEntities6())
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
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
    }
}
