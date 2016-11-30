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
    public partial class ManagementArticleMaster : System.Web.UI.Page
    {
        //private string author;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientEntity client = Session[PageInfo.SessionKey_Client] as ClientEntity;
                if (client == null)
                {
                    //Response.Write("<script>alert('" + PageInfo.+ "')</script>")
                    Response.Redirect(PageInfo.PathClientLogin);
                    return;
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeAdmin))
                {
                    ArticleService service = new ArticleService();
                    //this.GridViewArticle.PageSize = service.getArticleListByAuthorForNumber(client.Username)/PageInfo.NumberOfArticleForUserPage;
                    IList<ArticleEntity> articles = service.getArticleListByAuthor(client.Username);
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin) )
                {

                }

            }
        }
    }
}