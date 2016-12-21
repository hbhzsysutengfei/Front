using Front.ASPX;
using Front.ASPX.Catalog;
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
                    switch (article.Catalog.CatalogLoc)
                    {
                        case CatalogHelper.CatalogMainBodyLoc.LocMainBodyFirst:
                            this.BulletedListFirst.Items.Add(new ListItem(article.Title +   "   " + article.UpdateTime.ToLocalTime(), PageInfo.PathArticleShowPage + article.Id));
                            break;
                        case CatalogHelper.CatalogMainBodyLoc.LocMainBodySecond:
                            this.BulletedListSecond.Items.Add(new ListItem(article.Title +  "   " + article.UpdateTime.ToString(), PageInfo.PathArticleShowPage + article.Id));
                            break;
                        case CatalogHelper.CatalogMainBodyLoc.LocMainBodyThird:
                            this.BulletedListThird.Items.Add(new ListItem(article.Title +   "   " + article.UpdateTime.ToString(), PageInfo.PathArticleShowPage + article.Id));
                            break;
                        case CatalogHelper.CatalogMainBodyLoc.LocMainBodyForth:
                            this.BulletedListForth.Items.Add(new ListItem(article.Title +   "   " + article.UpdateTime.ToString(), PageInfo.PathArticleShowPage + article.Id));
                            break;
                        default:
                            break;
                    }
                }
                this.LabelCatalogFirst.Text     =   PageInfo.CatalogsForMainBody[0];
                this.LabelCatalogSecond.Text    =   PageInfo.CatalogsForMainBody[1];
                this.LabelCatalogThird.Text     =   PageInfo.CatalogsForMainBody[2];
                this.LabelCatalogForth.Text     =   PageInfo.CatalogsForMainBody[3];
            }
        }

        protected void buttonShowPage_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("/Article/ShowPageMaster.aspx?" + "articleId=200603f0314a47709d6ee1e47dbbf1aa");
            
        }

        protected void LinkButtonCatalogFirst_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogArticleListPage + this.LabelCatalogFirst.Text);
        }

        protected void LinkButtonCatalogSecond_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogArticleListPage + this.LabelCatalogSecond.Text);
        }

        protected void LinkButtonCatalogThird_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogArticleListPage + this.LabelCatalogThird.Text);
        }

        protected void LinkButtonCatalogForth_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogArticleListPage + this.LabelCatalogForth.Text);
        }

        
    }
}