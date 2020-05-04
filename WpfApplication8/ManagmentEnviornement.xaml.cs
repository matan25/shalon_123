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
    /// Interaction logic for ManagmentEnviornement.xaml
    /// </summary>
    public partial class ManagmentEnviornement : Window
    {
        employee emp = new employee();
        public ManagmentEnviornement(employee emp)
        {
            this.emp = emp;
            InitializeComponent();
        }

        private void Button_Add_Expense(object sender, RoutedEventArgs e)
        {
            AddExpeneseWindow aew = new AddExpeneseWindow(emp);
            aew.ShowDialog();
        }


        private void Button_Expenses_Table(object sender, RoutedEventArgs e)
        {
            ShowExpensesTable set = new ShowExpensesTable();
            set.ShowDialog();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.ShowDialog();
        }
    }
}
