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
    /// Interaction logic for UpdateOrderWindow.xaml
    /// </summary>
    public partial class UpdateOrderWindow : Window
    {
        Database1Entities1 db1 = new Database1Entities1();
        OrdersBL obl = new OrdersBL();
        Orders updateorder = new Orders();
        employee emp = new employee();
        Products p = new Products();
        public UpdateOrderWindow(Orders od , Database1Entities1 db1, employee emp)
        {
            this.updateorder = od;
            this.db1 = db1;
            this.emp = emp;
            InitializeComponent();
            List<Products> lst = db1.Products.ToList();
            List<Company> lst2 = db1.Company.ToList();
            List<Clients> lst3 = db1.Clients.ToList();
            foreach (Products prodcut in lst)
            {
                if (prodcut.deleted == "Avaibale")
                {
                    products_cb.Items.Add(prodcut.name);
                }
            }
            foreach (Company company in lst2)
            {
                foreach (Clients client in lst3)
                {
                    if (client.company_id == company.Id_Company && client.Deleted == "Active")
                    {
                        company_cb.Items.Add(company.compnay_name);
                        break;
                    }
                }
            }
        }

        private void Button_Submit(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            string ret = products_cb.Text;
            string dateorder = orderDate.Text;
            string datedelivery = deliveryDate.Text;
            DateTime orderdate = DateTime.Parse(orderDate.Text);
            DateTime deliverydate = DateTime.Parse(deliveryDate.Text);
            List<Products> lst = db1.Products.ToList();
            int quantity;
            if (quantity_tb.Text == "")
            {
                quantity = 0;
            }
            else
            {
                quantity = Int32.Parse(quantity_tb.Text);
            }
            foreach(Products product in lst)
            {
                if(product.name == products_cb.Text )
                {
                    sum = product.price;
                    break;
                }
            }
            sum = quantity * sum;
            string orderPrice = sum.ToString();
            if (obl.CheckChanges(company_cb.Text, orderdate, deliverydate, ret, quantity, orderPrice, cStatus.Text) == true)
            {
                db1 = obl.UpdateOrder(company_cb.Text, orderdate, deliverydate, ret, quantity, orderPrice, updateorder, emp, cStatus.Text, db1);
                this.db1.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: you must fullfill all details/according to requirnments!");
            }
        }
    }
}
