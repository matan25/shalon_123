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
    /// Interaction logic for ShowClientsTable.xaml
    /// </summary>
    public partial class ShowClientsTable : Window
    {
        Database1Entities1 db1 = new Database1Entities1();
        public ShowClientsTable()
        {
            InitializeComponent();
            var results = from table1 in db1.Clients.AsEnumerable()
                          join table2 in db1.Company.AsEnumerable() on (int)table1.company_id equals (int)table2.Id_Company
                          join table3 in db1.Factory_Occupation.AsEnumerable() on (int)table1.factory_occupation_id equals (int)table3.Id_Factory_Occupation
                          select new
                          {
                              Client_Id = (int)table1.Id_Clients,
                              Company_Name = (string)table2.compnay_name,
                              Company_Country = (string)table2.company_country,
                              Client_Bussiness_Priority = (string)table1.Buissnes_Priority,
                              Note = (string)table1.Note,
                              Deleted = (string)table1.Deleted,
                              Shalon_Factory_Occupations = (string)table3.factory_occupation_name,
                          };
            ClientsDataGrid.ItemsSource = results.ToList();
        }
    }
}
