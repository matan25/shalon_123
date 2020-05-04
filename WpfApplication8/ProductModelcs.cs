using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class ProductModelcs
    {
        public bool Validate(string productName, int price, string status)
        {
            if(productName == "")
            {
                return false;
            }
            if(price < 10)
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
