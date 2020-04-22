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
        private EmployeeControlerr ec = new EmployeeControlerr();

        public AddWorker()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* employee_type et = db1.employee_type.Add(new employee_type { type = tType.Text, salary = tSalary.Text });
               Postal_Code_Worker pc = db1.Postal_Code_Worker.Add(new Postal_Code_Worker { city = tCity.Text, street = tStreet.Text, house_number = tNumberHouse.Text });
               Workers_Gender wg = db1.Workers_Gender.Add(new Workers_Gender { Gender = cGender.Text });
               db1.employee.Add(new employee { id_number = tNumberID.Text, name = tName_Copy.Text, phone = tPhone.Text, deleted = cDeleted.Text, employee_type = et , Postal_Code_Worker = pc }); */
            db1 = ec.InsertWorker(tType.Text, tSalary.Text, tCity.Text, tStreet.Text, tNumberHouse.Text, cGender.Text, tNumberID.Text, tName_Copy.Text, tPhone.Text, cDeleted.Text, db1);
            var results = from table1 in db1.employee.AsEnumerable()
                          join table2 in db1.Workers_Gender.AsEnumerable() on (int)table1.Gender_Id equals (int)table2.Id_Worker_Gender
                          join table3 in db1.Postal_Code_Worker.AsEnumerable() on (int)table1.postal_code_id equals (int)table3.Id_Postal_Code_Worker
                          select new
                          {
                              Employee_Id = (int)table1.Id_Employee,
                              Id_Number = (string)table1.id_number,
                              Name = (string)table1.name,
                              Phone = (string)table1.phone,
                              Deleted = (string)table1.deleted,
                              Status = (string)table2.Gender,
                              /*employee_type_id = (int)table2.Id_Employee_Type,
                              type = (string)table2.type,
                              salary = (string)table2.salary,*/
                              //postal_code_id = (int)table3.Id_Postal_Code_Worker,
                              City = (string)table3.city,
                              Street = (string)table3.street,
                              House_Number = (string)table3.house_number
                          };

            this.db1.SaveChanges();
            // employeeDataGrid.ItemsSource = results.ToList();
            //es.ShowDialog();
            this.Close();
        }

        private void TName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
