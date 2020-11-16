using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonSite.BLL;

namespace PersonSite
{
    public partial class ValidateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request["username"];
            Guid vCode = new Guid(Request["vcode"]);
            T_UserInfoBLL userInfoBll = new T_UserInfoBLL();
            if (userInfoBll.ValidateVCode(username, vCode))
            {
                labelMsg.Text = "激活帐户" + username + "成功";
            }
            else
            {
                labelMsg.Text = "激活帐户" + username + "失败";
            }
        }
    }
}