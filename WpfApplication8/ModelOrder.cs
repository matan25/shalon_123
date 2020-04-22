using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class ModelOrder
    {
        private Database1Entities1 db = new Database1Entities1();
        public List<Orders> GetOrders()
        {
            return db.Orders.ToList();
        }
    }
}
