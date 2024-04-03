using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace rpm
{
    public partial class raspisanie : Window
    {
        public raspisanie()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            NewData();
        }

        private void NewData()
        {
            table.Items.Clear();
            using (var db = new PROEKTEntities6())
            {
                foreach (var f in db.Schedule)
                {
                    table.Items.Add(new Schedule { DateClass = f.DateClass, Time = f.Time, Type = f.Type,
                    IdDirection = f.IdDirection });
                }
            }   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddClass addClass = new AddClass();
            addClass.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = (MessageBoxResult)System.Windows.MessageBox.Show("Вы точно хотите удалить это занятие?",
                "Уведомление", (MessageBoxButton)(MessageBoxButtons)MessageBoxButton.YesNo);
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
