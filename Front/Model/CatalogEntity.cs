using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Model
{
    public class CatalogEntity:Entity
    {

        public virtual string CatalogName { get; set; }

        public virtual int CatalogLoc { get; set; }

        //public int CatalogLoc { get; set; } //top header nav content 
        



        public CatalogEntity()
        {

        }

        public CatalogEntity(string name)
        {
            CatalogName = name;
            CatalogLoc = 0;

        }




        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            CatalogEntity catalog = obj as CatalogEntity;
            if (catalog != null && catalog.CatalogName.Equals(CatalogName))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CatalogName.GetHashCode();
        }
                
    }
}