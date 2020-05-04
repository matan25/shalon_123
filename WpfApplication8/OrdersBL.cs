using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class OrdersBL
    {
        OrderModel om = new OrderModel();
        public Clients findClient(Database1Entities1 db, string clientName)
        {
            List<Clients> lst = db.Clients.ToList();
            foreach (Clients client in lst)
            {
                if (client.Company.compnay_name == clientName)
                {
                    return client;
                }
            }
            return null;
        }

        public Products findProduct(Database1Entities1 db, string productName)
        {
            List<Products> lst = db.Products.ToList();
            foreach (Products prodcut in lst)
            {
                if (prodcut.name == productName)
                {
                    return prodcut;
                }
            }
            return null;
        }

        public Database1Entities1 AddOrder(string clientName, DateTime orderDate, DateTime deliveryDate, string ret, int quantity, string note, employee emp, string status, Database1Entities1 db1)
        {
            Database1Entities1 db2 = new Database1Entities1();
            Clients client = findClient(db1, clientName);
            if (client == null)
            {
                Console.WriteLine("Client does not exist!");
                return db2;
            }

            Products product = findProduct(db1, ret);
            if (product == null)
            {
                Console.WriteLine("Product does not exist!");
                return db2;
            }
            
            //Products p = db1.Products.Add(new Products { name = ChangeToString(chosen), price = Account(ret, chosen), deleted = "Active"});
            Order_Details od = db1.Order_Details.Add(new Order_Details { Order_Date = orderDate, Delivery_Date = deliveryDate, production_amount = quantity, Note = note, products_id = product.Id_Products});
            db1.Orders.Add(new Orders { Deleted = status, Order_Details = od, employee = new employee(emp), Clients = client});
            return db1;
        }

        public Database1Entities1 UpdateOrder(string clientName ,DateTime sourceDate, DateTime destinationDate, string ret, int quantity, string note, Orders updateorder ,employee emp, string status, Database1Entities1 db1)
        {
            Clients client = findClient(db1, clientName);
            Products product = findProduct(db1, ret);
              if (client == null)
              {
                  Console.WriteLine("Client does not exist!");
                  return db1;
              }


            if (product == null)
             {
                 Console.WriteLine("Product does not exist!");
                 return db1;
             }
            updateorder.Clients.Company.compnay_name = clientName;
            updateorder.Deleted = status;
            updateorder.Order_Details.Delivery_Date = sourceDate;
            updateorder.Order_Details.Order_Date = destinationDate;
            updateorder.Order_Details.production_amount = quantity;
            updateorder.Order_Details.Note = note;
            updateorder.Order_Details.products_id = product.Id_Products;
            //updateorder.Clients.Id_Clients = client.Id_Clients;
           // updateorder.Clients.company_id = client.company_id;
           /* updateorder.Clients.factory_occupation_id = client.factory_occupation_id;
            updateorder.Clients.Buissnes_Priority = client.Buissnes_Priority;
            updateorder.Clients.Note = client.Note;
            updateorder.Clients.Deleted = client.Deleted;*/
            //updateorder.employee.Id_Employee = emp.Id_Employee;
            updateorder.employee.id_number = emp.id_number;
            updateorder.employee.name = emp.name;
            updateorder.employee.phone = emp.phone;
            updateorder.employee.Workers_Gender.Gender = emp.Workers_Gender.Gender;
            updateorder.employee.employee_type.type = emp.employee_type.type;
            updateorder.employee.employee_type.salary = emp.employee_type.salary;
            updateorder.employee.Postal_Code_Worker.street = emp.Postal_Code_Worker.street;
            updateorder.employee.Postal_Code_Worker.city = emp.Postal_Code_Worker.city;
            updateorder.employee.Postal_Code_Worker.house_number = emp.Postal_Code_Worker.house_number;
            db1.Entry(updateorder).State = System.Data.Entity.EntityState.Modified;
            return db1;
        }

        public bool CheckChanges(string clientName, DateTime orderDate, DateTime deliveryDate, string ret, int quantity, string note, string status)
        {
            bool flag;
            flag = om.Validate(clientName, orderDate, deliveryDate, ret, quantity, note, status);
            return flag;
        }

            public string[] CheckBoxChecking(bool[] arr1, string[] arr2)
        {
            string[] ret = new string[arr1.Length];
            int k = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == true)
                {
                    ret[k] = arr2[i];
                    k++;
                }
            }
            return ret;
        }


        public string ChangeToString(string[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + "  ";
            }
            return str;
        }
    }
}
