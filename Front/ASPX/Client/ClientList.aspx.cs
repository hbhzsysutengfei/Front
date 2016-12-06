using Front.Dao;
using Front.Model;
using Front.Service;
using Front.Service.Client;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.ASPX.Client
{
    public partial class ClientList : System.Web.UI.Page
    {
        private int PageSize = PageInfo.NumberOfArticleForUserPage; //每页的数据条
        private int ItemCount; //一共有多少数据
        private int CurrentPage = 0; //当前页数
        private int PageCount = 0;
        private Boolean IsPaging = true;
        private DataSet ds;
        private string TableName = "client";


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
                else if( client.Role.RoleName.Equals(PageInfo.RoleTypeClient) || client.Role.RoleName.Equals(PageInfo.RoleTypeAdmin))
                {
                    Response.Write("<script>alert('"+PageInfo.MessageBox_NoAdministration+"')</script>");
                    Response.Redirect(PageInfo.PathDefaultPage);
                    return;
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
                {
                    InitDepartment();
                    ClientService service = new ClientService();
                    IList<ClientEntity> clients = this.getAllClient(service,null,0,PageSize,true);
                    if (this.ItemCount != 0)
                    {
                        this.CurrentPage = 1;
                        this.setDropDownListPageNumber(); //初始化
                        this.PageState();                       
                    }
                    this.setItemToGridView(clients);
                }
            }
        }

        private void setDropDownListPageNumber()
        {
            this.PageCount = (this.ItemCount + PageSize - 1) / PageSize;
            for (var index = 1; index <= PageCount; index++)
            {
                this.DropDownListPageNumber.Items.Add(new ListItem(index.ToString()));
            }
            this.DropDownListPageNumber.SelectedIndex = 0;
        }

        private void setItemToGridView(IList<ClientEntity> clients)
        {
            this.ds = new DataSet();
            ds.Tables.Add(TableName);
            ds.Tables[TableName].Columns.Add("ID");
            ds.Tables[TableName].Columns.Add("UserName");
            ds.Tables[TableName].Columns.Add("RealName");
            ds.Tables[TableName].Columns.Add("Department");
            ds.Tables[TableName].Columns.Add("UpdateTime");
            foreach (var client in clients)
            {
                DataRow row = ds.Tables[TableName].NewRow();
                row[0] = client.Id;
                row[1] = client.Username;
                row[2] = client.RealName;
                row[3] = client.Department.Description;
                row[4] = client.UpdateTime.ToString();
                ds.Tables[TableName].Rows.Add(row);
            }
            this.GridViewClientList.DataSource = ds.Tables[TableName];
            this.GridViewClientList.DataBind();   
        }

        private void PageState()
        {
            if (IsPaging)
            {
                ///查询所有client 分页                
                if (this.DropDownListPageNumber.Text.Equals("1"))
                {
                    this.LinkButtonFrist.Enabled = false;
                    this.LinkButtonFormer.Enabled = false;
                }
                if (this.DropDownListPageNumber.Text.Equals(this.PageCount.ToString()))
                {
                    this.LinkButtonLast.Enabled = false;
                    this.LinkButtonLatter.Enabled = false;
                }
                if (Convert.ToInt32(DropDownListPageNumber.Text) > 1 && Convert.ToInt32(DropDownListPageNumber.Text) < PageCount)
                {
                    this.LinkButtonFrist.Enabled = true;
                    this.LinkButtonFormer.Enabled = true;
                    this.LinkButtonLast.Enabled = true;
                    this.LinkButtonLatter.Enabled = true;
                }

            }
            else
            {
                ///查询单独部门，不分页
                this.LinkButtonFrist.Visible = false;
                this.LinkButtonFrist.Enabled = false;

                this.LinkButtonLast.Visible = false;
                this.LinkButtonLast.Enabled = false;

                this.LinkButtonFormer.Visible = false;
                this.LinkButtonFormer.Enabled = false;

                this.LinkButtonLatter.Visible = false;
                this.LinkButtonLatter.Enabled = false;

                this.DropDownListPageNumber.Visible = false;
             }
        }

        private void InitDepartment()
        {
            IList<DepartmentEntity> departments = new DepartmentService().getAllDepartments();
            this.DropDownListDepartment.Items.Add(new ListItem(PageInfo.DepartmentAll));
            foreach (var department in departments)
            {
                this.DropDownListDepartment.Items.Add(new ListItem(department.Description,department.DepartmentName));
            }
            this.DropDownListDepartment.SelectedIndex = 0;
        }
        private IList<ClientEntity> getAllClient(ClientService service, string departmentDesc, int pageNumber, int getNumber, Boolean calculateItemCount)
        {
            if (departmentDesc == null)
            {
                if (calculateItemCount)
                {
                    this.ItemCount = service.GetAllClientForNumber();                    
                }
                this.IsPaging = true;
                return service.GetAllClients(pageNumber, getNumber);
            }
            else
            {
                if (calculateItemCount)
                {
                    this.ItemCount = service.GetClientByDepartmentDescForNumber(departmentDesc);
                }
                this.IsPaging = false;
                return service.getClientByDepartmentDesc(departmentDesc);                
            }           
        }


        protected void GridViewClientList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void LinkButtonFrist_Click(object sender, EventArgs e)
        {
            this.CurrentPage = 1;
            string department = this.DropDownListDepartment.SelectedItem.Text.Equals(PageInfo.DepartmentAll)? null:this.DropDownListDepartment.SelectedItem.Value;
            ClientService service = new ClientService();
            IList<ClientEntity> clients = this.getAllClient(service, department, CurrentPage - 1, PageSize,false);
            if (this.ItemCount != 0)
            {
                this.DropDownListPageNumber.SelectedIndex = this.CurrentPage - 1;
                this.PageState();
                
            }
            this.setItemToGridView(clients);
        }

        protected void LinkButtonFormer_Click(object sender, EventArgs e)
        {
            this.CurrentPage = this.CurrentPage - 1;
            if (this.CurrentPage <= this.PageCount)
            {
                string department = this.DropDownListDepartment.SelectedItem.Text.Equals(PageInfo.DepartmentAll) ? null : this.DropDownListDepartment.SelectedItem.Value;
                ClientService service = new ClientService();
                IList<ClientEntity> clients = this.getAllClient(service, department, CurrentPage - 1, PageSize, false);
                if (this.ItemCount != 0)
                {
                    this.DropDownListPageNumber.SelectedIndex = this.CurrentPage;
                    this.PageState();
                    
                }
                this.setItemToGridView(clients);
            }
           
        }

        protected void DropDownListPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CurrentPage != Convert.ToInt32(this.DropDownListPageNumber.SelectedItem.Text))
            {
                this.CurrentPage = Convert.ToInt32(this.DropDownListPageNumber.SelectedItem.Text);
                string department = this.DropDownListDepartment.SelectedItem.Text.Equals(PageInfo.DepartmentAll) ? null : this.DropDownListDepartment.SelectedItem.Value;
                ClientService service = new ClientService();
                IList<ClientEntity> clients = this.getAllClient(service, department, CurrentPage - 1, PageSize, false);
                if (this.ItemCount != 0)
                {                   
                    this.PageState();
                    
                }
                this.setItemToGridView(clients);
            }
        }

        protected void LinkButtonLatter_Click(object sender, EventArgs e)
        {
            this.CurrentPage = this.CurrentPage + 1;
            if (this.CurrentPage <= this.PageCount)
            {
                string department = this.DropDownListDepartment.SelectedItem.Text.Equals(PageInfo.DepartmentAll) ? null : this.DropDownListDepartment.SelectedItem.Value;
                ClientService service = new ClientService();
                IList<ClientEntity> clients = this.getAllClient(service, department, CurrentPage - 1, PageSize, false);
                if (this.ItemCount != 0)
                {
                    this.DropDownListPageNumber.SelectedIndex = this.CurrentPage ;
                    this.PageState();                    
                }
                this.setItemToGridView(clients);
            }
            
        }

        protected void LinkButtonLast_Click(object sender, EventArgs e)
        {
            this.CurrentPage = this.PageCount;
            if (this.CurrentPage <= this.PageCount && this.CurrentPage > 1)
            {
                string department = this.DropDownListDepartment.SelectedItem.Text.Equals(PageInfo.DepartmentAll) ? null : this.DropDownListDepartment.SelectedItem.Value;
                ClientService service = new ClientService();
                IList<ClientEntity> clients = this.getAllClient(service, department, CurrentPage - 1, PageSize, false);
                if (this.ItemCount != 0)
                {
                    this.DropDownListPageNumber.SelectedIndex = this.CurrentPage;
                    this.PageState();
                    
                }
                this.setItemToGridView(clients);
            }
        }

        protected void DropDownListDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentPage = 1;
            string department = this.DropDownListDepartment.SelectedItem.Text.Equals(PageInfo.DepartmentAll) ? null : this.DropDownListDepartment.SelectedItem.Value;
            ClientService service = new ClientService();
            IList<ClientEntity> clients = this.getAllClient(service, department, 0 , PageSize, false);
            if (this.ItemCount != 0)
            {
                
            }
            this.setItemToGridView(clients);
        }

    }
}