using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Model
{
    public class RoleEntity:Entity
    {
        
        public virtual string RoleName { get; set; }

        public virtual string Description { get; set; }

        public RoleEntity()
        {

        }

        public RoleEntity(string name, string des)
        {
            RoleName = name;
            Description = des;
        }


    }
}