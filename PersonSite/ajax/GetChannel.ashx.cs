using PersonSite.BLL;
using PersonSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PersonSite.ajax
{
    /// <summary>
    /// GetChannel 的摘要说明
    /// </summary>
    public class GetChannel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            T_ChannelBLL bll = new T_ChannelBLL();
            IEnumerable<T_Channel> chas = null;
            if (string.IsNullOrEmpty(action))
            {
                ShowMessage.Show("action请求为空！");
            }
            else
            {
                switch (action)
                {
                    case "cn":
                        {
                            chas = bll.GetListByCn();
                            break;
                        }
                    case "parent":
                        {
                            chas = bll.GetListByParent();
                            break;
                        }
                }
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(chas);
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