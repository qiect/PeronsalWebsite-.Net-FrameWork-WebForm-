using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.BLL;

namespace PersonSite
{
    public partial class FindPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            T_UserInfoBLL userInfoBll = new T_UserInfoBLL();
            var userInfo = userInfoBll.GetByUserName(txtUserName.Text);
            if (userInfo == null)
            {
                labelMsg.Text = "用户名错误";
            }
            else
            {
                Response.Redirect("FindPassword2.aspx?id="+userInfo.UserId);
            }
        }
    }
}