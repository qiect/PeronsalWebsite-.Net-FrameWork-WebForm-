using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using log4net;
using System.Text.RegularExpressions;
using PersonSite.Search;

namespace PersonSite
{
    public class Global : System.Web.HttpApplication
    {
        private static ILog logger = LogManager.GetLogger(typeof(Global));

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

            PanGu.Segment.Init();

            //启动索引库的扫描线程（生产者）
            IndexManager.GetInstance().Start();

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //HttpContext.Current.RewritePath("~/Test1.aspx");
            string url = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath;//获得用户要访问的资源。这个属性获得的是虚拟路径
            //判断用户访问的是否是/Art/ViewArticle-333.aspx格式
            Match match = Regex.Match(url, @"~/Art/ViewArticle-(\d+)\.aspx");
            if (match.Success)
            {
                string id = match.Groups[1].Value;
                //把客户端请求发给内部的其他页面
                HttpContext.Current.RewritePath("~/Art/ViewArticle.aspx?id="+id);
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            logger.Error("程序中发生未捕获异常",HttpContext.Current.Server.GetLastError());
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}