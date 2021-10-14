using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecture_3.Models.Entity
{
    public class User
    {
       public int UID
        {
            get;
            set;
        }
        public string UuName { get; set; }

        public string UName { get; set; }
        public string Password { get; set;  }

    }
    
}