using Microsoft.OData.Edm;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace rpm
{
  
    public partial class AddClass : Window
    {
        private string selectedTime;
        private string selectedType;
        public AddClass()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            DateClass.SelectedDate = DateTime.Now.AddDays(1);
            DateClass.DisplayDateStart = DateTime.Now.AddDays(1);

        }
        private void timeTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            selectedTime = selectedItem.Content.ToString();
        }      
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
                        if (!Regex.IsMatch(IdDirection.Text, @"^\d{1,5}$"))
                        {
                            IdDirection.Text = "";
                            return; 
                        }
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
                        System.Windows.MessageBox.Show("ошибка вот тута");
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
