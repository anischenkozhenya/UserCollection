﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Student: Citizen
    {
        public Student(int id) : base(id)
        {

        }
        public Student(int id, string firstname, string lastname) : base(id, firstname, lastname)
        {

        }
    }
}
