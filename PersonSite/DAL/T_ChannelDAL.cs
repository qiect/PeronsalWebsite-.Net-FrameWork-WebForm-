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
	public partial class T_ChannelDAL
	{
        public T_Channel Add
			(T_Channel rP_Channel)
		{
				string sql ="INSERT INTO T_Channels (ParentId, Name)  output inserted.Id VALUES (@ParentId, @Name)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ParentId", ToDBValue(rP_Channel.ParentId)),
						new SqlParameter("@Name", ToDBValue(rP_Channel.Name)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE T_Channels WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(T_Channel rP_Channel)
        {
            string sql =
                "UPDATE T_Channels " +
                "SET " +
			" ParentId = @ParentId" 
                +", Name = @Name" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", rP_Channel.Id)
					,new SqlParameter("@ParentId", ToDBValue(rP_Channel.ParentId))
					,new SqlParameter("@Name", ToDBValue(rP_Channel.Name))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public T_Channel GetById(int id)
        {
            string sql = "SELECT * FROM T_Channels WHERE Id = @Id";
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
		
		public T_Channel ToModel(SqlDataReader reader)
		{
			T_Channel rP_Channel = new T_Channel();

			rP_Channel.Id = (int)ToModelValue(reader,"Id");
			rP_Channel.ParentId = (int?)ToModelValue(reader,"ParentId");
			rP_Channel.Name = (string)ToModelValue(reader,"Name");
			return rP_Channel;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM T_Channels";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<T_Channel> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<T_Channel>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_Channels) t where rownum>=@minrownum and rownum<=@maxrownum";
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
		
		public IEnumerable<T_Channel> GetAll()
		{
			var list = new List<T_Channel>();
			string sql = "SELECT * FROM T_Channels";
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
