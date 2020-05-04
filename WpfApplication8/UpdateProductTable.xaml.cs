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
    /// Interaction logic for UpdateProductTable.xaml
    /// </summary>
    public partial class UpdateProductTable : Window
    {
        Database1Entities1 db1 = new Database1Entities1();
        public UpdateProductTable()
        {
            var results = from table1 in db1.Products.AsEnumerable()
                          select new
                          {
                              Product_Id = (int)table1.Id_Products,
                              Product_Name = (string)table1.name,
                              Product_Price = (int)table1.price,
                              Product_Availability = (string)table1.deleted,
                          };
            InitializeComponent();
            this.db1.SaveChanges();
            ProductsDataGrid.ItemsSource = results.ToList();
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var updateproduct = ChangeType();
            UpdateProductWindow upw = new UpdateProductWindow(updateproduct,db1);
            this.db1.SaveChanges();
            this.Close();
            upw.ShowDialog();
        }

        private Products ChangeType()
        {
            Products i = db1.Products.ToList().FindAll(e => e.Id_Products == (int)ProductsDataGrid.SelectedItem.GetType().
            GetProperty("Product_Id").GetValue(ProductsDataGrid.SelectedItem)).FirstOrDefault();
            return i;
        }
    }
}
