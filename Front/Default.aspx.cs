using Front.ASPX;
using Front.Model;
using Front.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (!IsPostBack)
            {
                ArticleService service = new ArticleService();
                IList<ArticleEntity> articles = service.getArticleForMainPage();

                foreach (var article in articles)
                {
                    switch (article.Catalog.CatalogName)
                    {
                        case PageInfo.CatalogFirst:
                            this.BulletedListFirst.Items.Add(new ListItem(article.Title + "   " + article.UpdateTime.ToString(), PageInfo.PathShowPage + article.Id));
                            break;
                        case PageInfo.CatalogSecond:
                            this.BulletedListSecond.Items.Add(new ListItem(article.Title + "   " + article.UpdateTime.ToString(), PageInfo.PathShowPage + article.Id));
                            break;
                        case PageInfo.CatalogThird:
                            this.BulletedListThird.Items.Add(new ListItem(article.Title + "   " + article.UpdateTime.ToString(), PageInfo.PathShowPage + article.Id));
                            break;
                        case PageInfo.CatalogForth:
                            this.BulletedListForth.Items.Add(new ListItem(article.Title + "   " + article.UpdateTime.ToString(), PageInfo.PathShowPage + article.Id));
                            break;
                        default:
                            break;
                    }
                }
                this.LabelCatalogFirst.Text = PageInfo.CatalogFirst;
                this.LabelCatalogSecond.Text = PageInfo.CatalogSecond;
                this.LabelCatalogThird.Text = PageInfo.CatalogThird;
                this.LabelCatalogForth.Text = PageInfo.CatalogForth;
            }
        }

        protected void buttonShowPage_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("/Article/ShowPageMaster.aspx?" + "articleId=200603f0314a47709d6ee1e47dbbf1aa");
            
        }

        protected void LinkButtonCatalogFirst_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogArticleListPage + PageInfo.CatalogFirst);
        }

        protected void LinkButtonCatalogSecond_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogArticleListPage + PageInfo.CatalogSecond);
        }

        protected void LinkButtonCatalogThird_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogArticleListPage + PageInfo.CatalogThird);
        }

        protected void LinkButtonCatalogForth_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogArticleListPage + PageInfo.CatalogForth);
        }

        
    }
}