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
	public partial class T_VideoRateDAL
	{
        public T_VideoRate Add
			(T_VideoRate rP_VideoRate)
		{
				string sql ="INSERT INTO T_VideoRates (VideoId, Action, CreateDate, IP)  output inserted.Id VALUES (@VideoId, @Action, @CreateDate, @IP)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@VideoId", ToDBValue(rP_VideoRate.VideoId)),
						new SqlParameter("@Action", ToDBValue(rP_VideoRate.Action)),
						new SqlParameter("@CreateDate", ToDBValue(rP_VideoRate.CreateDate)),
						new SqlParameter("@IP", ToDBValue(rP_VideoRate.IP)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE T_VideoRates WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(T_VideoRate rP_VideoRate)
        {
            string sql =
                "UPDATE T_VideoRates " +
                "SET " +
			" VideoId = @VideoId" 
                +", Action = @Action" 
                +", CreateDate = @CreateDate" 
                +", IP = @IP" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", rP_VideoRate.Id)
					,new SqlParameter("@VideoId", ToDBValue(rP_VideoRate.VideoId))
					,new SqlParameter("@Action", ToDBValue(rP_VideoRate.Action))
					,new SqlParameter("@CreateDate", ToDBValue(rP_VideoRate.CreateDate))
					,new SqlParameter("@IP", ToDBValue(rP_VideoRate.IP))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public T_VideoRate GetById(int id)
        {
            string sql = "SELECT * FROM T_VideoRates WHERE Id = @Id";
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
		
		public T_VideoRate ToModel(SqlDataReader reader)
		{
			T_VideoRate rP_VideoRate = new T_VideoRate();

			rP_VideoRate.Id = (int)ToModelValue(reader,"Id");
			rP_VideoRate.VideoId = (int)ToModelValue(reader,"VideoId");
			rP_VideoRate.Action = (int)ToModelValue(reader,"Action");
			rP_VideoRate.CreateDate = (DateTime)ToModelValue(reader,"CreateDate");
			rP_VideoRate.IP = (string)ToModelValue(reader,"IP");
			return rP_VideoRate;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM T_VideoRates";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<T_VideoRate> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<T_VideoRate>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_VideoRates) t where rownum>=@minrownum and rownum<=@maxrownum";
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
		
		public IEnumerable<T_VideoRate> GetAll()
		{
			var list = new List<T_VideoRate>();
			string sql = "SELECT * FROM T_VideoRates";
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
