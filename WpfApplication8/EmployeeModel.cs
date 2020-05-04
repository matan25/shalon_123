using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class EmployeeModel
    {
        private Database1Entities1 db = new Database1Entities1();
        /*  public List<employee> GetEmployees()
          {
               return db.employee.ToList();
          }*/
        public bool ValidateWorker(string type, int salary, string city, string street, string house_number, string gender, string idNumber, string name, string phone, string deleted)
        {
            if (type == "")
            {
                return false;
            }
            if (salary < 5300 || salary > 100000)
            {
                return false;
            }
            if (city == "")
            {
                return false;
            }
            if (street == "")
            {
                return false;
            }
            if (house_number == "")
            {
                return false;
            }
            if (gender == "")
            {
                return false;
            }
            if (idNumber == "")
            {
                return false;
            }
            if(idNumber.Length!=9)
            {
                return false;
            }
            if (name == "")
            {
                return false;
            }
            if (phone == "")
            {
                return false;
            }
            if (phone.Length != 10)
            {
                return false;
            }
            if (deleted == "")
            {
                return false;
            }
            return true;
        }
    }
}
