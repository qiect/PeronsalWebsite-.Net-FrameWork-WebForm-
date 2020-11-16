using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using PersonSite.BLL;
using System.Text.RegularExpressions;
using System.Text;

namespace PersonSite
{
    public partial class FindPassword2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid userId = new Guid(Request["id"]);
                MembershipUser user = Membership.GetUser(userId);
                labelPwdQuestion.Text = user.PasswordQuestion;
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            Guid userId = new Guid(Request["id"]);
            T_UserInfoBLL userInfoBll = new T_UserInfoBLL();
            MembershipUser user = Membership.GetUser(userId);
            string newPwd;
            bool success = userInfoBll.ResetPassword(userId, txtPwdAnswer.Text, out newPwd);
            if (success)
            {
                bool isSuccess = userInfoBll.SendNewPasswordEmail(userId, newPwd);
                if (isSuccess)
                {
                    ShowMessage.Show("改密码成功！已经将新密码发到您的邮箱" + MaskEmail(user.Email));
                    //Response.Redirect("ShowMessage.aspx?msg=" + HttpUtility.UrlEncode("改密码成功！已经将新密码发到您的邮箱" + user.Email));
                    //labelMsg.Text = "改密码成功";
                }
                else
                {
                    ShowMessage.Show("改密码失败！新密码发到您的邮箱" + MaskEmail(user.Email) + "失败");
                }

            }
            else
            {
                ShowMessage.Show("改密码失败");
            }

        }

        //把abcde@163.com变成a****@163.com的格式，这样黑客就不会去尝试破解邮箱密码了
        private static string MaskEmail(string email)
        {
            Match match = Regex.Match(email, @"(\w)(\w*)@(.+)");
            string first = match.Groups[1].Value;
            string second = match.Groups[2].Value;
            string domain = match.Groups[3].Value;
            //*号的数量和邮箱用户名部分一致
            return first + Repeat("*", second.Length) + "@" + domain;
        }

        //把s重复count遍，Repeat("no",3)→nonono
        private static string Repeat(string s, int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }

    }
}