using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public abstract class Citizen
    {
        protected int id = 0;
        public int Id
        {
            get {return id;}
            set {id = value;}
        }
        public bool Equals(Citizen newcitizen)
        {
            if (newcitizen.Id==this.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
