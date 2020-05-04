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
    /// Interaction logic for ShowOrdersReport.xaml
    /// </summary>
    public partial class ShowOrdersReport : Window
    {
        Database1Entities1 db1 = new Database1Entities1();
        public ShowOrdersReport()
        {
            InitializeComponent();
            var results = from table1 in db1.Orders.AsEnumerable()
                          join table2 in db1.employee.AsEnumerable() on (int)table1.employee_id equals (int)table2.Id_Employee
                          join table3 in db1.Order_Details.AsEnumerable() on (int)table1.order_details_id equals (int)table3.Id_Order_Details
                          join table4 in db1.Clients.AsEnumerable() on (int)table1.client_id equals (int)table4.Id_Clients
                          join table5 in db1.Company.AsEnumerable() on (int)table4.company_id equals (int)table5.Id_Company

                          select new
                          {
                              Client_Name = (string)table5.compnay_name,
                              Source_Date = (DateTime)table3.Delivery_Date,
                              Destination_Date = (DateTime)table3.Order_Date,
                              Selected_Product_id = table3.products_id,
                              Quantity_Amount = (int)table3.production_amount,
                              Employee_Id_User = (string)table2.id_number,
                              Order_Price = (string)table3.Note,
                              Deleted = (string)table1.Deleted,
                          };
            OrdersDataGrid.ItemsSource = results.ToList();
        }
    }
}
