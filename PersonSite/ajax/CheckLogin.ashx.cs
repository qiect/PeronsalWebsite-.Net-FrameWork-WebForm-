using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PersonSite.ajax
{
    /// <summary>
    /// CheckLogin 的摘要说明
    /// </summary>
    public class CheckLogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var user = Membership.GetUser();
            if (user == null)
            {
                context.Response.Write("no");
            }
            else
            {
                context.Response.Write("yes|"+user.UserName);
            }
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