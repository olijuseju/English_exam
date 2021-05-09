using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace English_exam
{
    public class ClientList
    {
        public List<Client> clients { get; set; }

        public ClientList()
        {
            clients = new List<Client>();
        }

    }
}