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
	public partial class T_CreditOrderDAL
	{
        public T_CreditOrder Add
			(T_CreditOrder rP_CreditOrder)
		{
				string sql ="INSERT INTO T_CreditOrders (UserId, CreditCount, Status)  output inserted.Id VALUES (@UserId, @CreditCount, @Status)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@UserId", ToDBValue(rP_CreditOrder.UserId)),
						new SqlParameter("@CreditCount", ToDBValue(rP_CreditOrder.CreditCount)),
						new SqlParameter("@Status", ToDBValue(rP_CreditOrder.Status)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE T_CreditOrders WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(T_CreditOrder rP_CreditOrder)
        {
            string sql =
                "UPDATE T_CreditOrders " +
                "SET " +
			" UserId = @UserId" 
                +", CreditCount = @CreditCount" 
                +", Status = @Status" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", rP_CreditOrder.Id)
					,new SqlParameter("@UserId", ToDBValue(rP_CreditOrder.UserId))
					,new SqlParameter("@CreditCount", ToDBValue(rP_CreditOrder.CreditCount))
					,new SqlParameter("@Status", ToDBValue(rP_CreditOrder.Status))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public T_CreditOrder GetById(int id)
        {
            string sql = "SELECT * FROM T_CreditOrders WHERE Id = @Id";
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
		
		public T_CreditOrder ToModel(SqlDataReader reader)
		{
			T_CreditOrder rP_CreditOrder = new T_CreditOrder();

			rP_CreditOrder.Id = (int)ToModelValue(reader,"Id");
			rP_CreditOrder.UserId = (Guid)ToModelValue(reader,"UserId");
			rP_CreditOrder.CreditCount = (int)ToModelValue(reader,"CreditCount");
			rP_CreditOrder.Status = (string)ToModelValue(reader,"Status");
			return rP_CreditOrder;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM T_CreditOrders";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<T_CreditOrder> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<T_CreditOrder>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_CreditOrders) t where rownum>=@minrownum and rownum<=@maxrownum";
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
		
		public IEnumerable<T_CreditOrder> GetAll()
		{
			var list = new List<T_CreditOrder>();
			string sql = "SELECT * FROM T_CreditOrders";
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
