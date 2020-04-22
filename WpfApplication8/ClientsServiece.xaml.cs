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
    /// Interaction logic for ClientsServiece.xaml
    /// </summary>
    public partial class ClientsServiece : Window
    {
        private Database1Entities1 db = new Database1Entities1();
        private clientControllercs c = new clientControllercs();
        private orderController o = new orderController();
        public ClientsServiece()
        {
            InitializeComponent();
            clientsDataGrid.ItemsSource = c.GetClient();
            ordersDataGrid.ItemsSource = o.GetOrder();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
