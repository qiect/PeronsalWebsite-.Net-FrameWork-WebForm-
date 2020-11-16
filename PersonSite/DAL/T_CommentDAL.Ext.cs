using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonSite.Model;
using System.Data.SqlClient;

namespace PersonSite.DAL
{
    public partial class T_CommentDAL
    {
        /// <summary>
        /// 获得某个文章下所有的审核通过的评论
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public IEnumerable<T_Comment> GetByArticleId(int articleId)
        {
            var list = new List<T_Comment>();
            string sql = "SELECT * FROM T_Comments where ArticleId=@articleId and IsVisible=1";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@articleId", articleId)))
            {
                while (reader.Read())
                {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<T_Comment> GetModComments()
        {
            var list = new List<T_Comment>();
            string sql = "SELECT * FROM T_Comments where IsVisible=0";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }
    }
}