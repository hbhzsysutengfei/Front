using Front.ASPX;
using Front.Model;
using Front.Service;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.Article
{
    public partial class ManagementArticleMaster : System.Web.UI.Page
    {

        private int PageSize = PageInfo.NumberOfArticleForUserPage; //每页的数据条
        private int ItemCount; //一共有多少数据
        private int CurrentPage = 0; //当前页数
        private int PageCount   ;

        private DataSet ds ;
        private const string TableName = "Article";
        private const string ButtonCommandNameView = "View";
        private const string ButtonCommandNameDelete = "Delete";
        
        //private string author;
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                ClientEntity client = Session[PageInfo.SessionKey_Client] as ClientEntity;
                if (client == null)
                {
                    Response.Redirect(PageInfo.PathClientLogin + Request.Url.ToString());
                    return;
                }
                else if (client.Role.RoleName == PageInfo.RoleTypeClient)
                {
                    Response.Write("<script>alert('" + PageInfo.MessageBox_NoAdministration + "')</script>");
                    Response.Redirect(PageInfo.PathDefaultPage);
                    return;
                }
                else if (client.Role.RoleName == PageInfo.RoleTypeAdmin)
                {
                    foreach (var catalog in client.Catalogs)
                    {
                        this.DropDownListCatalog.Items.Add(new ListItem(catalog.CatalogName));
                    }
                    ArticleService service = new ArticleService();
                    IList<ArticleEntity> articles = this.getArticlesForAdmin(service, client.Username, null, 0, PageSize, true);

                    if (this.ItemCount != 0)
                    {
                        this.PageCount = (this.ItemCount + PageSize - 1) / PageSize;
                        this.CurrentPage = 1;
                        this.setDropDownListPageNumber();
                        this.PageState();
                        this.setArticlesToGridView(articles);
                    }
                    
                }
                else if (client.Role.RoleName == PageInfo.RoleTypeSuperAdmin)
                {
                    InitCatalogForSuperAdmin();
                    ArticleService service = new ArticleService();
                    IList<ArticleEntity> articles = this.getArticlesForSuperAdmin(service, null, 0, PageSize, true);

                    if(this.ItemCount!=0){
                        this.PageCount = (this.ItemCount + PageSize - 1) / PageSize;
                        this.CurrentPage = 1;
                        this.setDropDownListPageNumber();
                        this.PageState();
                        this.setArticlesToGridView(articles);
                    }                    
                }
               
            }
        }

        private void InitCatalogForSuperAdmin()
        {
            CatalogService service = new CatalogService();
            IList<CatalogEntity> catalogs = service.getAll();
            foreach (var catalog in catalogs)
            {
                this.DropDownListCatalog.Items.Add(new ListItem(catalog.CatalogName));
            }
        }

        private IList<ArticleEntity> getArticlesForSuperAdmin(ArticleService service, string catalog, int pageNumber, int getNumber, Boolean calculateCount)
        {
            if (catalog == null)
            {
                if (calculateCount)
                {
                    this.ItemCount = service.getAllArticleListNumber();
                }
                return service.getAllArticleList(pageNumber, PageSize);
            }
            else
            {
                if (calculateCount)
                {
                    this.ItemCount = service.getArticleListByCatalogNameForNumber(catalog);
                }
                return service.getArticleListByCatalogName(catalog, pageNumber, getNumber);
            }
        }

        //填充页码数字
        private void setDropDownListPageNumber()
        {
            for (var index = 1; index <= PageCount; index++)
            {
                this.DropDownListPageNumber.Items.Add(new ListItem(index.ToString()));
            }
            this.DropDownListPageNumber.SelectedIndex = 0;
        }

        /// <summary>
        /// 更新 linkbutton 首页 尾页 下一页 上一页 状态
        /// </summary>
        private void PageState()
        {
            if (this.DropDownListPageNumber.Text.Equals("1"))
            {
                this.LinkButtonFrist.Enabled = false;
                this.LinkButtonFormer.Enabled = false;                
            }
            if (this.DropDownListPageNumber.Text.Equals(this.PageCount.ToString()))
            {
                this.LinkButtonLast.Enabled = false;
                this.LinkButtonLatter.Enabled = false;
            }
            if (Convert.ToInt32(DropDownListPageNumber.Text) > 1 && Convert.ToInt32(DropDownListPageNumber.Text) < PageCount)
            {
                this.LinkButtonFrist.Enabled = true;
                this.LinkButtonFormer.Enabled = true;
                this.LinkButtonLast.Enabled = true;
                this.LinkButtonLatter.Enabled = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serivce"></param>
        /// <param name="author"></param>
        /// <param name="catalog"></param>
        /// <param name="pageNumber"></param>
        /// <param name="getNumber"></param>
        /// <param name="calculateCount">第一次查询的时候需要设置为true 去计算ItemCount</param>
        /// <returns></returns>
        private IList<ArticleEntity> getArticlesForAdmin(ArticleService serivce, string author, String catalog, int pageNumber, int getNumber, Boolean calculateCount)
        {            
            if (catalog == null)
            {
                if (calculateCount)
                {
                    this.ItemCount = serivce.getArticleListByAuthorForNumber(author);  
                }
                return serivce.getArticleListByAuthor(author, pageNumber, PageSize);
            }
            else
            {
                if (calculateCount)
                {
                    this.ItemCount = serivce.getArticleListByCatalogAndAuthorForNumber(author,catalog);                    
                }
                return serivce.getArticleListByCatalogAndAuthor(author, catalog, pageNumber, getNumber);
            }
        }

        private void setArticlesToGridView(IList<ArticleEntity> articles)
        {
            this.ds = new DataSet();
            ds.Tables.Add(TableName);
            ds.Tables[TableName].Columns.Add("ID"); 
            ds.Tables[TableName].Columns.Add("Title");
            ds.Tables[TableName].Columns.Add("Author");
            ds.Tables[TableName].Columns.Add("Catalog");
            ds.Tables[TableName].Columns.Add("UpdateTime");
            foreach (var article in articles)
            {
                DataRow row = ds.Tables[TableName].NewRow();
                row[0] = article.Id;
                row[1] = article.Title;
                row[2] = article.Author.Username;
                row[3] = article.Catalog.CatalogName;
                row[4] = article.UpdateTime.ToString();
                ds.Tables[TableName].Rows.Add(row);
            }
            this.GridViewArticle.DataSource = ds.Tables[TableName];
            this.GridViewArticle.DataBind();           
        }

        protected void GridViewArticle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ButtonCommandNameView:
                    Response.Redirect(PageInfo.PathArticleShowPage + this.GridViewArticle.Rows[rowIndex].Cells[2].Text);  
                    break;
                case ButtonCommandNameDelete:
                    DeleteArticle(this.GridViewArticle.Rows[rowIndex].Cells[2].Text);
                    this.ds.Tables[TableName].Rows[rowIndex].Delete();
                    break;
                default:
                    break;
            }
        }

        private void DeleteArticle(string articleId)
        {
            ArticleService service = new ArticleService();
            service.DeleteArticle(articleId);
            
        }

        protected void DropDownListCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            //unfinished
        }
        
    }
}