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
	public partial class T_AdPositionDAL
	{
        public T_AdPosition Add
			(T_AdPosition rP_AdPosition)
		{
				string sql ="INSERT INTO T_AdPositions (Name)  output inserted.Id VALUES (@Name)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@Name", ToDBValue(rP_AdPosition.Name)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE T_AdPositions WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(T_AdPosition rP_AdPosition)
        {
            string sql =
                "UPDATE T_AdPositions " +
                "SET " +
			" Name = @Name" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", rP_AdPosition.Id)
					,new SqlParameter("@Name", ToDBValue(rP_AdPosition.Name))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public T_AdPosition GetById(int id)
        {
            string sql = "SELECT * FROM T_AdPositions WHERE Id = @Id";
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
		
		public T_AdPosition ToModel(SqlDataReader reader)
		{
			T_AdPosition rP_AdPosition = new T_AdPosition();

			rP_AdPosition.Id = (int)ToModelValue(reader,"Id");
			rP_AdPosition.Name = (string)ToModelValue(reader,"Name");
			return rP_AdPosition;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM T_AdPositions";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<T_AdPosition> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<T_AdPosition>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_AdPositions) t where rownum>=@minrownum and rownum<=@maxrownum";
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
		
		public IEnumerable<T_AdPosition> GetAll()
		{
			var list = new List<T_AdPosition>();
			string sql = "SELECT * FROM T_AdPositions";
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
