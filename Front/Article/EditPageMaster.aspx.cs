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
    public partial class EditPageMaster : System.Web.UI.Page
    {
        private string UpdateArticleId;
        public string txtContent; //for write to the aspx page
        public Boolean BoolUpdateArticle = false;
        ///wait for check update administration
        ///
        //public String contents;
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateArticleId = Request.Params.Get(PageInfo.PathParamNameOfArticleId);

            if (!IsPostBack)
            {
                ClientEntity client = Session[PageInfo.SessionKey_Client] as ClientEntity;
                if (client == null)
                {
                    //Response.Write("<script>alert('" + PageInfo.MessageBox_NotLogin + "')</script>");
                    Response.Redirect(PageInfo.PathClientLogin + Request.Url.ToString());
                    return;
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeClient))
                {
                    Response.Write("<script>alert('" + PageInfo.MessageBox_NoAdministration + "')</script>");
                    Response.Redirect(PageInfo.PathDefaultPage);
                    return;
                }
                foreach (var catalog in client.Catalogs)
                {
                    DropDownListCatalog.Items.Add(catalog.CatalogName);
                }
                
                if (UpdateArticleId == null || UpdateArticleId.Length == 0)
                {
                    
                    ///for create 
                    DropDownListCatalog.SelectedIndex = 0;
                    this.BoolUpdateArticle = false;
                }
                else
                {
                    ///update page module 
                    ///load the article
                    this.BoolUpdateArticle = true;
                    ArticleEntity article = new ArticleService().getById(UpdateArticleId);
                    if (article.Author.Username.Equals(client.Username))
                    {
                        this.txtContent = article.Content;
                        this.TextBoxTitle.Text = article.Title;
                        if (article.Catalog != null)
                        {
                            this.DropDownListCatalog.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('" + PageInfo.MessageBox_NoAdministration + "')</script>");
                    }
                   
                }
            }
            else
            {

            }
           

            //check for update or create
            
        }

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
            
            // submit 发布 update
            if (UpdateArticleId != null)
            {
                String txtContent = Request.Form["textEditPage"];
                ArticleService service = new ArticleService();
                ArticleEntity article = service.getById(UpdateArticleId);
                article.Content = txtContent;
                article.Title = this.TextBoxTitle.Text;
                article.Catalog = new CatalogDao().get(DropDownListCatalog.SelectedItem.Text);
                article.updateUpdateTime();                
                service.update(article);
                Response.Redirect(PageInfo.PathShowPage + UpdateArticleId);
            }
            else
            {
                ArticleService service = new ArticleService();
                ArticleEntity article = new ArticleEntity();
                article.Content = txtContent;
                article.Title = this.TextBoxTitle.Text;
                article.Author = new ClientDao().getClientByUsername(((ClientEntity)Session[PageInfo.SessionKey_Client]).Username);
                article.Catalog = new CatalogDao().get(DropDownListCatalog.SelectedItem.Text);                               
                string res = service.save(article);
                Response.Redirect(PageInfo.PathShowPage + res);
            }                   
        }       
    }
}