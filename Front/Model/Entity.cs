using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Model
{
    public class Entity
    {
        public Entity()
        {
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
        public virtual string Id { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime UpdateTime { get; set; }

        public virtual String PageInfo { get; set; }

        public virtual void updateUpdateTime()
        {
            UpdateTime = DateTime.Now;
        }
    }
}