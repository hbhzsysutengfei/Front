using Front.Model;
using Front.Service.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Front.ASPX.User
{
    public partial class Login : System.Web.UI.Page
    {
        private ClientService clientService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clientService == null)
            {
                clientService = new ClientService();
            }

            if (LabelMessageInfo.Text.Length != 0)
            {
                LabelMessageInfo.Visible = true;
            }

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            this.LabelMessageInfo.Visible = true;
            if (this.TextBoxUsername.Text.Length == 0)
            {
                this.LabelMessageInfo.Text = PageInfo.ClientUsernameNull;
                return;
            }

            if(this.TextBoxPassword.Text.Length == 0)
            {
                this.LabelMessageInfo.Text = PageInfo.ClientPasswordNull;
                return;
            }

            ClientEntity  client = clientService.ValidUser(TextBoxUsername.Text, TextBoxPassword.Text);
            if (client.PageInfo.Equals(PageInfo.PageInfoOK))
            {
                Session.Add(PageInfo.SessionKey_Client, client);
                //jump to different page according by the role type of the client in session
                //ke admin
                String pathFrom = Request.Params.Get(PageInfo.PathParmaNameOfPathFrom);
                
                if (client.Role.RoleName.Equals(PageInfo.RoleTypeAdmin))
                {
                    if (pathFrom == null)
                    {
                        Response.Redirect(PageInfo.PathDefaultPage);
                    }
                    else
                    {
                        Response.Redirect(pathFrom);
                    }
                    
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeSuperAdmin))
                {
                    if (pathFrom == null)
                    {
                        Response.Redirect(PageInfo.PathDefaultPage);
                    }
                    else
                    {
                        Response.Redirect(pathFrom);
                    }
                }
                else if (client.Role.RoleName.Equals(PageInfo.RoleTypeClient))
                {
                    if (pathFrom == null)
                    {
                        Response.Redirect(PageInfo.PathDefaultPage);
                    }
                    else
                    {
                        Response.Redirect(pathFrom);
                    }
                }                
            }
            else //in the login page with the error message
            {
                this.LabelMessageInfo.Text = client.PageInfo;
            }
        }

        
    }
}