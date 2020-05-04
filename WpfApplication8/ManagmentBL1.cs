using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class ManagmentBL1
    {
        ManagmentModel m = new ManagmentModel();
        public Database1Entities1 InsertExpense(string name, string value, DateTime datetime, string note, employee emp ,  Database1Entities1 db1)
        {
            Expends_Type et = db1.Expends_Type.Add(new Expends_Type {name = name});
            db1.Expends_Report.Add(new Expends_Report {note = note,  value =  Convert.ToInt32(value), employee = new employee(emp), Expends_Type = et, date = datetime});
            return db1;
        }

        public bool CheckChanges(string name, string value, DateTime datetime, string note)
        {
            bool flag;
            flag = m.Validate(name, value, datetime, note);
            return flag;
        }
    }
}
