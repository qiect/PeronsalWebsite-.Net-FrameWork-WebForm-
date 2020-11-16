using PersonSite.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonSite.Admin.Art
{
    public partial class AddArticleByRule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                T_ChannelBLL chaBll = new T_ChannelBLL();
                ddlChannel.DataSource = chaBll.GetAll();
                ddlChannel.DataTextField = "Name";
                ddlChannel.DataValueField = "Id";
                ddlChannel.DataBind();
            }
        }
    }
}