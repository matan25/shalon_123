using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class clientControllercs
    {
        private ModelController modelClient = new ModelController();

        public List<Clients> GetClient()
        {
            return modelClient.GetClients();
            ////////////////////////////////
        }
    }
}
