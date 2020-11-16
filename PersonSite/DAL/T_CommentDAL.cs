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
	public partial class T_CommentDAL
	{
        public T_Comment Add
			(T_Comment rP_Comment)
		{
				string sql ="INSERT INTO T_Comments (ArticleId, PostDate, Msg, IsVisible)  output inserted.Id VALUES (@ArticleId, @PostDate, @Msg, @IsVisible)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ArticleId", ToDBValue(rP_Comment.ArticleId)),
						new SqlParameter("@PostDate", ToDBValue(rP_Comment.PostDate)),
						new SqlParameter("@Msg", ToDBValue(rP_Comment.Msg)),
						new SqlParameter("@IsVisible", ToDBValue(rP_Comment.IsVisible)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE T_Comments WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(T_Comment rP_Comment)
        {
            string sql =
                "UPDATE T_Comments " +
                "SET " +
			" ArticleId = @ArticleId" 
                +", PostDate = @PostDate" 
                +", Msg = @Msg" 
                +", IsVisible = @IsVisible" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", rP_Comment.Id)
					,new SqlParameter("@ArticleId", ToDBValue(rP_Comment.ArticleId))
					,new SqlParameter("@PostDate", ToDBValue(rP_Comment.PostDate))
					,new SqlParameter("@Msg", ToDBValue(rP_Comment.Msg))
					,new SqlParameter("@IsVisible", ToDBValue(rP_Comment.IsVisible))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public T_Comment GetById(int id)
        {
            string sql = "SELECT * FROM T_Comments WHERE Id = @Id";
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
		
		public T_Comment ToModel(SqlDataReader reader)
		{
			T_Comment rP_Comment = new T_Comment();

			rP_Comment.Id = (int)ToModelValue(reader,"Id");
			rP_Comment.ArticleId = (int)ToModelValue(reader,"ArticleId");
			rP_Comment.PostDate = (DateTime)ToModelValue(reader,"PostDate");
			rP_Comment.Msg = (string)ToModelValue(reader,"Msg");
			rP_Comment.IsVisible = (bool)ToModelValue(reader,"IsVisible");
			return rP_Comment;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM T_Comments";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<T_Comment> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<T_Comment>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_Comments) t where rownum>=@minrownum and rownum<=@maxrownum";
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
		
		public IEnumerable<T_Comment> GetAll()
		{
			var list = new List<T_Comment>();
			string sql = "SELECT * FROM T_Comments";
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
