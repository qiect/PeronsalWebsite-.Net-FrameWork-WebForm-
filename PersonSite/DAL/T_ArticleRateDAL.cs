using PersonSite.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonSite.DAL
{
    public partial class T_ArticleRateDAL
    {
        public T_ArticleRate Add
            (T_ArticleRate rP_ArticleRate)
        {
            string sql = "INSERT INTO T_ArticleRates (ArticleId, Action, CreateDate, IP)  output inserted.Id VALUES (@ArticleId, @Action, @CreateDate, @IP)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ArticleId", ToDBValue(rP_ArticleRate.ArticleId)),
						new SqlParameter("@Action", ToDBValue(rP_ArticleRate.Action)),
						new SqlParameter("@CreateDate", ToDBValue(rP_ArticleRate.CreateDate)),
						new SqlParameter("@IP", ToDBValue(rP_ArticleRate.IP)),
					};

            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetById(newId);
        }

        public int DeleteById(int id)
        {
            string sql = "DELETE T_ArticleRates WHERE Id = @Id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(T_ArticleRate rP_ArticleRate)
        {
            string sql =
                "UPDATE T_ArticleRates " +
                "SET " +
            " ArticleId = @ArticleId"
                + ", Action = @Action"
                + ", CreateDate = @CreateDate"
                + ", IP = @IP"

            + " WHERE Id = @Id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", rP_ArticleRate.Id)
					,new SqlParameter("@ArticleId", ToDBValue(rP_ArticleRate.ArticleId))
					,new SqlParameter("@Action", ToDBValue(rP_ArticleRate.Action))
					,new SqlParameter("@CreateDate", ToDBValue(rP_ArticleRate.CreateDate))
					,new SqlParameter("@IP", ToDBValue(rP_ArticleRate.IP))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public T_ArticleRate GetById(int id)
        {
            string sql = "SELECT * FROM T_ArticleRates WHERE Id = @Id";
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

        public T_ArticleRate ToModel(SqlDataReader reader)
        {
            T_ArticleRate rP_ArticleRate = new T_ArticleRate();

            rP_ArticleRate.Id = (int)ToModelValue(reader, "Id");
            rP_ArticleRate.ArticleId = (int)ToModelValue(reader, "ArticleId");
            rP_ArticleRate.Action = (int)ToModelValue(reader, "Action");
            rP_ArticleRate.CreateDate = (DateTime)ToModelValue(reader, "CreateDate");
            rP_ArticleRate.IP = (string)ToModelValue(reader, "IP");
            return rP_ArticleRate;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM T_ArticleRates";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public IEnumerable<T_ArticleRate> GetPagedData(int minrownum, int maxrownum)
        {
            var list = new List<T_ArticleRate>();
            string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_ArticleRates) t where rownum>=@minrownum and rownum<=@maxrownum";
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

        public IEnumerable<T_ArticleRate> GetAll()
        {
            var list = new List<T_ArticleRate>();
            string sql = "SELECT * FROM T_ArticleRates";
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