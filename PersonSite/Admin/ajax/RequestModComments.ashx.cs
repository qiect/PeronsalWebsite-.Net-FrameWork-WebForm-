using PersonSite.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonSite.Admin.ajax
{
    /// <summary>
    /// RequestModComments 的摘要说明
    /// </summary>
    public class RequestModComments : IHttpHandler
    {
        T_CommentBLL bll = new T_CommentBLL();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"],
                   idStr = context.Request["id"],
                msg = "";
            if (string.IsNullOrEmpty(action))
            {
                context.Response.Write("请求非法！");
            }
            switch (action)
            {
                case "shenhe":
                    {
                        var comment = bll.GetById(Convert.ToInt32(idStr));
                        comment.IsVisible = true;
                        msg = bll.Update(comment).ToString();
                        break;
                    }
                case "delete":
                    {
                        msg = bll.DeleteById(Convert.ToInt32(idStr)).ToString();
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