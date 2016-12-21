using Front.Model;
using Front.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.ASPX.Catalog
{
    public partial class CatalogList : System.Web.UI.Page
    {

        private DataSet ds;
        private const string TableName = "Catalog";
        private const string ButtonCommandNameView = "View";
        private const string ButtonCommandNameDelete = "Delete";

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
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeAdmin))
                {

                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
                {
                    //IList<CatalogEntity> catalogs = new CatalogService().getAll();
                    //foreach (var catalog in catalogs)
                    //{
                    //    this.BulletedListCatalog.Items.Add(new ListItem(catalog.CatalogName,PageInfo.PathCatalogInfoPage+catalog.CatalogName));
                    //}

                    //load all catalogs 
                    LoadAllCatalogs();
                }
            }
        }

        private void LoadAllCatalogs()
        {
            IList<CatalogEntity> catalogs = new CatalogService().getAll();
            ds = new DataSet();
            ds.Tables.Add(TableName);
            ds.Tables[TableName].Columns.Add("栏目名称");
            ds.Tables[TableName].Columns.Add("主页显示");
            foreach (var catalog in catalogs)
            {
                DataRow row = ds.Tables[TableName].NewRow();
                row[0] = catalog.CatalogName;
                row[1] = catalog.CatalogLoc >0 ? CatalogHelper.CatalogLocInfo[catalog.CatalogLoc - 1] : "不在主页";
                ds.Tables[TableName].Rows.Add(row);
            }
            this.GridViewCatalogs.DataSource = ds.Tables[TableName];
            this.GridViewCatalogs.DataBind();
        }

        protected void GridViewCatalogs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ButtonCommandNameView:
                    Response.Redirect(PageInfo.PathCatalogInfoPage + this.GridViewCatalogs.Rows[rowIndex].Cells[2].Text);
                    break;
                case ButtonCommandNameDelete:
                    DeleteCatalog(this.GridViewCatalogs.Rows[rowIndex].Cells[2].Text);
                    break;
                default:

                    break;
            }
        }

        protected void LinkButtonCatalogAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageInfo.PathCatalogAddPage);
        }

        private void DeleteCatalog(String catalog_name)
        {
            CatalogService service =  new CatalogService();
            service.DeleteCatalog(catalog_name);
            LoadAllCatalogs();
        }
    }
}