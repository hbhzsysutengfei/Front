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

        /// <summary>
        /// get Article by the Article Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArticleEntity getById(string id)
        {
            return session.Load<ArticleEntity>(id);
        }

        /// <summary>
        /// save article
        /// </summary>
        /// <param name="art"></param>
        /// <returns></returns>
        public string save(ArticleEntity art)
        {
            ITransaction tx = session.BeginTransaction();
            string generatedId = session.Save(art) as string;
            tx.Commit();
            //session.Close();
            return generatedId;

        }

        /// <summary>
        /// update the article
        /// </summary>
        /// <param name="article"></param>
        public void update(ArticleEntity article)
        {
            ITransaction tx = session.BeginTransaction();
            session.Update(article);
            tx.Commit();
            //session.Close();
        }

        
        /// <summary>
        /// get all article without limitation, just for superadmin
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="getNumber"></param>
        /// <returns></returns>
        public IList<ArticleEntity> getAllArticleList(int pageNumber, int getNumber)
        {
            return session.QueryOver<ArticleEntity>()
                .Select(
                    a=>a.Id,
                    a=>a.Title,
                    a => a.UpdateTime,
                    a=>a.Catalog,                    
                    a=>a.Author).OrderBy(a=>a.UpdateTime).Desc
                .Skip(pageNumber*getNumber).Take(getNumber).List<object[]>()
                .Select(
                    props => new ArticleEntity 
                    { 
                        Id = (string)props[0], 
                        Title = props[1] as string, 
                        UpdateTime = (DateTime)props[2], 
                        Catalog = props[3] as CatalogEntity,
                        Author = props[4] as ClientEntity                    
                    })
                .ToList<ArticleEntity>();                
        }

        public int getAllArticleListForNumber()
        {
            return session.QueryOver<ArticleEntity>().RowCount();
        }


        public IList<ArticleEntity> getArticleListByCatalog(string catalog,int pageNumber = 0, int getNumber = PageInfo.NumberOfArticleForMainPage)
        {
           IList<ArticleEntity> res =  session.QueryOver<ArticleEntity>()
               .Where(a => a.Catalog.CatalogName == catalog)
               .Select(
                    a => a.Id, 
                    a => a.Title,                  
                    a => a.UpdateTime,
                    a => a.Author,
                    a => a.Catalog).OrderBy(a =>a.UpdateTime).Desc
                .Skip(pageNumber * getNumber).Take(getNumber).List<object[]>()
                .Select(
                    props => new ArticleEntity 
                    { 
                        Id = (string)props[0], 
                        Title = props[1] as string, 
                        UpdateTime = (DateTime)props[2] ,
                        Author = props[3] as ClientEntity,
                        Catalog= props[4] as CatalogEntity
                    })
                .ToList<ArticleEntity>();
           return res;
        }
        public int getArticleListByCatalogForNumber(string catalog)
        {
            return session.QueryOver<ArticleEntity>().Where(a => a.Catalog.CatalogName == catalog).RowCount();
        }


        /// <summary>
        /// get the article list by author
        /// </summary>
        /// <param name="author"></param>
        /// <param name="pageNumber"></param>
        /// <param name="get"></param>
        /// <returns></returns>
        public IList<ArticleEntity> getArticleListByAuthor(string author, int pageNumber = 0, int get = PageInfo.NumberOfArticleForUserPage)
        {
            return session.QueryOver<ArticleEntity>()
                .Where(a => a.Author.Username == author)
                .Select(a => a.Id,
                            a => a.Title,
                            a => a.UpdateTime,
                            a => a.Catalog,
                            a => a.Author).OrderBy(a => a.UpdateTime).Desc
                .Skip(pageNumber * get).Take(get).List<object[]>()
                .Select(props => new ArticleEntity
                    {
                        Id = (string)props[0],
                        Title = props[1] as string,
                        UpdateTime = (DateTime)props[2],
                        Catalog = props[3] as CatalogEntity,
                        Author = props[4] as ClientEntity
                    })
                .ToList<ArticleEntity>();
        }

        public int getArticleListByAuthorForNumber(string author)
        {
            return session.QueryOver<ArticleEntity>().Where(a => a.Author.Username == author).RowCount();
        }


        public IList<ArticleEntity> getArticleByAuthorAndCatalog(string author, string catalog, int pageNumber=0, int getNumber=PageInfo.NumberOfArticleForUserPage)
        {
            return session.QueryOver<ArticleEntity>().And(a => a.Author.Username == author).And(a => a.Catalog.CatalogName == catalog)
                        .Select(
                            a => a.Id,
                            a => a.Title,
                            a => a.UpdateTime,
                            a => a.Catalog,
                            a => a.Author).OrderBy(a => a.UpdateTime).Desc
                        .Skip(pageNumber * getNumber).Take(getNumber).List<object[]>()
                        .Select(props => new ArticleEntity
                        {
                            Id = (string)props[0],
                            Title = props[1] as string,
                            UpdateTime = (DateTime)props[2],
                            Catalog = props[3] as CatalogEntity,
                            Author = props[4] as ClientEntity
                        }).ToList<ArticleEntity>();
        }

        public int getArticleByAuthorAndCatalogForNumber(string author, string catalog)
        {
            return session.QueryOver<ArticleEntity>().And(a => a.Author.Username == author).And(a => a.Catalog.CatalogName == catalog).RowCount();
        }

        //////////////////////////////////////////////////////////////////////// 
        ///for test ignore followed
        //////////////////////////////////////


        /// <summary>
        /// for Test
        /// </summary>
        /// <returns></returns>
        public IList<String> getArticleList()
        {
            return session.QueryOver<ArticleEntity>().Select(a => a.Id).Take(FETCH_MAX_COUNT).List<String>();
        }

        /// <summary>
        /// for test
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public IList<String> getArticleListByAuthor(String author)
        {
            return session.QueryOver<ArticleEntity>().Select(a => a.Id).Where(a => a.Author.Username == author).Take(FETCH_MAX_COUNT).List<String>();
        }


        public  void DeleteArticle(string articleId)
        {
            ITransaction tx = session.BeginTransaction();
            session.Delete("from ArticleEntity where Id='" + articleId +"'");
            tx.Commit();
        }

        public void DeleteCatalogArticles(string catalog_name)
        {
            ITransaction tx = session.BeginTransaction();
            session.Delete("from ArticleEntity where Catalog='"+ catalog_name+"'");
            tx.Commit();
        }
    }
}