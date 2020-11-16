using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.Model;
using PersonSite.DAL;
using System.Data.SqlClient;
using System.Web.Hosting;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using System.Text.RegularExpressions;
using PersonSite.Search;

namespace PersonSite.BLL
{
    public partial class T_ArticleBLL
    {
        /// <summary>
        /// 获取所有记录不包含Msg
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_Article> GetAllNotMsg()
        {
            return new T_ArticleDAL().GetAllNotMsg();
        }

        /// <summary>
        /// 顶
        /// </summary>
        /// <param name="videoId"></param>
        public void Ding(int videoId)
        {
            new T_ArticleDAL().Rate(videoId, 1);
        }
        /// <summary>
        /// 踩
        /// </summary>
        /// <param name="videoId"></param>
        public void Cai(int videoId)
        {
            new T_ArticleDAL().Rate(videoId, -1);
        }

        /// <summary>
        /// 获得指定频道下所有文章
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public IEnumerable<T_Article> GetByChannelId(int channelId, string orderby)
        {
            return new T_ArticleDAL().GetByChannelId(channelId, orderby);
        }

        /// <summary>
        /// 获取人气最高的文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_Article> GetTop3()
        {
            return new T_ArticleDAL().GetTop3();
        }


        /// <summary>
        /// 获得50条最新资讯
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public IEnumerable<T_Article> Get50News(int count)
        {
            return new T_ArticleDAL().Get50News(count);
        }

        /// <summary>
        /// 页面全部静态化
        /// </summary>
        public void StaticAllArticle()
        {
            var arts = GetAll();
            foreach (var art in arts)
            {
                StaticArticle(art.Id);
                IndexManager.GetInstance().AddArticle(art.Id);
            }
        }

        /// <summary>
        /// 为某篇文章静态化
        /// </summary>
        /// <param name="artId"></param>
        public void StaticArticle(int artId)
        {
            T_ArticleBLL artbll = new T_ArticleBLL();
            var art = artbll.GetById(artId);

            string staticPath;
            //如果StaticPath为空，则是第一次生成静态页
            if (string.IsNullOrEmpty(art.StaticPath))
            {
                SqlParameter pName = new SqlParameter();
                pName.SqlDbType = System.Data.SqlDbType.NVarChar;
                pName.ParameterName = "@SeqName";
                pName.Value = "静态页面流水号";

                SqlParameter pResult = new SqlParameter();
                pResult.SqlDbType = System.Data.SqlDbType.Int;
                pResult.ParameterName = "@result";
                pResult.Direction = System.Data.ParameterDirection.Output;

                //调用存储过程usp_getSeqNo生成当日顺序流水号
                SqlHelper.ExecuteStoredProcedure("usp_getSeqNo", pName, pResult);
                int seqNo = (int)pResult.Value;
                //要生成的静态页面的保存路径
                //注意是发布日期，不是当前日期
                staticPath = art.PostDate.ToString(@"yyyy\/MM\/dd\/") + seqNo + ".htm";
                art.StaticPath = staticPath;
                artbll.Update(art);//把生成的静态路径保存在数据库中
            }
            else//如果不为空，则表示是重新生成静态页，重新生成不应该改变路径，复用旧的staticPath
            {
                staticPath = art.StaticPath;
            }


            string localPath = HttpContext.Current.Server.MapPath("~/Art/" + staticPath); //HostingEnvironment.MapPath();
            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            string downStaticPage = config.AppSettings.Settings["downStaticPage"].Value;
            //string downStaticPage = ConfigurationManager.AppSettings["downStaticPage"];
            //创建文件夹
            Directory.CreateDirectory(Path.GetDirectoryName(localPath));

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            //通过WebClient向服务器发Get请求，把服务器返回的html内容保存到磁盘上。以后用户直接请html文件请求。
            //todo:静态化下载文件地址做成可配置的
            wc.DownloadFile(downStaticPage + art.Id, localPath);
            //wc.DownloadFile("http://localhost:5501/Art/ViewArticle.aspx?id=" + art.Id, localPath);

        }

        /// <summary>
        /// 录入页面数据通过规则
        /// </summary>
        /// <param name="channelId">频道ID</param>
        /// <param name="url">录入的页面URL</param>
        /// <param name="matchRule">页面规则</param>
        /// <param name="matchContentRule">内容规则</param>
        /// <param name="maxCount">最大条数</param>
        //todo:规则模块，可以配置规则添加页面数据
        public void AddPageDataByRule(int channelId, string url, string matchRule, string matchContentRule, int maxCount = 250)
        {
            //从配置文件获取文章规则Url
            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            string artRuleUrl = config.AppSettings.Settings["artRuleUrl"].Value;
            string hrefRegex = config.AppSettings.Settings["hrefRegex"].Value;
            string contentRegex = config.AppSettings.Settings["contentRegex"].Value;

            var data = GetHtmlStr(artRuleUrl, "gb2312");
            string temp = data.Substring(4500).Replace("\r", " ").Replace("\n", " ");
            var matches = Regex.Matches(temp, hrefRegex, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            T_Article article = new T_Article();
            T_ArticleBLL bll = new T_ArticleBLL();
            if (matches.Count < maxCount)
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    Match match = matches[i];
                    string href = match.Groups[2].Value;
                    var content = GetHtmlStr(href, "gb2312");
                    var contentTemp = content.Replace("\r", " ").Replace("\n", " ").Replace("color=\"#ff0000\"", "").Replace("color=\"#0000ff\"", "");
                    var contentMatches = Regex.Match(contentTemp, contentRegex);
                    article.Title = match.Groups[4].Value;
                    article.PostDate = DateTime.Now;
                    article.ChannelId = channelId;
                    article.Msg = contentMatches.Value;
                    bll.Add(article);
                }
            }
        }

        /// <summary>  
        /// 获取网页的HTML码  
        /// </summary>  
        /// <param name="url">链接地址</param>  
        /// <param name="encoding">编码类型</param>  
        /// <returns></returns>  
        public string GetHtmlStr(string url, string encoding)
        {
            string htmlStr = "";
            try
            {
                if (!String.IsNullOrEmpty(url))
                {
                    WebRequest request = WebRequest.Create(url);            //实例化WebRequest对象  
                    WebResponse response = request.GetResponse();           //创建WebResponse对象  
                    Stream datastream = response.GetResponseStream();       //创建流对象  
                    Encoding ec = Encoding.Default;
                    if (encoding == "UTF8")
                    {
                        ec = Encoding.UTF8;
                    }
                    else if (encoding == "Default")
                    {
                        ec = Encoding.Default;
                    }
                    StreamReader reader = new StreamReader(datastream, ec);
                    htmlStr = reader.ReadToEnd();                  //读取网页内容  
                    reader.Close();
                    datastream.Close();
                    response.Close();
                }
            }
            catch { }
            return htmlStr;
        }

    }
}