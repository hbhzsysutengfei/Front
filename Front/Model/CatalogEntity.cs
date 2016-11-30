using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Model
{
    public class CatalogEntity:Entity
    {

        public string CatalogName { get; set; }


        public CatalogEntity()
        {

        }

        public CatalogEntity(string name)
        {
            CatalogName = name;
        }
                
    }
}