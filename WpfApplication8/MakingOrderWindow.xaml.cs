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
    /// Interaction logic for MakingOrderWindow.xaml
    /// </summary>
    public partial class MakingOrderWindow : Window
    {
        Database1Entities1 db1 = new Database1Entities1();
        OrdersBL obl = new OrdersBL();
        public int ordersum = 0;
        public employee emp;
        public MakingOrderWindow(employee emp)
        {
            InitializeComponent();
            this.emp = emp;
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void M_15_Military_Mask_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Submit(object sender, RoutedEventArgs e)
        {
            // bool flag = csb.CheckAdd(tCompany.Text,tCompanyCountry.Text,cPriority.Text,cnm,im,mnm,pnf,inf,hi,cns,tNote.Text,cStatus.Text);
            //if (flag == true)
            {
                List<Products> lst = db1.Products.ToList();
                string ret = products_cb.Text;
                string dateorder = orderDate.Text;
                string datedelivery = deliveryDate.Text;
                DateTime orderdate = new DateTime();
                if (orderDate.Text != "")
                {
                    orderdate = DateTime.Parse(orderDate.Text);
                }
                DateTime deliverydate = new DateTime();
                if (orderDate.Text != "")
                {
                    deliverydate = DateTime.Parse(deliveryDate.Text);
                }
                int quantity = 0;
                if (quantity_tb.Text != "")
                {
                    try
                    {
                        quantity = Int32.Parse(quantity_tb.Text);
                    }
                    catch (Exception)
                    {
                        quantity = 0;
                    }
                }
                foreach (Products product in lst)
                {
                    if (product.name == products_cb.Text)
                    {
                        ordersum = product.price;
                        break;
                    }
                }
                ordersum = quantity * ordersum;
                string totalSumOrder = ordersum.ToString();
                if (obl.CheckChanges(company_cb.Text, orderdate, deliverydate, ret, quantity, totalSumOrder, cStatus.Text) == true)
                    {
                        db1 = obl.AddOrder(company_cb.Text, deliverydate, orderdate, ret, quantity, totalSumOrder, emp, cStatus.Text, db1);
                        this.db1.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error: you must fullfill all details/according to requirnments!");
                    }
                   try
                    {
                        this.db1.SaveChanges();

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
    }


