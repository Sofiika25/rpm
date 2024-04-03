using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;

namespace rpm
{
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
           
            System.Windows.MessageBoxButton btn = System.Windows.MessageBoxButton.OK;
            System.Windows.MessageBoxImage ico = System.Windows.MessageBoxImage.Information;
            string caption = "Дата сохранения";
            if (string.IsNullOrWhiteSpace(Surname.Text) || string.IsNullOrWhiteSpace(FirstName.Text) || 
                string.IsNullOrWhiteSpace(Patronymic.Text) || string.IsNullOrWhiteSpace(PhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(IdDirection.Text))
            {
                System.Windows.MessageBox.Show("Все поля обязательны для ввода.");
                FirstName.Text = "";
                Surname.Text = "";
                Patronymic.Text = "";
                PhoneNumber.Text = "";
                IdDirection.Text = "";
                return;
            }
            if (!Regex.IsMatch(FirstName.Text, "^[А-Яа-яA-Za-z]{5,20}$"))
            {
                System.Windows.MessageBox.Show("Пожалуйста,введите имя повторно!", caption, btn, ico);
                FirstName.Text = "";
                return;
            }

            if (!Regex.IsMatch(Surname.Text, "^[А-Яа-яA-Za-z]{5,20}$"))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите фамилию правильно!", caption, btn, ico);
                Surname.Text = "";
                return;
            }

            if (!Regex.IsMatch(Patronymic.Text, "^[А-Яа-яA-Za-z]{5,20}$"))
            {
                System.Windows.MessageBox.Show("Пожалуйста,введите отчество повторно!", caption, btn, ico);
                Patronymic.Text = "";
                return;
            }

            if (!Regex.IsMatch(PhoneNumber.Text, @"^\d{11}$"))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите телефон правильно!", caption, btn, ico);
                PhoneNumber.Text = "";
                return;
            }
            if (!Regex.IsMatch(IdDirection.Text, @"^\d{1,5}$"))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите направление правильно!", caption, btn, ico);
                IdDirection.Text = "";
                return;
            }

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
                    db.SaveChanges();
                    System.Windows.MessageBox.Show("Сохранено");

                    Treners2 treners2 = new Treners2();
                    treners2.Show();
                    this.Close();
                }
                catch
                {
                    System.Windows.MessageBox.Show("Возникла ошибка");
                }
            }
        }
       
        private void DelButton_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = (MessageBoxResult)System.Windows.MessageBox.Show("Вы точно хотите удалить этого тренера?",
                "Уведомление", (MessageBoxButton)(MessageBoxButtons)MessageBoxButton.YesNo);
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
                    Treners2 treners2 = new Treners2();
                    treners2.Show();
                    this.Close();
                }
            }
        }
    }
}
