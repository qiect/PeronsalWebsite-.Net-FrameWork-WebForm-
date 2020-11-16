using PersonSite.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonSite.Admin.ajax
{
    /// <summary>
    /// RequestArticles 的摘要说明
    /// </summary>
    public class RequestArticles : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"],
                   id = context.Request["id"],
                   msg = "";
            if (string.IsNullOrEmpty(action))
            {
                context.Response.Write("请求非法！");
            }
            T_ArticleBLL bll = new T_ArticleBLL();
            switch (action)
            {
                case "delete":
                    {
                        msg = bll.DeleteById(int.Parse(id)).ToString();
                        break;
                    }
                case "static":
                    {
                        bll.StaticAllArticle();
                        msg = "ok";
                        break;
                    }
                case "batchdel":
                    {
                        string[] ids = id.Split(',');
                        foreach (string str in ids)
                        {
                            int count = bll.DeleteById(Convert.ToInt32(str));
                            msg += count;
                        }
                        break;
                    }
                case "addpagedata":
                    {
                        bll.AddPageDataByRule(12, null, null, null);
                        break;
                    }
            }
            context.Response.Write(msg);
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