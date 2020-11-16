using PersonSite.BLL;
using PersonSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonSite.ajax
{
    /// <summary>
    /// RateArticle 的摘要说明
    /// </summary>
    public class RateArticle : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string straction = context.Request["action"];
            int action = Convert.ToInt32(straction);
            int videoId = Convert.ToInt32(context.Request["articleId"]);
            string ip = context.Request.UserHostAddress;

            //判断这个ip的用户在24小时之内是否针对这个视频做出了打分
            //select count(*) from T_VideoRates where IP=@IP and datediff(hour,CreateDate,now())<=24 and videoId=@videoId
            T_ArticleRateBLL rateBll = new T_ArticleRateBLL();
            if (rateBll.Get24HRateCount(ip, videoId) > 0)
            {
                context.Response.Write("duplicate");
                return;
            }


            //评价记录插入Rate表
            T_ArticleRate rate = new T_ArticleRate();
            rate.Action = action;
            rate.CreateDate = DateTime.Now;
            rate.IP = ip;
            rate.ArticleId = videoId;
            rateBll.Add(rate);

            //更新视频的dingcount和caicount。通过冗余字段提高效率
            T_ArticleBLL videoBll = new T_ArticleBLL();
            if (action == 1)
            {
                videoBll.Ding(videoId);
            }
            else
            {
                videoBll.Cai(videoId);
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