using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class ModelController
    {
        private Database1Entities1 db = new Database1Entities1();
        public List<Clients> GetClients()
        {
            return db.Clients.ToList();
        }
    }
}
