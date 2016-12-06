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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientEntity client = Session[PageInfo.SessionKey_Client] as ClientEntity;
                if (client == null)
                {
                    Response.Redirect(PageInfo.PathClientLogin + Request.Url.ToString());
                }
            }
          
        }

        protected void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            if (this.TextBoxOriginalPassword.Text.Length == 0)
            {
                this.LabelMessageInfo.Text = PageInfo.ClientPasswordNull;
                return;
            }
            else if (this.TextBoxNewPassword.Text.Length == 0)
            {
                this.LabelMessageInfo.Text = PageInfo.ClientNewPasswordNull;
                return;
            }
            else if (this.TextBoxRepeatPassword.Text.Length == 0)
            {
                this.LabelMessageInfo.Text = PageInfo.ClientRepeatPasswordNull;
                return;
            }
            else if (this.TextBoxNewPassword.Text.Equals(this.TextBoxRepeatPassword.Text) == false)
            {
                this.LabelMessageInfo.Text = PageInfo.ClientNewPasswordAndRepeatPasswordNotSame;
                return;
            }
            ClientService service = new ClientService();
            ClientEntity client = Session[PageInfo.SessionKey_Client] as ClientEntity;
            ClientEntity clientFromServer = service.ValidUser(client.Username, this.TextBoxOriginalPassword.Text);
            if (clientFromServer.PageInfo.Equals(PageInfo.PageInfoOK))
            {
                //change password
                service.ChangeClientPassword(client.Username, this.TextBoxNewPassword.Text);
                Response.Write("<script>alert('修改密码成功,重新登录！')</script>");
                Session.Remove(PageInfo.SessionKey_Client);
                Response.Redirect(PageInfo.PathClientLogin + PageInfo.PathDefaultPage);
                return;
            }
            else if ( clientFromServer.PageInfo.Equals(PageInfo.ClientPasswordError))
            {
                this.LabelMessageInfo.Text = PageInfo.ClientPasswordError;
                return;
            }

        }
    }
}