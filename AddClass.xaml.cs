using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddClass.xaml
    /// </summary>
    public partial class AddClass : Window
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    using (PROEKTEntities4 db = new PROEKTEntities4())
            //    {
            //        if (DateClass.SelectedDate != null && TimeClass.Text.Trim() != "" && Type.Text.Trim() != "" && int.Parse(Direction.Text.Trim()) != null)
            //        {
            //            try
            //            {
            //                Schedule schedule = new Schedule()
            //                {
            //                    DateClass = (DateTime)DateClass.SelectedDate,
            //                    TimeClass = DateTime.ParseExact(TimeClass.Text, "HH:mm:ss"),
            //                    Type = Type.SelectedItem.ToString(),
            //                    Direction = int.Parse(Direction.Text)
            //                };
            //                db.Treners.Add(treners);
            //                db.SaveChanges();
            //                MessageBox.Show("Успешно добавлено");


            //                Treners2 treners2 = new Treners2();
            //                treners2.Show();
            //                this.Close();
            //            }
            //            catch
            //            {
            //                MessageBox.Show("Неверно введены данные");
            //            }
            //        }
            //        else
            //            MessageBox.Show("Не все поля заполнены");
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Не все поля заполнены");
            //}
        }
    }
    
}
