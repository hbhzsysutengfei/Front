using Front.Model;
using Front.Service.Client;
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
                    if (client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
                    {
                        string client_name = Request.Params.Get(PageInfo.PathParamNameOfClientName);
                        if (client_name != null)
                        {
                            ClientService service = new ClientService();
                            ClientEntity view_client = service.GetClientByUsername(client_name);
                            if (view_client != null)
                            {
                                this.LabelUserNameInfo.Text = view_client.Username;
                                this.LabelRealNameInfo.Text = view_client.RealName;
                                this.LabelDepartmentInfo.Text = view_client.Department.Description;
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
                    else if (client.Role.RoleName.Equals(PageInfo.RoleTypeAdmin))
                    {
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
        }

        protected void LinkButtonChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathChangePassword);
        }

        protected void LinkButtonManagementCatalog_Click(object sender, EventArgs e)
        {

        }
    }
}