using Microsoft.OData.Edm;
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
using Xceed.Wpf.Toolkit;

namespace rpm
{
  
    public partial class AddClass : Window
    {
        private string selectedTime;
        private string selectedType;
        public AddClass()
        {
            InitializeComponent();
            //this.WindowState = WindowState.Maximized;
        }
        private void timeTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            selectedTime = selectedItem.Content.ToString();
        }
        //private void Add_Click(object sender, RoutedEventArgs e)
        ////{
        //    try
        //    {
        //        using (PROEKTEntities6 db = new PROEKTEntities6())
        //        {
        //            if (DateClass.SelectedDate != null && !string.IsNullOrEmpty(TimePicker.Text) && Type.Text.Trim() != "" && int.Parse(IdDirection.Text.Trim()) != null)
        //            {
        //                try
        //                {
        //                    Schedule schedule = new Schedule()
        //                    {
        //                        DateClass = (DateTime)DateClass.SelectedDate,
        //                        TimeClass = TimeSpan.ParseExact(TimePicker.Text, "HH:mm:ss", null),
        //                        Type = Type.SelectedItem.ToString(),
        //                        IdDirection = int.Parse(IdDirection.Text)
        //                    };

        //                    db.Schedule.Add(schedule);
        //                    db.SaveChanges();
        //                    System.Windows.MessageBox.Show("Успешно добавлено");

        //                    Treners2 treners2 = new Treners2();
        //                    treners2.Show();
        //                    this.Close();
        //                }
        //                catch
        //                {
        //                    System.Windows.MessageBox.Show("Неверно введены данные");
        //                }
        //            }
        //            else
        //                System.Windows.MessageBox.Show("Не все поля заполнены");
        //        }
        //    }
        //    catch
        //    {
        //        System.Windows.MessageBox.Show("Не все поля заполнены");
        //    }
        //    try
        //    {
        //        using (PROEKTEntities6 db = new PROEKTEntities6())
        //        {
        //            if (DateClass.SelectedDate != null && Type.Text.Trim() != "" && int.Parse(IdDirection.Text.Trim()) != null)
        //            {
        //                try
        //                {
        //                    Schedule schedule = new Schedule()
        //                    {
        //                        DateClass = (DateTime)DateClass.SelectedDate,
        //                        Type = Type.Text,
        //                        IdDirection = int.Parse(IdDirection.Text)
        //                    };
        //                    db.Schedule.Add(schedule);
        //                    db.SaveChanges();
        //                    System.Windows.MessageBox.Show("Успешно добавлено");


        //                    Treners2 treners2 = new Treners2();
        //                    treners2.Show();
        //                    this.Close();
        //                }
        //                catch
        //                {
        //                    System.Windows.MessageBox.Show("Неверно введены данные");
        //                }
        //            }
        //            else
        //                System.Windows.MessageBox.Show("Не все поля заполнены");
        //        }
        //    }
        //    catch
        //    {
        //        System.Windows.MessageBox.Show("Не все поля заполнены");
        //    }
        //}
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedTypeItem = (ComboBoxItem)typeComboBox.SelectedItem;
            selectedType = selectedTypeItem.Content.ToString();

            try
            {
                using (PROEKTEntities6 db = new PROEKTEntities6())
                {
                    if (DateClass.SelectedDate != null && !string.IsNullOrWhiteSpace(IdDirection.Text))
                    {
                        Schedule schedule = new Schedule()
                        {
                            DateClass = (Date)DateClass.SelectedDate,
                            Type = selectedType,
                            IdDirection = int.Parse(IdDirection.Text),
                            Time = TimeSpan.Parse(selectedTime)
                        };

                        db.Schedule.Add(schedule);
                        db.SaveChanges();

                        System.Windows.MessageBox.Show("Успешно добавлено");

                        
                        this.Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Не все поля заполнены");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при добавлении: {ex.Message}");
            }
        }
    }
    
}
