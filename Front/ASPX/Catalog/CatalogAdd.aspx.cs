using Front.Dao;
using Front.Model;
using Front.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.ASPX.Catalog
{
    public partial class CatalogAdd : System.Web.UI.Page
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
                    Response.Write("<script>alert('"+PageInfo.MessageBox_NoAdministration+"');window.location.href='"+PageInfo.PathDefaultPage+"'</script>");
                    return;
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
                {

                }
            }
        }

        protected void LinkButtonAddCatalog_Click(object sender, EventArgs e)
        {
            if (this.TextBoxCatalogName.Text.Length == 0)
            {
                this.LabelPageMessageInfo.Text = PageInfo.MessageInfo_CatalogNameNull;
                return;
            }
            CatalogService service =new CatalogService();
            CatalogEntity catalog = service.GetCatalogByName(this.TextBoxCatalogName.Text);
            if (catalog != null)
            {
                this.LabelPageMessageInfo.Text = PageInfo.MessageInfo_CatalogNameExist;
                this.LabelCatalogName.Text = "";
                return;
            }
            else
            {
                CatalogEntity new_catalog = new CatalogEntity(this.TextBoxCatalogName.Text);
                string res = service.SaveCatalog(new_catalog);
                if (res != null)
                {
                    Response.Redirect(PageInfo.PathCatalogAuthorizePage + new_catalog.CatalogName);
                    return;
                }
                else
                {
                    this.LabelPageMessageInfo.Text = PageInfo.MessageInfo_AddCatalogError;
                    return;
                }
            }
        }
    }
}