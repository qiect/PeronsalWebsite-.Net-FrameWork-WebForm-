using PersonSite.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PersonSite.ajax
{
    /// <summary>
    /// GetArticles 的摘要说明
    /// </summary>
    public class GetArticles : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"],
            strId = context.Request["id"];
            T_ArticleBLL artBll = new T_ArticleBLL();
            JavaScriptSerializer jss = new JavaScriptSerializer();

            if (string.IsNullOrEmpty(action))
            {
                ShowMessage.Show("违法请求！");
            }
            else
            {
                switch (action)
                {
                    case "articlesbychannel":
                        {
                            IEnumerable<Model.T_Article> arts;
                            if (strId == "12")
                            {
                                arts = artBll.GetByChannelId(Convert.ToInt32(strId), "order by PostDate asc");

                            }
                            arts = artBll.GetByChannelId(Convert.ToInt32(strId), "");
                            string json = jss.Serialize(arts);
                            context.Response.Write(json);
                            break;
                        }
                    case "get50news":
                        {
                            var arts50 = artBll.Get50News(50);
                            string json = jss.Serialize(arts50);
                            context.Response.Write(json);
                            break;
                        }
                    case "top3":
                        {
                            var art3 = artBll.GetTop3();
                            string json = jss.Serialize(art3);
                            context.Response.Write(json);
                            break;
                        }
                }
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