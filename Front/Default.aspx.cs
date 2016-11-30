using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonShowPage_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("/Article/ShowPageMaster.aspx?" + "articleId=200603f0314a47709d6ee1e47dbbf1aa");
            
        }
    }
}