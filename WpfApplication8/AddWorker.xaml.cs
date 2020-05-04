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
    /// Interaction logic for AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        private Database1Entities1 db1 = new Database1Entities1();
        private EmployeeBL ebl = new EmployeeBL();

        public AddWorker()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void TName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Add_1(object sender, RoutedEventArgs e)
        {
            int salary = 0;
            if (tSalary.Text != "")
                try
                {
                    salary = Convert.ToInt32(tSalary.Text);
                }
                catch(Exception)
                {
                    salary = 0;
                }
            bool flag = ebl.CheckChanges(cType.Text, salary, tCity.Text, tStreet.Text, tNumberHouse.Text, cGender.Text, tNumberId.Text, tName.Text, tPhone.Text, cDeleted.Text);
            if (flag == true)
            {
                db1 = ebl.InsertWorker(cType.Text, salary, tCity.Text, tStreet.Text, tNumberHouse.Text, cGender.Text, tNumberId.Text, tName.Text, tPhone.Text, cDeleted.Text, db1);
                this.db1.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: you must fullfill all details/according to requirment!");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
