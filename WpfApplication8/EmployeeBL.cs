using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class EmployeeBL
    {
        private EmployeeModel model = new EmployeeModel();
        //TMP
        /* public List<employee> GetEmployees()
              {
                  return model.GetEmployees();
              } 

          }*/

        public Database1Entities1 InsertWorker(string type, int salary, string city, string street, string house_number, string gender, string idNumber, string name, string phone, string deleted, Database1Entities1 db1)
        {

            employee_type et = db1.employee_type.Add(new employee_type { type = type, salary = salary });
            Postal_Code_Worker pc = db1.Postal_Code_Worker.Add(new Postal_Code_Worker { city = city, street = street, house_number = house_number });
            Workers_Gender wg = db1.Workers_Gender.Add(new Workers_Gender { Gender = gender });
            db1.employee.Add(new employee { id_number = idNumber, name = name, phone = phone, deleted = deleted, employee_type = et, Postal_Code_Worker = pc, Workers_Gender = wg });
            return db1;
        }

        public Database1Entities1 UpdateWorker(string type, int salary, string city, string street, string house_number, string gender, string idNumber, string name, string phone, string deleted, employee updateworker1, Database1Entities1 db)
        {
            updateworker1.phone = phone;
            updateworker1.Workers_Gender.Gender = gender;
            updateworker1.name = name;
            updateworker1.id_number = idNumber;
            updateworker1.deleted = deleted;
            updateworker1.employee_type.type = type;
            updateworker1.employee_type.salary = salary;
            updateworker1.Postal_Code_Worker.city = city;
            updateworker1.Postal_Code_Worker.street = street;
            updateworker1.Postal_Code_Worker.house_number = house_number;
            db.Entry(updateworker1).State = System.Data.Entity.EntityState.Modified;
            return db;
        }
        public bool CheckChanges(string type, int salary, string city, string street, string house_number, string gender, string idNumber, string name, string phone, string deleted)
        {
            bool flag = model.ValidateWorker(type, salary, city, street, house_number, gender, idNumber, name, phone, deleted);
            return flag;
        }
    }
}
