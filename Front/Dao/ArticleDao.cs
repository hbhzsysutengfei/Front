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