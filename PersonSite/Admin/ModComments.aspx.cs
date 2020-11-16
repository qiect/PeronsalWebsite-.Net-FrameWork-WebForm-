using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.BLL;

namespace PersonSite.Admin
{
    public partial class ModComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            T_CommentBLL bll = new T_CommentBLL();
            rptModComments.DataSource= bll.GetModComments();
            rptModComments.DataBind();
        }
    }
}