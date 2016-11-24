using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Model
{
    public class DepartmentEntity:Entity
    {

        public DepartmentEntity()
        {

        }

        public DepartmentEntity(string department, string description)
        {
            // TODO: Complete member initialization
            DepartmentName = department;
            Description = description;
        }
        public virtual string Id { get; set; }

        public virtual string DepartmentName { get; set; }

        public virtual string Description { get; set; }

    }
}