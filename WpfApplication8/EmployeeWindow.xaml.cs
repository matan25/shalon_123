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
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        private EmployeeControlerr employeeController = new EmployeeControlerr();
        private Database1Entities1 db1 = new Database1Entities1();
        public EmployeeWindow()
        {
            InitializeComponent();
            employeeDataGrid.ItemsSource = employeeController.GetEmployees();
            this.db1.SaveChanges();
            var results = from table1 in db1.employee.AsEnumerable()
                          join table2 in db1.employee_type.AsEnumerable() on (int)table1.employee_type_id equals (int)table2.Id
                          join table3 in db1.Postal_Code_Worker.AsEnumerable() on (int)table1.postal_code_id equals (int)table3.Id
                          select new
                          {
                              employee_id = (int)table1.Id,
                              id_number = (string)table1.id_number,
                              name = (string)table1.name,
                              phone = (string)table1.phone,
                              gender = (string)table1.gender,
                              deleted = (int)table1.deleted,
                              employee_type_id = (int)table2.Id,
                              type = (string)table2.type,
                              salary = (string)table2.salary,
                              postal_code_id = (int)table3.Id,
                              city = (string)table3.city,
                              street = (string)table3.street,
                              house_number = (string)table3.house_number
                          };
            employeeDataGrid.ItemsSource = results.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWorker aw = new WpfApplication8.AddWorker(employeeDataGrid, db1);
            aw.ShowDialog();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var results = from table1 in db1.employee.AsEnumerable()
                          join table2 in db1.employee_type.AsEnumerable() on (int)table1.employee_type_id equals (int)table2.Id
                          join table3 in db1.Postal_Code_Worker.AsEnumerable() on (int)table1.postal_code_id equals (int)table3.Id
                          select new
                          {
                              employee_id = (int)table1.Id,
                              id_number = (string)table1.id_number,
                              name = (string)table1.name,
                              phone = (string)table1.phone,
                              gender = (string)table1.gender,
                              deleted = (int)table1.deleted,
                              employee_type_id = (int)table2.Id,
                              type = (string)table2.type,
                              salary = (string)table2.salary,
                              postal_code_id = (int)table3.Id,
                              city = (string)table3.city,
                              street = (string)table3.street,
                              house_number = (string)table3.house_number
                          };
            employeeDataGrid.ItemsSource = results.ToList();
            DeleteWorker dw = new WpfApplication8.DeleteWorker(db1, employeeDataGrid);
            dw.ShowDialog();
            employeeDataGrid.ItemsSource = results.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ClientsServiece cs = new WpfApplication8.ClientsServiece();
            cs.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UpdateEmployeeTable ut = new WpfApplication8.UpdateEmployeeTable(employeeDataGrid, db1);
            ut.ShowDialog();
            var results = from table1 in db1.employee.AsEnumerable()
                          join table2 in db1.employee_type.AsEnumerable() on (int)table1.employee_type_id equals (int)table2.Id
                          join table3 in db1.Postal_Code_Worker.AsEnumerable() on (int)table1.postal_code_id equals (int)table3.Id
                          select new
                          {
                              employee_id = (int)table1.Id,
                              id_number = (string)table1.id_number,
                              name = (string)table1.name,
                              phone = (string)table1.phone,
                              gender = (string)table1.gender,
                              deleted = (int)table1.deleted,
                              employee_type_id = (int)table2.Id,
                              type = (string)table2.type,
                              salary = (string)table2.salary,
                              postal_code_id = (int)table3.Id,
                              city = (string)table3.city,
                              street = (string)table3.street,
                              house_number = (string)table3.house_number
                          };
            employeeDataGrid.ItemsSource = results.ToList();
        }
    }
}
