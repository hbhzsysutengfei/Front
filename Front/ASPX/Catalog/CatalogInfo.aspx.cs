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
                    ///load the catalog clients data
                    string catalog_name = Request.Params.Get(PageInfo.PathParamNameOfCatalogName);
                    if ( catalog_name == null || catalog_name.Length == 0)
                    {
                        Response.Write("<script>alert('" + PageInfo.MessageInfo_CatalogNameNull+ "');window.location.href='" + PageInfo.PathCatalogListPage + "'</script>");
                        return;
                    }
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
            }
        }

        protected void LinkButtonCatalogArticles_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogArticleListPage + Request.Params.Get(PageInfo.PathParamNameOfCatalogName));
            return;
        }

        protected void LinkButtonAuthorize_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogAuthorizePage + Request.Params.Get(PageInfo.PathParamNameOfCatalogName));
            return;
        }

        protected void LinlButtonCatalogArticleManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathArticleManagementPage);
            return;
        }
    }
}