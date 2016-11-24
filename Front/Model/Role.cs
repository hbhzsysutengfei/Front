using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Model
{
    public class Role
    {
        public virtual string Id { get; set; }
        public virtual string RoleName { get; set; }
        public virtual string Description { get; set; }

        public Role() { }

        public Role(string name, string des)
        {
            RoleName = name;
            Description = des;
        }


    }
}