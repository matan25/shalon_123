using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class orderController
    {
        private ModelOrder model = new ModelOrder();

        public List<Orders> GetOrder()
        {
            return model.GetOrders();
        }
    }
}
