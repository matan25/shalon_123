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
    /// Interaction logic for ConsumersEnviornment.xaml
    /// </summary>
    public partial class ConsumersEnviornment : Window
    {
        public employee emp;
        public ConsumersEnviornment(employee emp)
        {
            InitializeComponent();
            this.emp = emp;
        }

        private void Button_Add_Update_Client(object sender, RoutedEventArgs e)
        {
            AddUpdateConsumer auc = new AddUpdateConsumer();
            auc.ShowDialog();
        }

        private void Button_Consumers_Table(object sender, RoutedEventArgs e)
        {
            ShowClientsTable sct = new WpfApplication8.ShowClientsTable();
            sct.ShowDialog();
        }

        private void Button_Orders_Report(object sender, RoutedEventArgs e)
        {
            ShowOrdersReport sor = new ShowOrdersReport();
            sor.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MakingOrderWindow mow = new MakingOrderWindow(emp);
            mow.ShowDialog();
        }

        private void Button_add_product(object sender, RoutedEventArgs e)
        {
            AddProduct ap = new AddProduct();
            ap.ShowDialog();
        }

        private void Button_Products_Table(object sender, RoutedEventArgs e)
        {
           ShowProductsTable spt = new ShowProductsTable();
            spt.ShowDialog();
        }

        private void Button_Update_Order(object sender, RoutedEventArgs e)
        {
            UpdateOrderTable uot = new UpdateOrderTable(emp);
            uot.ShowDialog();
        }

        private void Button_Update_Product_Table(object sender, RoutedEventArgs e)
        {
            UpdateProductTable upt = new UpdateProductTable();
            upt.ShowDialog();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.ShowDialog();
        }
    }
}
