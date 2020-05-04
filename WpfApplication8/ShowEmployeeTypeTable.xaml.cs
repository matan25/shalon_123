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
    /// Interaction logic for ShowEmployeeTypeTable.xaml
    /// </summary>
    public partial class ShowEmployeeTypeTable : Window
    {
        Database1Entities1 db1 = new Database1Entities1();
        public ShowEmployeeTypeTable()
        {
            InitializeComponent();
            var results = from table1 in db1.employee.AsEnumerable()
                          join table2 in db1.employee_type.AsEnumerable() on (int)table1.employee_type_id equals (int)table2.Id_Employee_Type
                          join table3 in db1.Postal_Code_Worker.AsEnumerable() on (int)table1.postal_code_id equals (int)table3.Id_Postal_Code_Worker
                          select new
                          {
                              Employee_Id = (int)table1.Id_Employee,
                              Id_Number = (string)table1.id_number,
                              Name = (string)table1.name,
                              //  employee_type_id = (int)table2.Id_Employee_Type,
                              type = (string)table2.type,
                              salary = (int)table2.salary
                          };
            EmployeeTypeDataGrid.ItemsSource = results.ToList();
        }
    }
}
