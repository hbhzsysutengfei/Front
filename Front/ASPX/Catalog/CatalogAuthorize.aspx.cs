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
    public partial class CatalogAuthorize : System.Web.UI.Page
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
                    Response.Write("<script>alert('" + PageInfo.MessageBox_NoAdministration + "');window.location.href='" + PageInfo.PathDefaultPage + "'</script>");
                    return;
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
                {
                    //load all client to the checkboxlist
                    string catalogname = Request.Params.Get(PageInfo.PathParamNameOfCatalogName);
                    if (catalogname == null || catalogname.Length == 0)
                    {
                        this.LabelPageMessageInfo.Text = PageInfo.MessageInfo_ParamCatalogNameNull;
                        return;
                    }
                    else
                    {
                        this.LabelCatalogName.Text = catalogname;
                        ClientService service = new ClientService();
                        IList<ClientEntity> clientsAdmin = service.GetAllAdmin();
                        IList<ClientEntity> clientsSuperAdmin = service.GetAllSuperAdmin();
                        foreach (var temp_client in clientsSuperAdmin)
                        {
                            this.CheckBoxListClients.Items.Add(new ListItem(temp_client.RealName, temp_client.Username));
                        }
                        foreach (var temp_client in clientsAdmin)
                        {
                            this.CheckBoxListClients.Items.Add(new ListItem(temp_client.RealName, temp_client.Username));
                        }
                    }
                }
            }
        }

        protected void LinkButtonAuthorize_Click(object sender, EventArgs e)
        {
            IList<string> names = new List<string>();
            foreach (ListItem client in this.CheckBoxListClients.Items)
            {
                if (client.Selected)
                {
                    names.Add(client.Value);
                }
            }
            CatalogEntity catalog = new CatalogService().GetCatalogByName(this.LabelCatalogName.Text);
            if (catalog == null)
            {
                this.LabelPageMessageInfo.Text = PageInfo.MessageInfo_CatalogNameNotExist;
                this.CheckBoxListClients.Items.Clear();
                return;
            }
            else
            {
                ClientService service = new ClientService();
                service.AuthorizeCatalogToClients(catalog, names.ToArray());
                Response.Redirect(PageInfo.PathCatalogAddPage);
                return;                
            }
            
        }
    }
}