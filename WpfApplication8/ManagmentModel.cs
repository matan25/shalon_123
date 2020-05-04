using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class ManagmentModel
    {
        public bool Validate(string name, string value, DateTime datetime, string note)
        {
            int val = 0;
            if (value != "")
            {
                try
                {
                    val = Convert.ToInt32(value);
                }
                catch(Exception)
                {
                    val = 0;
                }
            }
            if(name == "")
            {
                return false;
            }
            if(val < 1)
            {
                return false;
            }
            if(datetime.ToString() == "")
            {
                return false;
            }
            return true;
        }
    }
}
