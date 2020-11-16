using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PersonSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //HttpContext.Current.User.IsInRole();//是否属于角色
            //HttpContext.Current.User.Identity.IsAuthenticated //判断是否是游客
            //HttpContext.Current.User.Identity.Name;//当前登录用户名
            //Membership.GetUser()获得当前登录用户，如果用户未登录（游客），则返回null
            //MembershipUser user = Membership.GetUser();
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //验证用户
            if (Membership.ValidateUser(txtUserName.Text, txtPwd.Text))
            {
                labelMsg.Text = "登录成功";
                //设置登录
                FormsAuthentication.SetAuthCookie(txtUserName.Text, true);
            }
            else
            {
                labelMsg.Text = "登录失败";
            }
        }
    }
}