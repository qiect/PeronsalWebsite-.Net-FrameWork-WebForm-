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
	public partial class T_VideoDAL
	{
        public T_Video Add
			(T_Video rP_Video)
		{
				string sql ="INSERT INTO T_Videos (Title, Url, DingCount, CaiCount)  output inserted.Id VALUES (@Title, @Url, @DingCount, @CaiCount)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@Title", ToDBValue(rP_Video.Title)),
						new SqlParameter("@Url", ToDBValue(rP_Video.Url)),
						new SqlParameter("@DingCount", ToDBValue(rP_Video.DingCount)),
						new SqlParameter("@CaiCount", ToDBValue(rP_Video.CaiCount)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE T_Videos WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(T_Video rP_Video)
        {
            string sql =
                "UPDATE T_Videos " +
                "SET " +
			" Title = @Title" 
                +", Url = @Url" 
                +", DingCount = @DingCount" 
                +", CaiCount = @CaiCount" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", rP_Video.Id)
					,new SqlParameter("@Title", ToDBValue(rP_Video.Title))
					,new SqlParameter("@Url", ToDBValue(rP_Video.Url))
					,new SqlParameter("@DingCount", ToDBValue(rP_Video.DingCount))
					,new SqlParameter("@CaiCount", ToDBValue(rP_Video.CaiCount))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public T_Video GetById(int id)
        {
            string sql = "SELECT * FROM T_Videos WHERE Id = @Id";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
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
		
		public T_Video ToModel(SqlDataReader reader)
		{
			T_Video rP_Video = new T_Video();

			rP_Video.Id = (int)ToModelValue(reader,"Id");
			rP_Video.Title = (string)ToModelValue(reader,"Title");
			rP_Video.Url = (string)ToModelValue(reader,"Url");
			rP_Video.DingCount = (int)ToModelValue(reader,"DingCount");
			rP_Video.CaiCount = (int)ToModelValue(reader,"CaiCount");
			return rP_Video;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM T_Videos";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<T_Video> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<T_Video>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_Videos) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
		
		public IEnumerable<T_Video> GetAll()
		{
			var list = new List<T_Video>();
			string sql = "SELECT * FROM T_Videos";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
		
		public object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		public object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
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
