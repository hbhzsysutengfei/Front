using Front.ASPX;
using Front.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Dao
{
    public class ArticleDao:DataDao
    {
        public ArticleDao() { }

        public ArticleEntity getById(string id)
        {
            return session.Load<ArticleEntity>(id);
        }
        public IList<String> getArticleList()
        {
            return session.QueryOver<ArticleEntity>().Select(a => a.Id).Take(FETCH_MAX_COUNT).List<String>();
        }
        public IList<String> getArticleListByAuthor(String  author)
        {
            return session.QueryOver<ArticleEntity>().Select(a => a.Id).Where(a=>a.Author.Username == author ).Take(FETCH_MAX_COUNT).List<String>();
        }

        public IList<ArticleEntity> getArticleListByCatalog(string catalog,int skip = 0)
        {
           IList<ArticleEntity> res =  session.QueryOver<ArticleEntity>()
               .Where(a => a.Catalog.CatalogName == catalog)
               .Select(a => a.Id, a => a.Title, a => a.UpdateTime).OrderBy(a =>a.UpdateTime).Desc
                .Skip(skip * PageInfo.ArticlePerPage).Take(PageInfo.ArticlePerPage).List<object[]>()
                .Select(props => new ArticleEntity { Id = (string)props[0], Title = props[1] as string, UpdateTime = (DateTime)props[2] ,Catalog=new CatalogEntity(catalog)})
                .ToList<ArticleEntity>();
           return res;
        }
        public string save(ArticleEntity art)
        {
            ITransaction tx = session.BeginTransaction();
            string generatedId = session.Save(art) as string;
            tx.Commit();
            session.Close();
            return generatedId;
           
        }

        public void update(ArticleEntity article)
        {
            ITransaction tx = session.BeginTransaction();
            session.Update(article);
            tx.Commit();
            session.Close();
        }
    }
}