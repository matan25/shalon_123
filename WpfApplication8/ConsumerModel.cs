using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class ConsumerModel
    {
        public bool IsValidate(string companyName, string companyCountry, string priority, string ret, string note, string status)
        {
            if(companyName == "")
            {
                return false;
            }
            if(companyCountry == "")
            {
                return false;
            }
            if(priority == "")
            {
                return false;
            }
            if(ret == "")
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
