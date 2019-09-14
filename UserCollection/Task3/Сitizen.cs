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
        public string firstname { get; protected set; }
        public string lastname { get; protected set; }
        public string FullName { get { return string.Format("{0} {1}", firstname, lastname);} }
        public Citizen(int id)
        {
            Id = id;
        }

        public Citizen(int id,string firstname,string lastname):this(id)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

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
