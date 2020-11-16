using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.Model;
using System.Data.SqlClient;

namespace PersonSite.DAL
{
    public partial class T_ArticleDAL
    {
        /// <summary>
        /// 获取人气最高的文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_Article> GetTop3()
        {
            var list = new List<T_Article>();
            string sql = "select top 3 [Id],[ChannelId],[Title],[PostDate],[StaticPath],[DingCount],[CaiCount] from T_Articles order by DingCount desc";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(ToModelNotMsg(reader));
                }
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId">文章Id</param>
        /// <param name="action">顶1或踩-1</param>
        public void Rate(int articleId, int action)
        {
            if (action == -1)
            {
                SqlHelper.ExecuteNonQuery("Update T_Articles set CaiCount=CaiCount+1 where Id=@Id",
                    new SqlParameter("@Id", articleId));
            }
            else if (action == 1)
            {
                SqlHelper.ExecuteNonQuery("Update T_Articles set DingCount=DingCount+1 where Id=@Id",
                    new SqlParameter("@Id", articleId));
            }
        }


        /// <summary>
        /// 获得指定频道下所有文章
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public IEnumerable<T_Article> GetByChannelId(int channelId, string orderby = "order by PostDate desc")
        {
            var list = new List<T_Article>();
            string sql = "SELECT [Id],[ChannelId],[Title],[PostDate],[StaticPath],[DingCount],[CaiCount] FROM T_Articles  where ChannelId=@channelId "+orderby;
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@channelId", channelId)))
            {
                while (reader.Read())
                {
                    list.Add(ToModelNotMsg(reader));
                }
            }
            return list;
        }

        /// <summary>
        /// 获得50条最新资讯
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public IEnumerable<T_Article> Get50News(int count)
        {
            var list = new List<T_Article>();
            string sql = "SELECT top " + count + " [Id],[ChannelId],[Title],[PostDate],[StaticPath],[DingCount],[CaiCount] FROM T_Articles where ChannelId<>'12'  order by PostDate desc ";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(ToModelNotMsg(reader));
                }
            }
            return list;
        }
        /// <summary>
        /// 获取所有记录不包含Msg
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_Article> GetAllNotMsg()
        {
            var list = new List<T_Article>();
            string sql = "SELECT [Id],[ChannelId],[Title],[PostDate],[StaticPath],[DingCount],[CaiCount] FROM T_Articles";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(ToModelNotMsg(reader));
                }
            }
            return list;
        }
    }
}