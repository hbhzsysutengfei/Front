using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.ASPX
{
    public partial class DefaultPageForSuperAdmin : System.Web.UI.Page
    {
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
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeClient))
                {

                }
                else if(client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
                {
                    //add client functions
                    this.AddClientFunctions();

                    //add catalog functions
                    this.AddCatalogFunctions();

                    //add article functions
                    this.AddArticleFunctions();

                    //add department functions
                    this.AddDepartmentFunctions();
                }
            }
        }

        private void AddClientFunctions()
        {
            this.BulletedListClient.Items.Add(new ListItem("用户管理",PageInfo.PathClientList));
            this.BulletedListClient.Items.Add(new ListItem("添加用户", PageInfo.PathClientAdd));
        }

        private void AddCatalogFunctions()
        {
            this.BulletedListCatalog.Items.Add(new ListItem("栏目管理",PageInfo.PathCatalogListPage));
            this.BulletedListCatalog.Items.Add(new ListItem("添加栏目", PageInfo.PathCatalogAddPage));
        }

        private void AddArticleFunctions()
        {
            this.BulletedListArticle.Items.Add(new ListItem("文章管理",PageInfo.PathArticleManagementPage));
        }

        private void AddDepartmentFunctions()
        {

        }
    }
}