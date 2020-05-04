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

namespace WpfApplication8
{
    /// <summary>
    /// Interaction logic for EmployeeSystem.xaml
    /// </summary>
    public partial class EmployeeSystem : Window
    {
        private Database1Entities1 db = new Database1Entities1();
        public EmployeeSystem()
        {
            InitializeComponent();
        }

        private void Button_Add_Worker(object sender, RoutedEventArgs e)
        {
            AddWorker aw = new WpfApplication8.AddWorker();
            aw.ShowDialog();
        }

        private void Button_Update_Worker(object sender, RoutedEventArgs e)
        {
            UpdateEmployeeTable uet = new WpfApplication8.UpdateEmployeeTable(db);
            uet.ShowDialog();
        }

        private void Button_Employee_Table(object sender, RoutedEventArgs e)
        {
            ShowEmployeeTable set1 = new WpfApplication8.ShowEmployeeTable();
            set1.ShowDialog();
        }

        private void Button_Employee_Type_Table(object sender, RoutedEventArgs e)
        {
            ShowEmployeeTypeTable set2 = new WpfApplication8.ShowEmployeeTypeTable();
            set2.ShowDialog();

        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new WpfApplication8.MainWindow();
            this.Close();
            mw.ShowDialog();
        }
    }
}