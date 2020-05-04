using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Interaction logic for AddExpeneseWindow.xaml
    /// </summary>
    public partial class AddExpeneseWindow : Window
    {
        Database1Entities1 db1 = new Database1Entities1();
        ManagmentBL1 mbl = new ManagmentBL1();
        employee emp = new employee();
        public AddExpeneseWindow(employee emp)
        {
            this.emp = emp;
            InitializeComponent();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            string date = date_dp.Text;
            DateTime usingDate = new DateTime();
            if (date_dp.Text != "")
            {
                usingDate = DateTime.Parse(date_dp.Text);
            }
            if (mbl.CheckChanges(name_tb.Text, value_tb.Text, usingDate, note_tb.Text) == true)
            {
                db1 = mbl.InsertExpense(name_tb.Text, value_tb.Text, usingDate, note_tb.Text, emp, db1);
                this.db1.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: you must fullfill all details/according to requirnments!");
                this.Close();
            }
            try
            {
                this.db1.SaveChanges();
                this.Close();
            }
            catch (DbEntityValidationException exc)
            {
                foreach (var eve in exc.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
    

