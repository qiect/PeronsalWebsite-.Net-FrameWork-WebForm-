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
	public partial class T_FilterWordDAL
	{
        public T_FilterWord Add
			(T_FilterWord rP_FilterWord)
		{
				string sql ="INSERT INTO T_FilterWords (WordPattern, ReplaceWord)  output inserted.Id VALUES (@WordPattern, @ReplaceWord)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@WordPattern", ToDBValue(rP_FilterWord.WordPattern)),
						new SqlParameter("@ReplaceWord", ToDBValue(rP_FilterWord.ReplaceWord)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE T_FilterWords WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(T_FilterWord rP_FilterWord)
        {
            string sql =
                "UPDATE T_FilterWords " +
                "SET " +
			" WordPattern = @WordPattern" 
                +", ReplaceWord = @ReplaceWord" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", rP_FilterWord.Id)
					,new SqlParameter("@WordPattern", ToDBValue(rP_FilterWord.WordPattern))
					,new SqlParameter("@ReplaceWord", ToDBValue(rP_FilterWord.ReplaceWord))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public T_FilterWord GetById(int id)
        {
            string sql = "SELECT * FROM T_FilterWords WHERE Id = @Id";
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
		
		public T_FilterWord ToModel(SqlDataReader reader)
		{
			T_FilterWord rP_FilterWord = new T_FilterWord();

			rP_FilterWord.Id = (int)ToModelValue(reader,"Id");
			rP_FilterWord.WordPattern = (string)ToModelValue(reader,"WordPattern");
			rP_FilterWord.ReplaceWord = (string)ToModelValue(reader,"ReplaceWord");
			return rP_FilterWord;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM T_FilterWords";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<T_FilterWord> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<T_FilterWord>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_FilterWords) t where rownum>=@minrownum and rownum<=@maxrownum";
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
		
		public IEnumerable<T_FilterWord> GetAll()
		{
			var list = new List<T_FilterWord>();
			string sql = "SELECT * FROM T_FilterWords";
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
