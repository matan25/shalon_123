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
    /// Interaction logic for ShowExpensesTablexaml.xaml
    /// </summary>
    public partial class ShowExpensesTable : Window
    {
        Database1Entities1 db1 = new Database1Entities1();
        public ShowExpensesTable()
        {
            InitializeComponent();
            var results = from table1 in db1.Expends_Report.AsEnumerable()
                          join table2 in db1.Expends_Type.AsEnumerable() on (int)table1.expends_type_id equals (int)table2.Id_Expends_Type
                          join table3 in db1.employee.AsEnumerable() on (int)table1.employee_id equals (int)table3.Id_Employee
                          select new
                          {
                              Expense_Type = (string)table2.name,
                              Input_Date = (DateTime)table1.date,
                              Expense_Value = (int)table1.value,
                              Notes = table1.note,
                              Employee_User = table3.id_number,
                          };
            ExpenseDataGrid.ItemsSource = results.ToList();
        }
    }
}
