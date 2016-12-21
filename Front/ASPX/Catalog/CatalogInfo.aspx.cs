using Front.Model;
using Front.Service;
using Front.Service.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.ASPX.Catalog
{
    public partial class CatalogInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientEntity client =  Session[PageInfo.SessionKey_Client] as ClientEntity;
                if (client == null)
                {
                    Response.Redirect(PageInfo.PathClientLogin + Request.Url.ToString());
                    return;
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeClient) || client.Role.RoleName.Equals(PageInfo.RoleTypeAdmin))
                {
                    Response.Write("<script>alert('"+PageInfo.MessageBox_NoAdministration+"');window.location.href='"+PageInfo.PathDefaultPage+"'</script>");
                    return;
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
                {                    
                    string catalog_name = GetCatalogName();
                    if (catalog_name == null)
                    {
                        return;
                    }
                    else
                    {
                        LoadCatalogClientList(catalog_name);
                    }                    
                }
            }
        }

        protected void LinkButtonCatalogArticles_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogArticleListPage + Request.Params.Get(PageInfo.PathParamNameOfCatalogName));
            return;
        }
        
        protected void LinlButtonCatalogArticleManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathArticleManagementPage);
            return;
        }

        protected void LinkButtonAuthorizeClientToCatalog_Click(object sender, EventArgs e)
        {
            //load client (admin and superadmin without management)
            this.CheckBoxListAddClient.Items.Clear();
            string catalog_name = this.LabelCatalogNameInfo.Text;
            ClientService service = new ClientService();
            IList<ClientEntity> clientsAdmin = service.GetAllAdmin();
            IList<ClientEntity> clientsSuperAdmin = service.GetAllSuperAdmin();
            CatalogEntity catalog = new CatalogService().GetCatalogByName(catalog_name);

            foreach (var client in clientsAdmin)
            {
                if (!client.Catalogs.Contains(catalog))
                {
                    this.CheckBoxListAddClient.Items.Add(new ListItem(client.Username, client.Username));
                }
            }
            foreach (var client in clientsSuperAdmin)
            {
                if (!client.Catalogs.Contains(catalog))
                {
                    this.CheckBoxListAddClient.Items.Add(new ListItem(client.Username, client.Username));
                }
            }

            this.UpdatePanelVisible(false, false, true);
           
        }
        protected void BottonAuthorizeClientToCatalog_Click(object sender, EventArgs e)
        {
            //authorize by the checkboxlistAddClient
            string catalog_name = this.LabelCatalogNameInfo.Text;
            List<String> usernames = new List<string>();
            
            foreach (ListItem item in this.CheckBoxListAddClient.Items)
            {
                if (item.Selected)
                {
                    usernames.Add(item.Value);
                }
            }
            new ClientService().AuthorizeCatalogToClients(catalog_name, usernames.ToArray());
            //message
            this.LoadCatalogClientList(catalog_name);
        }

        protected void LinkButtonDeleteClientForCatalog_Click(object sender, EventArgs e)
        {
            this.CheckBoxListValidUser.Items.Clear();
            foreach (ListItem item in this.BulletedListClients.Items)
            {
                this.CheckBoxListValidUser.Items.Add(item);
            }            
            this.UpdatePanelVisible(false, true, false);
        }
        

        protected void ButtonDeleteClientForCatalog_Click(object sender, EventArgs e)
        {
            //delete clients by the checkboxlist valid users
            string catalog_name = this.LabelCatalogNameInfo.Text;
            List<String> usernames = new List<string>();
            foreach(ListItem item in this.CheckBoxListValidUser.Items)
            {
                if (item.Selected)
                {
                    usernames.Add(item.Value);
                }
            }
            new ClientService().DeleteClientsForCatalog(catalog_name,usernames.ToArray());
            //message

            this.LoadCatalogClientList(catalog_name);
        }

        protected void LinkButtonClientsForCatalog_Click(object sender, EventArgs e)
        { 
            this.LoadCatalogClientList(this.LabelCatalogNameInfo.Text);            
        }

        private void UpdatePanelVisible(Boolean view, Boolean delete, Boolean add)
        {
            this.PanelValidClients.Visible = view;
            this.PanelValidClients.Enabled = view;
            this.PanelDeleteClientForCatalog.Visible = delete;
            this.PanelDeleteClientForCatalog.Enabled = delete;
            this.PanelAuthorizeClientToCatalog.Visible = add;
            this.PanelAuthorizeClientToCatalog.Enabled = add;
        }

        private void LoadCatalogClientList(string catalog_name)
        {
            this.BulletedListClients.Items.Clear();
            UpdatePanelVisible(true, false, false);
            CatalogEntity catalog = new CatalogService().GetCatalogByName(catalog_name);
            if (catalog == null)
            {
                Response.Write("<script>alert('" + PageInfo.MessageInfo_CatalogNameNotExist + "');window.location.href='" + PageInfo.PathCatalogListPage + "'</script>");
                return;
            }
            IList<ClientEntity> clients = new ClientService().GetClientsByCatalogName(catalog.CatalogName);
            this.LabelCatalogNameInfo.Text = catalog.CatalogName;
            foreach (var temp_client in clients)
            {
                this.BulletedListClients.Items.Add(new ListItem(temp_client.Username, temp_client.Username));
            }
        }

        private string GetCatalogName()
        {
            string catalog_name = Request.Params.Get(PageInfo.PathParamNameOfCatalogName);
            if (catalog_name == null || catalog_name.Length == 0)
            {
                Response.Write("<script>alert('" + PageInfo.MessageInfo_CatalogNameNull + "');window.location.href='" + PageInfo.PathCatalogListPage + "'</script>");
                return null;
            }
            else
            {
                return catalog_name;
            }           
        }

        
    }
}