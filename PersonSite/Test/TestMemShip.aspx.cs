using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PersonSite.Test
{
    public partial class TestMemShip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             Membership.CreateUser("test1", "123", "abc@rupeng.com");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            bool b= Membership.ValidateUser("test1", "456");
            Response.Write(b);

            bool b1 = Membership.ValidateUser("test1", "123");
            Response.Write(b1);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser();
            if (user == null)
            {
                Label1.Text = "未登录";
            }
            else
            {
                Label1.Text = user.UserName;
            }

        }
    }
}