﻿using Front.ASPX;
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


        public IList<ArticleEntity> getArticleForMainPage()
        {
            IList<ArticleEntity> list = new List<ArticleEntity>();
            foreach (var catalog in PageInfo.CatalogForMainPage)
            {
                var articleList = dao.getArticleListByCatalog(catalog);
                foreach (var article in articleList)
                {
                    list.Add(article);
                }
            }
            return list; 
        }

        public IList<ArticleEntity> getArticleListByCatalogAndAuthor(string author, string catalog, int pageNumber = 0, int getNumber = PageInfo.NumberOfArticleForUserPage)
        {
            return dao.getArticleByAuthorAndCatalog(author, catalog, pageNumber, getNumber);
        }




        public IList<ArticleEntity> getArticleListByCatalogName(String catalog)
        {
            return dao.getArticleListByCatalog(catalog);
        }


        public IList<ArticleEntity> getArticleListByAuthor(String author, int pageNumber = 0, int getNumber = PageInfo.NumberOfArticleForUserPage)
        {
            return dao.getArticleListByAuthor(author, pageNumber, getNumber);
        }

        public IList<ArticleEntity> getAllArticleList(int pageNumber = 0, int getNumber = PageInfo.NumberOfArticleForUserPage)
        {

            return dao.getAllArticleList(pageNumber, getNumber);
        }


        public int getArticleListByAuthorForNumber(string author)
        {
            return dao.getArticleListByAuthorForNumber(author);
        }
    }
}