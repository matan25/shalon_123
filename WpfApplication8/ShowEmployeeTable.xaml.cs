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
    /// Interaction logic for ShowEmployeeTable.xaml
    /// </summary>
    public partial class ShowEmployeeTable : Window
    {
        Database1Entities1 db1 = new Database1Entities1();
        public ShowEmployeeTable()
        {
            InitializeComponent();
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
                              Gender = (string)table2.Gender,
                              City = (string)table3.city,
                              Street = (string)table3.street,
                              House_Number = (string)table3.house_number
                          };
            EmployeeDataGrid.ItemsSource = results.ToList();
        }
    }
}

