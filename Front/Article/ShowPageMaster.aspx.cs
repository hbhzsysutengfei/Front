using Front.ASPX;
using Front.Dao;
using Front.Model;
using Front.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.Article
{
    public partial class ShowPageMaster : System.Web.UI.Page
    {
        private const string ArticleIdOfPageNotFound = "200603f0314a47709d6ee1e47dbbf1aa";

        private string articleId;

        public string txtContent;

        private ArticleEntity article;

        protected void Page_Load(object sender, EventArgs e)
        {     
            //默认所有的文章都是可见的
            article =  new ArticleService().getById(getArticleId());
            if (article == null)
            {
                this.labelTitle.Text = "PageNotFound";                
                this.labelAuthor.Text = "";
                this.labelCatalog.Text ="";
                txtContent = "PageNotFound";
                this.buttonDeleteArticle.Visible = false;
                this.buttonUpdateArticle.Visible = false;
            }
            else
            {
                this.labelTitle.Text = article.Title;
                this.labelUpdateTime.Text = article.UpdateTime.ToString();
                this.labelAuthor.Text = article.Author.RealName;
                this.labelCatalog.Text = article.Catalog == null ? "" : article.Catalog.CatalogName;
                txtContent = article.Content; 
            }
            
            ClientEntity client = Session[PageInfo.SessionKey_Client] as ClientEntity;
            if (client != null)
            {
                this.buttonUpdateArticle.Visible = true;
                this.buttonDeleteArticle.Visible = true;
            }
            else
            {
                this.buttonDeleteArticle.Visible = false;
                this.buttonUpdateArticle.Visible = false;
            }
            
        }

        private string getArticleId()
        {
            articleId = Request.Params.Get(PageInfo.PathParamNameOfArticleId);
            if (articleId == null)
            {
                articleId = ArticleIdOfPageNotFound;
            }
            return articleId;
        }

        protected void buttonUpdateArticle_Click(object sender, EventArgs e)
        {
            ClientEntity client = Session[PageInfo.SessionKey_Client] as ClientEntity;
            if (client == null)
            {
                Response.Write("<script>alert('" + PageInfo.MessageBox_NotLogin + "')</script>");
                Response.Redirect(PageInfo.PathClientLogin);
                return;
            }
            else if (client.Role.RoleName.Equals(PageInfo.RoleTypeClient))
            {
                Response.Write("<script>alert('" + PageInfo.MessageBox_NoAdministration + "')</script>");
                //Response.Redirect("/");
                return;
            }
            else if(client.Role.RoleName.Equals(PageInfo.RoleTypeAdmin))
            {
                if (article.Author.Username.Equals(client.Username))
                {
                    Response.Redirect(PageInfo.PathEditPage + articleId);
                    return;
                }
                else
                {
                    Response.Write("<script>alert('" + PageInfo.MessageBox_NoAdministration + "')</script>");
                    return;
                }
            }
            else if(client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
            {
                Response.Redirect(PageInfo.PathEditPage + articleId);
                return;
            }

        }

        protected void buttonDeleteArticle_Click(object sender, EventArgs e)
        {

        }

    }
}