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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rpm
{
    /// <summary>
    /// Логика взаимодействия для Top.xaml
    /// </summary>
    public partial class Top : UserControl
    {
        public Top()
        {
            InitializeComponent();
        }
        private void CloseWindow()
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            autorization autorization = new autorization();

            // Открываем окно Window2
            autorization.Show();
            this.CloseWindow();
        }
    }
}
