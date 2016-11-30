using Front.Dao;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Service
{
    public class ArticleService
    {
        private ArticleDao dao;
        public ArticleService()
        {
            dao = new ArticleDao();
        }

        public string save(ArticleEntity article)
        {
            return dao.save(article);
        }

        public void update(ArticleEntity article)
        {
            dao.update(article);
        }

        public ArticleEntity getById(string articleId)
        {
            ArticleEntity article = dao.getById(articleId);
            return article;
        }

       
    }
}