using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Model
{
    public class ArticleEntity:Entity
    {
        public ArticleEntity()
        {

        }

        public virtual ClientEntity Author { get; set; }

        public virtual string Title { get; set; }

        public virtual string Content { get; set; }

        public virtual CatalogEntity Catalog { get; set; }

       


    }
}