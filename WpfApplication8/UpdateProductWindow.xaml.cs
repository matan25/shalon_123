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
    /// Interaction logic for UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        Database1Entities1 db1 = new Database1Entities1();
        Products updateproduct = new Products();
        ProductsBL pbl = new ProductsBL();
        public UpdateProductWindow(Products p, Database1Entities1 db1)
        {
            this.updateproduct = p;
            this.db1 = db1;
            InitializeComponent();
        }

        private void Button_Save_Changes(object sender, RoutedEventArgs e)
        {
            int price = 0;
            if(price_tb.Text != "")
            {
                try
                {
                    price = Convert.ToInt32(price_tb.Text);
                }
                catch(Exception)
                {
                    price = 0;
                }
            }
            if (pbl.CheckChanges(name_tb.Text, price, availability_cb.Text) == true)
            {
                db1 = pbl.UpdateProduct(name_tb.Text, price, availability_cb.Text, updateproduct, db1);
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
