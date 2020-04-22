using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class EmployeeControlerr
    {
        private Model model = new Model();

        /* public List<employee> GetEmployees()
              {
                  return model.GetEmployees();
              } 

          }*/

        public Database1Entities1 InsertWorker(string type, string salary, string city, string street, string house_number, string gender, string idNumber, string name , string phone, string deleted, Database1Entities1 db1)
        {
            employee_type et = db1.employee_type.Add(new employee_type { type = type, salary = salary });
            Postal_Code_Worker pc = db1.Postal_Code_Worker.Add(new Postal_Code_Worker { city = city, street = street, house_number = house_number });
            Workers_Gender wg = db1.Workers_Gender.Add(new Workers_Gender { Gender = gender });
            db1.employee.Add(new employee { id_number = idNumber, name = name, phone = phone, deleted = deleted, employee_type = et, Postal_Code_Worker = pc });
            return db1;
        }
    }
}
