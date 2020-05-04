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
    /// Interaction logic for UpdateEmployeeWindoe.xaml
    /// </summary>
    public partial class UpdateEmployeeWindow : Window
    {
        private Database1Entities1 db = new Database1Entities1();
        EmployeeBL ebl = new EmployeeBL();
        private DataGrid d = new DataGrid();
        private employee updateworker1;
        public UpdateEmployeeWindow(employee updateworker, Database1Entities1 db1, DataGrid dg)
        {
            this.db = db1;
            this.d = dg;
            this.updateworker1 = updateworker;
            InitializeComponent();
        }

        private void TName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int salary = 0;
            if (tSalary.Text != "")
            {
                try
                {
                    salary = Convert.ToInt32(tSalary.Text);
                }
                catch(Exception)
                {
                    salary = 0;
                }
            }
            bool flag = ebl.CheckChanges(cType.Text, salary, tCity.Text, tStreet.Text, tNumberHouse.Text, cGender.Text, tNumberId.Text, tName.Text, tPhone.Text, cDeleted.Text);
            if (flag == true)
            {
                db = ebl.UpdateWorker(cType.Text, salary, tCity.Text, tStreet.Text, tNumberHouse.Text, cGender.Text, tNumberId.Text, tName.Text, tPhone.Text, cDeleted.Text,updateworker1 ,db);
                this.db.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: you must fullfill all details/according to requirment!");
            }
        /*    //TO DO: Validate input
            updateworker1.phone = tPhone.Text;
            updateworker1.Workers_Gender.Gender = cGender.Text;
            updateworker1.name = tName.Text;
            updateworker1.id_number = tNumberId.Text;
            updateworker1.deleted = cDeleted.Text;
            updateworker1.employee_type.type = cType.Text;
            updateworker1.employee_type.salary = salary;
            updateworker1.Postal_Code_Worker.city = tCity.Text;
            updateworker1.Postal_Code_Worker.street = tStreet.Text;
            updateworker1.Postal_Code_Worker.house_number = tNumberHouse.Text;
            db.Entry(updateworker1).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();
            this.Close();*/
        }
    }
}


