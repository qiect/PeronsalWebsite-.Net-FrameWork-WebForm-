using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using PersonSite.Helpers;

namespace PersonSite.Admin
{
    /// <summary>
    /// UploadArticleImg 的摘要说明
    /// </summary>
    public class UploadArticleImg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile uploadFile = context.Request.Files["Filedata"];//从文档得知
            string ext = Path.GetExtension(uploadFile.FileName);
            if (ext != ".jpg")//防止用户跳过客户端校验直接向ashx发送exe、aspx等危险的文件！服务端校验不能省！！！
            {
                context.Response.Write("非法的文件类型！");
                return;
            }

            //如果用用户上传的文件名来保存文件，则可能会出现两个不同用户
            //上传的文件重名（一个用户上传两个内容不同文件名相同的文件也有这个问题）。所以计算文件内容的MD5值为文件名，这样就可以就可以解决这个问题了。
            string md5 = CommonHelper.GetStreamMD5(uploadFile.InputStream);//计算上传文件流的MD5值


            ////2011/08/09/格式
            //string now = DateTime.Now.ToString(@"yyyy\/MM\/dd\/");
            ////为了方便管理，文件按照日期进行存放，一个日期一个文件夹
            //string filename = context.Server.MapPath("~/Upload/" + now+uploadFile.FileName);//得到磁盘全路径。
            ////file c:/upload/2011/08/09/a.jpg
            //string dir = Path.GetDirectoryName(filename);//得到文件夹
            //Directory.CreateDirectory(dir);//如果文件夹不存在，则创建
            //uploadFile.SaveAs(filename);//把图片保存在硬盘上
            ////把上传的文件路径发送给客户端
            //context.Response.Write("/Upload/" + now + uploadFile.FileName);


            //2011/08/09/格式
            string now = DateTime.Now.ToString(@"yyyy\/MM\/dd\/");
            //为了方便管理，文件按照日期进行存放，一个日期一个文件夹
            string filename = context.Server.MapPath("~/Upload/" + now + md5+ext);//得到磁盘全路径。
            //file c:/upload/2011/08/09/a.jpg
            string dir = Path.GetDirectoryName(filename);//得到文件夹
            Directory.CreateDirectory(dir);//如果文件夹不存在，则创建
            uploadFile.SaveAs(filename);//把图片保存在硬盘上
            //把上传的文件路径发送给客户端
            context.Response.Write("/Upload/" + now + md5 + ext);
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