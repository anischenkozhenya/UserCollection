using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Pensioner:Citizen
    {
        public Pensioner(int id) : base(id)
        {

        }
        public Pensioner(int id, string firstname, string lastname) : base(id, firstname, lastname)
        {

        }
    }
}
