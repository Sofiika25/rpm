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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace rpm
{
    /// <summary>
    /// Логика взаимодействия для raspisanie.xaml
    /// </summary>
    public partial class raspisanie : Window
    {
       
        public raspisanie()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            NewData();
        }

        //private void LoadData()
        //{
        //    string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=PROEKT;Integrated Security=True";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT DateClass, TimeClass, Type, IdDirection FROM Schedule";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        List<DataItem> dataItems = new List<DataItem>();
        //        while (reader.Read())
        //        {
        //            DataItem dataItem = new DataItem
        //            {
        //                DateClass = Convert.ToDateTime(reader["DateClass"]),
        //                TimeClass = TimeSpan.Parse(reader["TimeClass"].ToString()),
        //                Type = reader["Type"].ToString(),
        //                IdDirection = Convert.ToInt32(reader["IdDirection"])
        //            };

        //            dataItems.Add(dataItem);
        //        }
        //        reader.Close();
        //        connection.Close();
        //        table.ItemsSource = dataItems;

        //    }
        //}
        private void NewData()
        {
            table.Items.Clear();
            using (var db = new PROEKTEntities6())
            {
                foreach (var f in db.Schedule)
                {
                    table.Items.Add(new Schedule { DateClass = f.DateClass, Time = f.Time, Type = f.Type, IdDirection = f.IdDirection });

                }
            }
            //table.Items.Clear();
            //using (var db = new PROEKTEntities6())
            //{
            //    var scheduleData = from s in db.Schedule join d in db.Direction on s.IdDirection equals d.Id_Dir select new Schedule
            //                       {
            //                           DateClass = s.DateClass,
            //                           Time = s.Time,
            //                           Type = s.Type,
            //                           DirectionName = d.NameDir
            //                       };

            //    foreach (var scheduleItem in scheduleData)
            //    {
            //        table.Items.Add(scheduleItem);
            //    }
            //}
            //using (var db = new PROEKTEntities6())
            //{
            //    foreach (var f in db.Schedule)
            //    {
            //        // Загрузка объекта направления
            //        var direction = db.Direction.FirstOrDefault(d => d.Id_Dir == f.IdDirection);

            //        // Создание нового объекта Schedule с использованием наименования направления
            //        var scheduleItem = new Schedule
            //        {
            //            DateClass = f.DateClass,
            //            Time = f.Time,
            //            Type = f.Type,
            //            IdDirection = direction?.NameDir // Проверка на null для избежания ошибок
            //        };

            //        table.Items.Add(scheduleItem);
            //    }
            //}
        }
       


        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddClass addClass = new AddClass();
            addClass.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = (MessageBoxResult)System.Windows.MessageBox.Show("Вы точно хотите удалить это занятие?", "Уведомление", (MessageBoxButton)(MessageBoxButtons)MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                if (table.SelectedItem != null && table.SelectedItem is Schedule selectedSchedule)
                {
                    using (var db = new PROEKTEntities6())
                    {
                        var scheduleToDelete = db.Schedule.FirstOrDefault(s =>
                            s.DateClass == selectedSchedule.DateClass &&
                            s.Time == selectedSchedule.Time &&
                            s.Type == selectedSchedule.Type &&
                            s.IdDirection == selectedSchedule.IdDirection);

                        if (scheduleToDelete != null)
                        {
                            var relatedScheduleClients = db.ScheduleClient.Where(sc => sc.IdClass == scheduleToDelete.Id_Class);
                            db.ScheduleClient.RemoveRange(relatedScheduleClients);
                            db.Schedule.Remove(scheduleToDelete);
                            db.SaveChanges();
                            table.Items.Remove(selectedSchedule);
                        }
                    }

                }
                else
                {
                    System.Windows.MessageBox.Show("Выберите запись для удаления.");
                }
            }
               
        }
    }
}
