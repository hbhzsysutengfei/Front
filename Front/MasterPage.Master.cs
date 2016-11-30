using Front.ASPX;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientEntity client = Session[PageInfo.SessionKey_Client] as ClientEntity;
                if (client != null)
                {
                    this.linkButtonLogin.Text = client.RealName;
                }

            }
        }
        protected void linkButtonLogin_Click(object sender, EventArgs e)
        {
            if(this.linkButtonLogin.Text.Equals(PageInfo.ASPXPageTextLogin))
            {
                Response.Redirect(PageInfo.PathClientLogin);
            }
            else
            {
                // 跳转到用户信息界面 没写
            }
            
        }
    }
}