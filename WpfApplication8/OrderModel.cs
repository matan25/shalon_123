using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class OrderModel
    {
        public bool Validate(string clientName, DateTime orderDate, DateTime deliveryDate, string ret, int quantity, string note, string status)
        {
            if(clientName == "")
            {
                return false;
            }
            if(orderDate == null)
            {
                return false;
            }
            if(deliveryDate == null)
            {
                return false;
            }
            if(ret == "")
            {
                return false;
            }
            if(quantity < 1)
            {
                return false;
            }
            if(status == "")
            {
                return false;
            }
            return true;

        }
    }
}
