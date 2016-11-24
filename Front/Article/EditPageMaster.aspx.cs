using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.Article
{
    public partial class EditPageMaster : System.Web.UI.Page
    {
        //public String contents;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
            String txtContent = Request.Form["textEditPage"];
        }

       
    }
}