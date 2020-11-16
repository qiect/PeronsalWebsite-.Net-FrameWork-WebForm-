//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PersonSite.Model;

namespace PersonSite.DAL
{
    public partial class T_ArticleDAL
    {
        public T_Article Add
            (T_Article rP_Article)
        {
            string sql = "INSERT INTO T_Articles (ChannelId, Title, PostDate, Msg, StaticPath, DingCount, CaiCount)  output inserted.Id VALUES (@ChannelId, @Title, @PostDate, @Msg, @StaticPath, @DingCount, @CaiCount)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ChannelId", ToDBValue(rP_Article.ChannelId)),
						new SqlParameter("@Title", ToDBValue(rP_Article.Title)),
						new SqlParameter("@PostDate", ToDBValue(rP_Article.PostDate)),
						new SqlParameter("@Msg", ToDBValue(rP_Article.Msg)),
						new SqlParameter("@StaticPath", ToDBValue(rP_Article.StaticPath)),
                        new SqlParameter("@DingCount", ToDBValue(rP_Article.DingCount)),
						new SqlParameter("@CaiCount", ToDBValue(rP_Article.CaiCount)),
					};

            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetById(newId);
        }

        public int DeleteById(int id)
        {
            string sql = "DELETE T_Articles WHERE Id = @Id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(T_Article rP_Article)
        {
            string sql =
                "UPDATE T_Articles " +
                "SET " +
            " ChannelId = @ChannelId"
                + ", Title = @Title"
                + ", PostDate = @PostDate"
                + ", Msg = @Msg"
                + ", StaticPath = @StaticPath"
                + ", DingCount = @DingCount"
                + ", CaiCount = @CaiCount"

            + " WHERE Id = @Id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", rP_Article.Id)
					,new SqlParameter("@ChannelId", ToDBValue(rP_Article.ChannelId))
					,new SqlParameter("@Title", ToDBValue(rP_Article.Title))
					,new SqlParameter("@PostDate", ToDBValue(rP_Article.PostDate))
					,new SqlParameter("@Msg", ToDBValue(rP_Article.Msg))
					,new SqlParameter("@StaticPath", ToDBValue(rP_Article.StaticPath))
                    ,new SqlParameter("@DingCount",ToDBValue(rP_Article.DingCount))
                    ,new SqlParameter("@CaiCount",ToDBValue(rP_Article.CaiCount))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public T_Article GetById(int id)
        {
            string sql = "SELECT * FROM T_Articles WHERE Id = @Id";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    return ToModel(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        public T_Article ToModel(SqlDataReader reader)
        {
            T_Article rP_Article = new T_Article();

            rP_Article.Id = (int)ToModelValue(reader, "Id");
            rP_Article.ChannelId = (int)ToModelValue(reader, "ChannelId");
            rP_Article.Title = (string)ToModelValue(reader, "Title");
            rP_Article.PostDate = (DateTime)ToModelValue(reader, "PostDate");
            rP_Article.Msg = (string)ToModelValue(reader, "Msg");
            rP_Article.StaticPath = (string)ToModelValue(reader, "StaticPath");
            rP_Article.DingCount = (int)ToModelValue(reader, "DingCount");
            rP_Article.CaiCount = (int)ToModelValue(reader, "CaiCount");
            return rP_Article;
        }
        public T_Article ToModelNotMsg(SqlDataReader reader)
        {
            T_Article rP_Article = new T_Article();

            rP_Article.Id = (int)ToModelValue(reader, "Id");
            rP_Article.ChannelId = (int)ToModelValue(reader, "ChannelId");
            rP_Article.Title = (string)ToModelValue(reader, "Title");
            rP_Article.PostDate = (DateTime)ToModelValue(reader, "PostDate");
            rP_Article.StaticPath = (string)ToModelValue(reader, "StaticPath");
            rP_Article.DingCount = (int)ToModelValue(reader, "DingCount");
            rP_Article.CaiCount = (int)ToModelValue(reader, "CaiCount");
            return rP_Article;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM T_Articles";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public IEnumerable<T_Article> GetPagedData(int minrownum, int maxrownum)
        {
            var list = new List<T_Article>();
            string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_Articles) t where rownum>=@minrownum and rownum<=@maxrownum";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", minrownum),
                new SqlParameter("@maxrownum", maxrownum)))
            {
                while (reader.Read())
                {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public IEnumerable<T_Article> GetAll()
        {
            var list = new List<T_Article>();
            string sql = "SELECT * FROM T_Articles";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                while (reader.Read())
                {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

        public object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        public object ToModelValue(SqlDataReader reader, string columnName)
        {
            if (reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                return null;
            }
            else
            {
                return reader[columnName];
            }
        }
    }
}
