using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.ASPX.Client
{
    public partial class ClientInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientEntity client = Session[PageInfo.SessionKey_Client] as ClientEntity;
                if (client == null)
                {
                    Response.Redirect(PageInfo.PathClientLogin + Request.Url.ToString());
                }
                else
                {
                    /// write the client message to the aspx
                    this.LabelUserNameInfo.Text = client.Username;
                    this.LabelRealNameInfo.Text = client.RealName;
                    this.LabelDepartmentInfo.Text = client.Department.Description;
                    if (client.Role.RoleName.Equals(PageInfo.RoleTypeClient))
                    {
                        this.BulletedListCatalog.Visible = false;
                    }
                    else
                    {
                        foreach (var catalog in client.Catalogs)
                        {
                            this.BulletedListCatalog.Items.Add(new ListItem(catalog.CatalogName, PageInfo.PathCatalogArticleListPage + catalog.CatalogName));
                        }
                    }

                }
            }
        }

        protected void LinkButtonChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathChangePassword);
        }

        
    }
}