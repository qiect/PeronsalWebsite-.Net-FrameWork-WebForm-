using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using PersonSite.BLL;
using PersonSite.Model;

namespace PersonSite
{
    public partial class RegUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            MembershipCreateStatus status;
            MembershipUser user = Membership.CreateUser(txtUserName.Text, txtPwd.Text, txtEmail.Text, ddlQuestion.SelectedValue, txtAnswer.Text, true, out status);
            if (status != MembershipCreateStatus.Success)
            {
                switch (status)
                {
                    case MembershipCreateStatus.DuplicateEmail:
                        labelMsg.Text = "邮箱重复";
                        break;
                    case MembershipCreateStatus.DuplicateUserName:
                        labelMsg.Text = "用户名重复";
                        break;
                    default:
                        labelMsg.Text = status.ToString();
                        break;
                }
            }
            else
            {
                labelMsg.Text = "验证邮件发送成功，快去激活您的账号吧！";


                
                //获得刚插入的用户的Id（ASPNetSqlMembershipProvider的主键是Guid类型）
                T_UserInfoBLL userBll = new T_UserInfoBLL();
                Guid userId = (Guid)user.ProviderUserKey;
                userBll.AddUserExtra(userId, txtQQ.Text);
                if(userBll.SendValidateEmail(userId))
                {
                    //labelMsg.Text = "验证邮件发送成功，快去激活账号吧！";
                    ShowMessage.Show("验证邮件发送成功，快去激活您的账号吧！");
                }

                //注册成功后登录
                FormsAuthentication.SetAuthCookie(txtUserName.Text, true);
            }
        }
    }
}