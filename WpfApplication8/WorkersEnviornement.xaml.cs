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
    /// Interaction logic for WorkersEnviornement.xaml
    /// </summary>
    public partial class WorkersEnviornement : Window
    {
        private EmployeeControlerr employeeController = new EmployeeControlerr();
        private Database1Entities1 db1 = new Database1Entities1();
        public WorkersEnviornement()
        {
            InitializeComponent();
            // employeeDataGrid.ItemsSource = employeeController.GetEmployees();

            this.db1.SaveChanges();
            var results = from table1 in db1.employee.AsEnumerable()
                          //join table2 in db1.employee_type.AsEnumerable() on (int)table1.employee_type_id equals (int)table2.Id_Employee_Type
                         // join table3 in db1.Postal_Code_Worker.AsEnumerable() on (int)table1.postal_code_id equals (int)table3.Id_Postal_Code_Worker
                          select new
                          {
                              Employee_Id = (int)table1.Id_Employee,
                              Id_Number = (string)table1.id_number,
                              Name = (string)table1.name,
                              Phone = (string)table1.phone,
                              //Gender = (string)table1.gender,
                              Deleted = (string)table1.deleted,
                              /*employee_type_id = (int)table2.Id_Employee_Type,
                              type = (string)table2.type,
                              salary = (string)table2.salary,
                              postal_code_id = (int)table3.Id_Postal_Code_Worker,
                              city = (string)table3.city,
                              street = (string)table3.street,
                              house_number = (string)table3.house_number*/
                          };
            employeeDataGrid.ItemsSource = results.ToList();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
           /* var results = from table1 in db1.employee.AsEnumerable()
                                 join table2 in db1.employee_type.AsEnumerable() on (int)table1.employee_type_id equals (int)table2.Id_Employee_Type
                                 join table3 in db1.Postal_Code_Worker.AsEnumerable() on (int)table1.postal_code_id equals (int)table3.Id_Postal_Code_Worker
                          select new
                          {
                              Employee_Id = (int)table1.Id_Employee,
                              Id_Number = (string)table1.id_number,
                              Name = (string)table1.name,
                              Phone = (string)table1.phone,
                              Gender = (string)table1.gender,
                              Deleted = (string)table1.deleted,
                               employee_type_id = (int)table2.Id_Employee_Type,
                               type = (string)table2.type,
                               salary = (string)table2.salary,
                               postal_code_id = (int)table3.Id_Postal_Code_Worker,
                               city = (string)table3.city,
                               street = (string)table3.street,
                               house_number = (string)table3.house_number
                          };
            employeeDataGrid.ItemsSource = results.ToList();
            AddWorker aw = new WpfApplication8.AddWorker(employeeDataGrid, db1);
            aw.ShowDialog();
            employeeDataGrid.ItemsSource = results.ToList();*/
        }
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
           /* var results = from table1 in db1.employee.AsEnumerable()
                              //     join table2 in db1.employee_type.AsEnumerable() on (int)table1.employee_type_id equals (int)table2.Id_Employee_Type
                              //    join table3 in db1.Postal_Code_Worker.AsEnumerable() on (int)table1.postal_code_id equals (int)table3.Id_Postal_Code_Worker
                          select new
                          {
                              Employee_Id = (int)table1.Id_Employee,
                              Id_Number = (string)table1.id_number,
                              Name = (string)table1.name,
                              Phone = (string)table1.phone,
                             // Gender = (string)table1.gender,
                              Deleted = (string)table1.deleted,
                              /* employee_type_id = (int)table2.Id_Employee_Type,
                               type = (string)table2.type,
                               salary = (string)table2.salary,
                               postal_code_id = (int)table3.Id_Postal_Code_Worker,
                               city = (string)table3.city,
                               street = (string)table3.street,
                               house_number = (string)table3.house_number
                          };
            employeeDataGrid.ItemsSource = results.ToList();
            DeleteWorker dw = new WpfApplication8.DeleteWorker(db1, employeeDataGrid);
            dw.ShowDialog();
            employeeDataGrid.ItemsSource = results.ToList();*/
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            /*var results = from table1 in db1.employee.AsEnumerable()
                              //     join table2 in db1.employee_type.AsEnumerable() on (int)table1.employee_type_id equals (int)table2.Id_Employee_Type
                              //    join table3 in db1.Postal_Code_Worker.AsEnumerable() on (int)table1.postal_code_id equals (int)table3.Id_Postal_Code_Worker
                          select new
                          {
                              Employee_Id = (int)table1.Id_Employee,
                              Id_Number = (string)table1.id_number,
                              Name = (string)table1.name,
                              Phone = (string)table1.phone,
                              //Gender = (string)table1.gender,
                              Deleted = (string)table1.deleted,
                              /* employee_type_id = (int)table2.Id_Employee_Type,
                               type = (string)table2.type,
                               salary = (string)table2.salary,
                               postal_code_id = (int)table3.Id_Postal_Code_Worker,
                               city = (string)table3.city,
                               street = (string)table3.street,
                               house_number = (string)table3.house_number
                          };
            employeeDataGrid.ItemsSource = results.ToList();
            UpdateEmployeeTable uet = new WpfApplication8.UpdateEmployeeTable(employeeDataGrid, db1);
            uet.ShowDialog();
            employeeDataGrid.ItemsSource = results.ToList();*/
        }

        private void employeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
