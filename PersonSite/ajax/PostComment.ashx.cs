using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.BLL;
using PersonSite.Model;

namespace PersonSite.ajax
{
    /// <summary>
    /// PostComment 的摘要说明
    /// </summary>
    public class PostComment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string articleId = context.Request["articleId"];
            string msg = context.Request["msg"];
            //防止用户提交有潜在危险的html代码，防止XSS（跨站脚本漏洞）
            if (msg.Contains("<") || msg.Contains(">"))
            {
                context.Response.Write("error");
                return;
            }

            T_FilterWordBLL filterBll = new T_FilterWordBLL();
            string replaceMsg;

            //对用户输入的评论进行过滤处理
            FilterResult result = filterBll.FilterMsg(msg, out replaceMsg);
            if (result == FilterResult.OK)
            {
                T_Comment comment = new T_Comment();
                comment.ArticleId = Convert.ToInt32(articleId);
                comment.Msg = replaceMsg;
                comment.PostDate = DateTime.Now;
                comment.IsVisible = true;

                T_CommentBLL commentBll = new T_CommentBLL();
                commentBll.Add(comment);
                context.Response.Write("ok");
            }
            else if (result == FilterResult.Mod)
            {
                //含有审核词则向数据库中插入，但是IsVisible=false，需要审核设置为true才能显示
                T_Comment comment = new T_Comment();
                comment.ArticleId = Convert.ToInt32(articleId);
                comment.Msg = replaceMsg;
                comment.PostDate = DateTime.Now;
                comment.IsVisible = false;//需要审核

                T_CommentBLL commentBll = new T_CommentBLL();
                commentBll.Add(comment);
                context.Response.Write("mod");
            }
            else if (result == FilterResult.Banned)
            {
                //如果含有禁用词，则不向数据库中插入
                context.Response.Write("banned");
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