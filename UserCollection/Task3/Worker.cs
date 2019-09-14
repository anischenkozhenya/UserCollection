using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Worker:Citizen
    {
        public Worker(int id) : base(id)
        {

        }
        public Worker(int id,string firstname,string lastname) : base(id, firstname, lastname)
        {

        }
    }
}
