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
    public partial class CatalogList : System.Web.UI.Page
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
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
                {
                    IList<CatalogEntity> catalogs = new CatalogService().getAll();
                    foreach (var catalog in catalogs)
                    {
                        this.BulletedListCatalog.Items.Add(new ListItem(catalog.CatalogName,PageInfo.PathCatalogInfoPage+catalog.CatalogName));
                    }
                }
            }
        }
    }
}