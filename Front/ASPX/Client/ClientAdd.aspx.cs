using Front.Dao;
using Front.Model;
using Front.Service;
using Front.Service.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.ASPX.Client
{
    public partial class ClientAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientEntity client = Session[PageInfo.SessionKey_Client] as ClientEntity;
                if(client== null){
                    Response.Redirect(PageInfo.PathClientLogin + Request.Url.ToString());
                    return;
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeAdmin))
                {
                    Response.Write("<script>alert('你没有权限！');  window.location.href = "+PageInfo.PathDefaultPage+"</script>");
                    return;
                }
                else if(client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
                {
                    IList<RoleEntity> roles =  new RoleService().GetAllRoles();
                    foreach(var role in roles){
                        this.DropDownListRole.Items.Add(new ListItem(role.Description, role.RoleName));
                    }
                    IList<CatalogEntity> catalogs = new CatalogService().getAll();
                    foreach (var catalog in catalogs)
                    {
                        this.CheckBoxListCatalog.Items.Add(new ListItem(catalog.CatalogName));
                    }
                    IList<DepartmentEntity> departments = new DepartmentDao().getAllDepartments();
                    foreach (var department in departments)
                    {
                        this.DropDownListDepartment.Items.Add(new ListItem(department.Description, department.DepartmentName));
                    }
                }
            }
        }

        protected void ButtonAddClient_Click(object sender, EventArgs e)
        {
            //check
            if (this.TextBoxUsername.Text.Length == 0)
            {
                this.LabelPageMessageInfo.Text = PageInfo.ClientUsernameNull;
                return;
            }
            else if (this.TextBoxPassword.Text.Length == 0)
            {
                this.LabelPageMessageInfo.Text = PageInfo.ClientPasswordNull;
                return;
            }
            else if (this.TextBoxRepeatPassword.Text.Length == 0)
            {
                this.LabelPageMessageInfo.Text = PageInfo.ClientRepeatPasswordNull;
                return;
            }
            else if (!this.TextBoxRepeatPassword.Text.Equals(this.TextBoxPassword.Text))
            {
                this.LabelPageMessageInfo.Text = PageInfo.ClientNewPasswordAndRepeatPasswordNotSame;
                return;
            }
            else if (this.TextBoxRealName.Text.Length == 0)
            {
                this.LabelPageMessageInfo.Text = PageInfo.ClientRealNameNull;
                return;
            }

            /// check the username
            ClientService clientService = new ClientService();
            if (clientService.GetClientByUsername(this.TextBoxUsername.Text) != null)
            {
                this.LabelPageMessageInfo.Text = PageInfo.ClientUsernameAlreadExist;
                return;
            }
            else
            {
                ///add the client to the database
                ClientEntity client = new ClientEntity();
                client.Username = this.TextBoxUsername.Text;
                client.Password = this.TextBoxPassword.Text;
                client.RealName = this.TextBoxRealName.Text;
                client.Department = new DepartmentService().getByName(this.DropDownListDepartment.SelectedValue);
                client.Role = new RoleService().GetRoleByName(this.DropDownListRole.SelectedValue);
                client.encryptPassword();
                if(this.DropDownListRole.SelectedValue.Equals(PageInfo.RoleTypeAdmin) ||　this.DropDownListRole.SelectedValue.Equals(PageInfo.RoleTypeSuperAdmin)){
                    List<string> listCatalog = new List<string>();
                    foreach (ListItem catalog in this.CheckBoxListCatalog.Items)
                    {
                        if (catalog.Selected)
                        {
                            listCatalog.Add(catalog.Text);
                        }
                        
                    }
                    client.Catalogs = new CatalogService().GetCatalogsByNames(listCatalog.ToArray());
                }               
                string res = clientService.Save(client);
                if (res != null)
                {
                    Response.Redirect(PageInfo.PathClientInfo + client.Username);
                }
            }
        }

        protected void DropDownListRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownListRole.SelectedValue.Equals(PageInfo.RoleTypeAdmin) || this.DropDownListRole.SelectedValue.Equals(PageInfo.RoleTypeSuperAdmin))
            {
                this.CheckBoxListCatalog.Enabled = true;
            }
            else
            {
                this.CheckBoxListCatalog.Enabled = false;
            }
        }
    }
}