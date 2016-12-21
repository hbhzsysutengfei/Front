using Front.Dao;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Service
{
    public class CatalogService
    {
        private CatalogDao dao;
        public CatalogService()
        {
            dao = new CatalogDao();
        }

        public IList<CatalogEntity> getAll()
        {
            return dao.getAll();
        }

        public IList<CatalogEntity> GetCatalogsByNames(string[] names)
        {
            return dao.getCatalogsByNames(names);
        }

        public CatalogEntity GetCatalogByName(string name)
        {
            return dao.get(name);
        }

        public string SaveCatalog(CatalogEntity catalog)
        {
            return  dao.save(catalog);
        }

        public IList<CatalogEntity> GetCatalogsForMainPage()
        {
            return dao.getCatalogsForMainPage();
        }

        public void DeleteCatalog(string catalog_name)
        {
            //delete articles 
            ArticleDao articleDao = new ArticleDao();
            articleDao.DeleteCatalogArticles(catalog_name);

            //delete catalog
            dao.DeleteCatalogByName(catalog_name);
        }

    }
}