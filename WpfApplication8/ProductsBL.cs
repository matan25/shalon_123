using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class ProductsBL
    {
        ProductModelcs pm = new ProductModelcs();
        public Database1Entities1 AddProduct(string productName, int price, string status, Database1Entities1 db1)
        {
            db1.Products.Add(new Products { name = productName, price = price, deleted = status });
            return db1;
        }

        public Database1Entities1 UpdateProduct(string productName, int price, string status,Products updateproduct ,Database1Entities1 db1)
        {
            updateproduct.name = productName;
            updateproduct.price = price;
            updateproduct.deleted = status;
            db1.Entry(updateproduct).State = System.Data.Entity.EntityState.Modified;
            return db1;
        }

        public bool CheckChanges(string productName, int price, string status)
        {
            bool flag;
            flag = pm.Validate(productName, price, status);
            return flag;
        }
    }
}
