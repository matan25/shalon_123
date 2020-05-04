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
    /// Interaction logic for UpdateTable.xaml
    /// </summary>
    public partial class UpdateEmployeeTable : Window
    {
        private Database1Entities1 db = new Database1Entities1();
        private DataGrid d = new DataGrid();
        private Database1Entities1 dbSave = new Database1Entities1();
        public UpdateEmployeeTable(Database1Entities1 db1)
        {
            this.db = db1;
            var results = from table1 in db.employee.AsEnumerable()
                          select new
                          {
                              Employee_Id = (int)table1.Id_Employee,
                              Id_Number = (string)table1.id_number,
                              Name = (string)table1.name,
                          };
            InitializeComponent();
            this.db.SaveChanges();
            updateGrid.ItemsSource = results.ToList();
        }


        private void updateGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var updateworker = ChangeType();
            UpdateEmployeeWindow uew = new WpfApplication8.UpdateEmployeeWindow(updateworker, db, d);
            this.db.SaveChanges();
            this.Close();
            uew.ShowDialog();
        }

        private employee ChangeType()
        {
            employee i = db.employee.ToList().FindAll(e => e.Id_Employee == (int)updateGrid.SelectedItem.GetType().
            GetProperty("Employee_Id").GetValue(updateGrid.SelectedItem)).FirstOrDefault();
            return i;
        }
    }
}

