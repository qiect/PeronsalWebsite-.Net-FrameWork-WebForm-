using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.BLL;
using System.Web.Script.Serialization;

namespace PersonSite.ajax
{
    /// <summary>
    /// GetComments 的摘要说明
    /// </summary>
    public class GetComments : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string articleId = context.Request["articleId"];
            T_CommentBLL bll = new T_CommentBLL();
            var comments = bll.GetByArticleId(Convert.ToInt32(articleId));
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(comments);
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