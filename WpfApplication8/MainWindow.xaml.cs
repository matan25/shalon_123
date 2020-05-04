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

namespace WpfApplication8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database1Entities1 db1 = new Database1Entities1();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Employee_System(object sender, RoutedEventArgs e)
        {
            EmployeeSystem es = new WpfApplication8.EmployeeSystem();
            this.Close();
            es.ShowDialog();
        }

        private void Button_Consumer_Serviece(object sender, RoutedEventArgs e)
        {
            ConsumersSystem cs = new ConsumersSystem();
            this.Close();
            cs.ShowDialog();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Managment(object sender, RoutedEventArgs e)
        {
            ManagmentSystem ms = new ManagmentSystem();
            this.Close();
            ms.ShowDialog();
        }
    }
}
