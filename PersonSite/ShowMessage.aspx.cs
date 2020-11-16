using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonSite
{
    public partial class ShowMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.litMsg.Text = Request["msg"];
        }

        public static void Show(string msg)
        {
            HttpContext.Current.Response.Redirect("~/ShowMessage.aspx?msg="+HttpUtility.UrlEncode(msg));
        }
    }
}