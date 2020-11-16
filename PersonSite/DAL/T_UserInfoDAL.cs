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
	public partial class T_UserInfoDAL
	{
        public T_UserInfo Add
			(T_UserInfo rP_UserInfo)
		{
				string sql ="INSERT INTO T_UserInfos (UserId, QQ, Status, VCode, Credit)  VALUES (@UserId, @QQ, @Status, @VCode, @Credit)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@UserId", ToDBValue(rP_UserInfo.UserId)),
						new SqlParameter("@QQ", ToDBValue(rP_UserInfo.QQ)),
						new SqlParameter("@Status", ToDBValue(rP_UserInfo.Status)),
						new SqlParameter("@VCode", ToDBValue(rP_UserInfo.VCode)),
						new SqlParameter("@Credit", ToDBValue(rP_UserInfo.Credit)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return rP_UserInfo;				
		}

        public int DeleteByUserId(Guid userId)
		{
            string sql = "DELETE T_UserInfos WHERE UserId = @UserId";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UserId", userId)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(T_UserInfo rP_UserInfo)
        {
            string sql =
                "UPDATE T_UserInfos " +
                "SET " +
			" QQ = @QQ" 
                +", Status = @Status" 
                +", VCode = @VCode" 
                +", Credit = @Credit" 
               
            +" WHERE UserId = @UserId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UserId", rP_UserInfo.UserId)
					,new SqlParameter("@QQ", ToDBValue(rP_UserInfo.QQ))
					,new SqlParameter("@Status", ToDBValue(rP_UserInfo.Status))
					,new SqlParameter("@VCode", ToDBValue(rP_UserInfo.VCode))
					,new SqlParameter("@Credit", ToDBValue(rP_UserInfo.Credit))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public T_UserInfo GetByUserId(Guid userId)
        {
            string sql = "SELECT * FROM T_UserInfos WHERE UserId = @UserId";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@UserId", userId)))
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
		
		public T_UserInfo ToModel(SqlDataReader reader)
		{
			T_UserInfo rP_UserInfo = new T_UserInfo();

			rP_UserInfo.UserId = (Guid)ToModelValue(reader,"UserId");
			rP_UserInfo.QQ = (string)ToModelValue(reader,"QQ");
			rP_UserInfo.Status = (string)ToModelValue(reader,"Status");
			rP_UserInfo.VCode = (Guid?)ToModelValue(reader,"VCode");
			rP_UserInfo.Credit = (int?)ToModelValue(reader,"Credit");
			return rP_UserInfo;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM T_UserInfos";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<T_UserInfo> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<T_UserInfo>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by UserId) rownum FROM T_UserInfos) t where rownum>=@minrownum and rownum<=@maxrownum";
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
		
		public IEnumerable<T_UserInfo> GetAll()
		{
			var list = new List<T_UserInfo>();
			string sql = "SELECT * FROM T_UserInfos";
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
