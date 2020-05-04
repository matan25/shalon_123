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

namespace WpfApplication8
{
    /// <summary>
    /// Interaction logic for ConsumersSystem.xaml
    /// </summary>
    public partial class ConsumersSystem : Window
    {
        Database1Entities1 db = new Database1Entities1();
        public ConsumersSystem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<employee> lst = db.employee.ToList();
            foreach (employee emp in lst)
            {
                if (emp.id_number == input.Text)
                {
                    if (emp.deleted == "Active")
                    {
                        ConsumersEnviornment ce = new WpfApplication8.ConsumersEnviornment(emp);
                        this.Close();
                        ce.ShowDialog();
                        return;
                    }
                }
            }
            MessageBox.Show("Error: Not existed employee or not active!");
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.ShowDialog();
        }
    }
}
