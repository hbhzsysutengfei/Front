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
                    return;
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeClient) || client.Role.RoleName.Equals(PageInfo.RoleTypeAdmin))
                {
                    this.InitPageLinkButton(true, true, false);
                    this.FillASPXPageWithClient(client);
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
                {
                    string client_name = Request.Params.Get(PageInfo.PathParamNameOfClientName);
                    //superadmin view all client by param
                    if (client_name == null || client_name.Length == 0)
                    {
                        this.InitPageLinkButton(true, true, true);
                        this.FillASPXPageWithClient(client);

                    }
                    else if (client_name.Length > 0)
                    {
                        ClientService service = new ClientService();
                        ClientEntity view_client = service.GetClientByUsername(client_name);
                        if (view_client != null)
                        {
                            this.InitPageLinkButton(false, true, true);
                            this.FillASPXPageWithClient(view_client);
                        }
                        else
                        {
                            this.InitPageLinkButton(false, false, false);
                            this.LabelPageMessageInfo.Text = PageInfo.ClientUsernameNotExist;
                        }
                    }
                }
            }
            
        }

        private void InitPageLinkButton(Boolean change, Boolean reset, Boolean catalogManagement)
        {
            this.LinkButtonChangePassword.Enabled = change;
            this.LinkButtonChangePassword.Visible = change;
            this.LinkButtonResetPassword.Enabled = reset;
            this.LinkButtonResetPassword.Visible = reset;
            this.LinkButtonManagementCatalog.Enabled = catalogManagement;
            this.LinkButtonManagementCatalog.Visible = catalogManagement;
        }

        private void FillASPXPageWithClient(ClientEntity client)
        {
            this.LabelUserNameInfo.Text = client.Username;
            this.LabelRealNameInfo.Text = client.RealName;
            this.LabelDepartmentInfo.Text = client.Department.Description;
            this.LabelRoleInfo.Text = client.Role.Description;
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
        

        protected void LinkButtonChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathChangePassword);
        }

        protected void LinkButtonManagementCatalog_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButtonResetPassword_Click(object sender, EventArgs e)
        {
            ClientEntity client = Session[PageInfo.SessionKey_Client] as ClientEntity;
            if (client != null)
            {
                string newPassword = new ClientService().ResetPassword(client.Username);
                this.LabelPageMessageInfo.Text ="新密码："+ newPassword;
            }
            else
            {
                Response.Redirect(PageInfo.PathClientLogin + Request.Url.ToString());
            }            
        }
    }
}