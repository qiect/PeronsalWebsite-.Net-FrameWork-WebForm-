using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.BLL;
using System.IO;

namespace PersonSite.Admin
{
    /// <summary>
    /// ExportFilterWords 的摘要说明
    /// </summary>
    public class ExportFilterWords : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.AddHeader("Content-Disposition", "attachment");
            //context.Response.AddHeader("Content-Disposition", "attachment;filename=word.txt");
            string encodeFileName = HttpUtility.UrlEncode("过滤词.txt");
            //在浏览器弹出下载对话框保存Response，而不是直接显示到浏览器
            //filename设置默认文件名
            context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"", encodeFileName));

            T_FilterWordBLL bll = new T_FilterWordBLL();
            var filterwords = bll.GetAll();//因为数据量不大，所以也没用SqlDataReader
            foreach (var filterword in filterwords)
            {
                context.Response.Write(filterword.WordPattern + "=" + filterword.ReplaceWord + "\r\n");
            }

            //不要这样写：
            //File.WriteAllText(HttpContext.Current.Server.MapPath("~/1.txt"),"asfasfdasfasdfsa");
            //HttpContext.Current.Response.Redirect("/1.txt");
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