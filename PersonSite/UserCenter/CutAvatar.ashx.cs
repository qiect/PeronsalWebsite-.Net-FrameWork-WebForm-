using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.Security;
using System.Drawing.Imaging;

namespace PersonSite.UserCenter
{
    /// <summary>
    /// CutAvatar 的摘要说明
    /// </summary>
    public class CutAvatar : IHttpHandler
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

            string strTop = context.Request["top"];
            string strLeft = context.Request["left"];
            string strWidth = context.Request["width"];
            string strHeight = context.Request["height"];

            //todo:判断参数类型是否正确
            int top = Convert.ToInt32(strTop);
            int left = Convert.ToInt32(strLeft);
            int width = Convert.ToInt32(strWidth);
            int height = Convert.ToInt32(strHeight);

            //文件名为用户id
            string path = "/UserCenter/avatars/" + user.ProviderUserKey + ".jpg";
            string fullpath = HttpContext.Current.Server.MapPath("~" + path);
            //加载原始图片
            Bitmap newBitmap;
            using (Image oldImg = Image.FromFile(fullpath))
            {
                newBitmap = CutBitmap(oldImg, width, height, left, top);
            }
            newBitmap.Save(fullpath,ImageFormat.Jpeg);
            newBitmap.Dispose();
            context.Response.Write(path);
        }

        private static Bitmap CutBitmap(Image oldImage, int width, int height, int x, int y)
        {
            if (oldImage == null)
                throw new ArgumentNullException("oldImage");

            Bitmap newBitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.InterpolationMode = InterpolationMode.High;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(oldImage, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
                g.Save();
            }
            return newBitmap;
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