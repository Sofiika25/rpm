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
    /// Логика взаимодействия для raspisanie.xaml
    /// </summary>
    public partial class raspisanie : Window
    {
        Admin admin;
        public raspisanie()
        {
            InitializeComponent();
            
        } 
        //public void NewData()
        //{
        //    int n = 0;
        //    table.Items.Clear();
        //    using (var db = new RPM())
        //    {
        //        foreach (var f in db.Расписание)
        //        {
        //            table.Items.Add(new Расписание { IDFac = f.IDFac, Name = f.Name, Description = f.Description });
        //            n++;
        //        }
        //        num.Text = n.ToString();
        //    }
        //}

        
    }
}
