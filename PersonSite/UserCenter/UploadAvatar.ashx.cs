using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Drawing;
using System.Web.Script.Serialization;

namespace PersonSite.UserCenter
{
    /// <summary>
    /// UploadAvatar 的摘要说明
    /// </summary>
    public class UploadAvatar : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var user = Membership.GetUser();
            if (user == null)
            {
                context.Response.Write("notlogin");
                return;
            }
            HttpPostedFile uploadFile = context.Request.Files["Filedata"];//从文档得知
            string ext = Path.GetExtension(uploadFile.FileName);
            if (ext != ".jpg")//防止用户跳过客户端校验直接向ashx发送exe、aspx等危险的文件！服务端校验不能省！！！
            {
                context.Response.Write("非法的文件类型！");
                return;
            }
            //文件名为用户id
            string path = "/UserCenter/avatars/" + user.ProviderUserKey + ".jpg";
            string fullpath = HttpContext.Current.Server.MapPath("~"+path);
            uploadFile.SaveAs(fullpath);

            //读取文件的大小
            System.Drawing.Image img = Bitmap.FromFile(fullpath);
            string[] strs = { path, img.Size.Width.ToString(), img.Size.Height.ToString() };
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(strs);
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}