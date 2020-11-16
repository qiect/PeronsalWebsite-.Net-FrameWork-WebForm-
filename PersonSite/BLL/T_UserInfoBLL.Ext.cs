using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.Model;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using PersonSite.DAL;
using System.Text;

namespace PersonSite.BLL
{
    public partial class T_UserInfoBLL
    {
        public void AddUserExtra(Guid userId, string qq)
        {
            T_UserInfo userInfo = new T_UserInfo();
            userInfo.UserId = userId;
            userInfo.QQ = qq;
            userInfo.Status = "unactived";
            //将QQ等扩展信息加入一张自定义的新表
            new T_UserInfoBLL().Add(userInfo);
        }
        /// <summary>
        /// 注册验证邮箱
        /// </summary>
        /// <param name="userId"></param>
        public bool SendValidateEmail(Guid userId)
        {
            MembershipUser user = Membership.GetUser(userId);
            T_UserInfo userInfo = GetByUserId(userId);
            userInfo.VCode = Guid.NewGuid();//生成激活码
            new T_UserInfoBLL().Update(userInfo);//保存更新

            //MailMessage mailMsg = new MailMessage();//两个类，别混了应该引入System.Net.Mail下的

            //todo:系统邮箱、密码等都要可配置
            //mailMsg.From = new MailAddress("qct154878690@163.com", "红领巾资讯网");
            //mailMsg.To.Add(new MailAddress(user.Email, user.UserName));
            //mailMsg.Subject = "验证您的 红领巾社区 账户电子邮件地址";//发送邮件的标题 
            //string validateUrl = "http://www.hlj3.cn/ValidateUser.aspx?username=" + HttpUtility.UrlEncode(user.UserName) + "&vcode=" + userInfo.VCode;
            ////mailMsg.Body = "点击下面的链接激活您的帐户（如果看不到超链接，则把网址粘贴到您的浏览器打开）：<a href='" + validateUrl + "'>点此激活</a>";
            //mailMsg.Body = user.UserName + "，您好！<br/>您申请使用此电子邮件地址访问您的 红领巾社区 账户。点击下方链接验证电子邮件地址。 （如果看不到超链接，请把网址粘贴到您的浏览器打开）：<a href='" + validateUrl + "'>验证电子邮件</a>";
            //mailMsg.IsBodyHtml = true;
            //SmtpClient client = new SmtpClient("smtp.163.com");
            //client.Credentials = new NetworkCredential("qct154878690@163.com", "changjian520");
            ////有的smtp服务器的用户名是：yzk@rupeng.com，有的是yzk
            ////用户名、密码必须和From一致

            //client.Send(mailMsg);

            string userName = user.UserName;
            string subject = "验证您的 红领巾社区 账户电子邮件地址";
            string validateUrl = "http://www.hlj3.cn/ValidateUser.aspx?username=" + HttpUtility.UrlEncode(user.UserName) + "&vcode=" + userInfo.VCode;
            string userEmail = user.Email;
            string content = user.UserName + "，您好！<br/>您申请使用此电子邮件地址访问您的 红领巾社区 账户。点击下方链接验证电子邮件地址。 （如果看不到超链接，请把网址粘贴到您的浏览器打开）：<a href='" + validateUrl + "'>验证电子邮件</a>";
            return SendEmail(userEmail, subject, content);

        }

        public T_UserInfo GetByUserName(string username)
        {
            MembershipUser user = Membership.GetUser(username);
            if (user == null)
            {
                return null;
            }
            Guid userId = (Guid)user.ProviderUserKey;
            return GetByUserId(userId);
        }

        /// <summary>
        /// 验证用户名和验证号
        /// </summary>
        /// <param name="username"></param>
        /// <param name="vcode"></param>
        /// <returns></returns>
        public bool ValidateVCode(string username, Guid vcode)
        {
            //todo：用户名不存在、激活码错误、激活码过期（增加一个激活码生成时间字段，只有半个小时之内的才能有效）等几个状态定义为枚举
            T_UserInfo userInfo = GetByUserName(username);
            if (userInfo == null)
            {
                return false;
            }
            //return vcode == userInfo.VCode;
            if (vcode == userInfo.VCode)
            {
                //修改激活状态
                userInfo.Status = "actived";
                Update(userInfo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ResetPassword(Guid userId, string answer, out string newPwd)
        {
            newPwd = null;

            MembershipUser user = Membership.GetUser(userId);
            //只有设置requiresQuestionAndAnswer=“true”以后ResetPassword才会检查密码问题答案
            //如果答案错误，则抛出MembershipPasswordException:异常
            //如果答案正确，返回值为新密码
            try
            {
                string msPwd = user.ResetPassword(answer);
                //把微软生成密码改成稍微“人类一点的”密码
                //可以用验证码生成算法来生成一个随机的密码
                newPwd = GeneratePassword();
                if (!user.ChangePassword(msPwd, newPwd))
                {
                    return false;
                }
                return true;
            }
            catch (MembershipPasswordException memEx)
            {
                return false;
            }
        }

        //todo：SendValidateEmail、SendNewPasswordEmail中重复性的代码抽到一个方法中
        /// <summary>
        /// 发送新密码到邮箱
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newPwd"></param>
        public bool SendNewPasswordEmail(Guid userId, string newPwd)
        {
            MembershipUser user = Membership.GetUser(userId);
            T_UserInfo userInfo = GetByUserId(userId);
            userInfo.VCode = Guid.NewGuid();//生成激活码
            new T_UserInfoBLL().Update(userInfo);//保存更新

            //MailMessage mailMsg = new MailMessage();//两个类，别混了应该引入System.Net.Mail下的

            ////todo:系统邮箱、密码等都要可配置
            //mailMsg.From = new MailAddress("cgx@rupeng.com", "如鹏网");
            //mailMsg.To.Add(new MailAddress(user.Email, user.UserName));
            //mailMsg.Subject = "新在红领巾社区的新密码";//发送邮件的标题 
            //mailMsg.Body = "您在红领巾社区的用户名：" + user.UserName + "的新密码是：" + newPwd;
            //mailMsg.IsBodyHtml = true;
            //SmtpClient client = new SmtpClient("192.168.1.100");
            //client.Credentials = new NetworkCredential("cgx", "123456");
            ////有的smtp服务器的用户名是：yzk@rupeng.com，有的是yzk
            ////用户名、密码必须和From一致

            //client.Send(mailMsg);

            string userEmail = user.Email;
            string userName = user.UserName;
            string subject = "您在红领巾社区的新密码";
            string content = "您在红领巾社区的用户名：" + user.UserName + "的新密码是：" + newPwd;
            return SendEmail(userEmail, subject, content);

        }

        /// <summary>
        /// 生成6位随机密码
        /// </summary>
        /// <returns></returns>
        private static string GeneratePassword()
        {
            string id = Guid.NewGuid().ToString();
            return id.Substring(id.Length - 6);
        }

        /// <summary>
        /// 增加用户的积分
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="credit"></param>
        /// <returns></returns>
        public int IncCredit(Guid userId, int credit)
        {
            return new T_UserInfoDAL().IncCredit(userId, credit);
        }


        #region
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailTo">要发送的邮箱</param>
        /// <param name="mailSubject">邮箱主题</param>
        /// <param name="mailContent">邮箱内容</param>
        /// <returns>返回发送邮箱的结果</returns>
        public static bool SendEmail(string mailTo, string mailSubject, string mailContent)
        {
            // 设置发送方的邮件信息,例如使用网易的smtp
            string smtpServer = "smtp.163.com"; //SMTP服务器
            string mailFrom = "qct154878690@163.com"; //登陆用户名
            string userPassword = "changjian520";//登陆密码

            // 邮件服务设置
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码

            // 发送邮件设置       
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
            mailMessage.Subject = mailSubject;//主题
            mailMessage.Body = mailContent;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.Low;//优先级

            try
            {
                smtpClient.Send(mailMessage); // 发送邮件
                return true;
            }
            catch (SmtpException ex)
            {
                return false;
            }
        }
        #endregion
    }
}