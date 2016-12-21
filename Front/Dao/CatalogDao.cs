using Front.ASPX;
using Front.ASPX.Catalog;
using Front.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Dao
{
    public class CatalogDao : DataDao
    {

        public CatalogDao()
        {

        }

        public string save(CatalogEntity catalog)
        {
            ITransaction tx = session.BeginTransaction();
            string generateId = session.Save(catalog) as string;
            tx.Commit();
            //session.Close();
            return generateId;
        }

        public void save(CatalogEntity[] catalogs)
        {
            ITransaction tx = session.BeginTransaction();
            foreach (var catalog in catalogs)
            {
                session.Save(catalog);
            }
            tx.Commit();
            //session.Close();            
        }

        public CatalogEntity get(string name)
        {
            CatalogEntity catalog = session.QueryOver<CatalogEntity>().Where(c => c.CatalogName == name).SingleOrDefault();
            //session.Close();
            return catalog;
        }

        public IList<CatalogEntity> getAll()
        {
            IList<CatalogEntity> list = session.QueryOver<CatalogEntity>().List();
            //session.Close();
            return list;
        }

        public IList<CatalogEntity> getCatalogsByNames(string[] names)
        {
            IList<CatalogEntity> list = session.QueryOver<CatalogEntity>().WhereRestrictionOn(c => c.CatalogName).IsIn(names).List();
            return list;
        }

        public IList<CatalogEntity> getCatalogsForMainPage()
        {
            return session.QueryOver<CatalogEntity>()
                .And(m => m.CatalogLoc >= CatalogHelper.CatalogMainBodyLocStart)
                .And(m => m.CatalogLoc <= CatalogHelper.CatalogMainBodyLocEnd)
                .OrderBy(c => c.CatalogLoc).Asc.List();
        }

        public void DeleteCatalogByName(string catalog_name)
        {
            ITransaction tx = session.BeginTransaction();
            CatalogEntity catalog = this.get(catalog_name);
            if (catalog != null)
            {
                session.Delete(catalog);
            }            
            tx.Commit();
        }
    }
}