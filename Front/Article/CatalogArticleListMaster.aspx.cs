using Front.ASPX;
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
    public partial class CatalogArticleListMaster : System.Web.UI.Page
    {
        private string CatalogName;

        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogName = Request.Params.Get(PageInfo.PathParamNameOfCatalogName);
            if (!IsPostBack)
            {                
                if (CatalogName == null)
                {
                    return;
                }
                else
                {
                    this.LabelCatalogName.Text = CatalogName;
                    ArticleService service = new ArticleService();
                    IList<ArticleEntity> articles = service.getArticleListByCatalogName(CatalogName,0,PageInfo.NumberOfArticleForUserPage);
                    foreach (var article in articles)
                    {
                        this.BulletedListCatalogArticleList.Items.Add(
                            new ListItem(article.Title+"  "+ article.UpdateTime.ToString(), PageInfo.PathShowPage+article.Id));
                    }
                }
            }
        }
    }
}