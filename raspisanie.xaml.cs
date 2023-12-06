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
            using (var db = new PROEKTEntities4())
            {
                foreach (var f in db.Schedule)
                {
                    table.Items.Add(new Schedule { DateClass = f.DateClass, TimeClass = f.TimeClass, Type = f.Type, IdDirection = f.IdDirection });

                }
            }
        }
        //public class DataItem
        //{
        //    public Date DateClass { get; set; }
        //    public TimeSpan TimeClass { get; set; }
        //    public string Type { get; set; }
        //    public int IdDirection { get; set; }
        //}


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
