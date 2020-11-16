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
	public partial class T_SettingDAL
	{
        public T_Setting Add
			(T_Setting rP_Setting)
		{
				string sql ="INSERT INTO T_Settings (Name, Value)  output inserted.Id VALUES (@Name, @Value)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@Name", ToDBValue(rP_Setting.Name)),
						new SqlParameter("@Value", ToDBValue(rP_Setting.Value)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE T_Settings WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(T_Setting rP_Setting)
        {
            string sql =
                "UPDATE T_Settings " +
                "SET " +
			" Name = @Name" 
                +", Value = @Value" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", rP_Setting.Id)
					,new SqlParameter("@Name", ToDBValue(rP_Setting.Name))
					,new SqlParameter("@Value", ToDBValue(rP_Setting.Value))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public T_Setting GetById(int id)
        {
            string sql = "SELECT * FROM T_Settings WHERE Id = @Id";
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
		
		public T_Setting ToModel(SqlDataReader reader)
		{
			T_Setting rP_Setting = new T_Setting();

			rP_Setting.Id = (int)ToModelValue(reader,"Id");
			rP_Setting.Name = (string)ToModelValue(reader,"Name");
			rP_Setting.Value = (string)ToModelValue(reader,"Value");
			return rP_Setting;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM T_Settings";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<T_Setting> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<T_Setting>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_Settings) t where rownum>=@minrownum and rownum<=@maxrownum";
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
		
		public IEnumerable<T_Setting> GetAll()
		{
			var list = new List<T_Setting>();
			string sql = "SELECT * FROM T_Settings";
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
